using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls.UI;

using CodeJam.Strings;

using FirmwareConverter.BusinessLogic;
using Telerik.WinControls;

namespace FirmwareConverter
{
  public partial class MainForm : RadForm
  {
    string _text;

    public MainForm(string fileName)
    {
      InitializeComponent();

      _text = Text;

      if (File.Exists(fileName))
        ReadDatFile(fileName);
    }

    private void _miExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    string _datFile;
    string _folder;

    List<Firmware> _items = new List<Firmware>();

    private void _miOpen_Click(object sender, EventArgs e)
    {
      using (var dlg = new OpenFileDialog())
      {
        dlg.Filter          = "MS42/MS43 data(MDS42.DAT,MDS43.DAT)|MDS42.DAT;MDS43.DAT";
        dlg.CheckFileExists = true;

        if (dlg.ShowDialog() == DialogResult.OK)
        {
          ReadDatFile(dlg.FileName);
        }
      }
    }

    void ReadDatFile(string fileName)
    {
      Text = _text;

      _datFile = fileName;
      _folder = Path.GetDirectoryName(_datFile);

      _items = ReadFirmwares(_datFile);

      _gItems.DataSource = _items;

      Text = "{0}: {1}".FormatWith(_text, fileName);
    }

    List<Firmware> ReadFirmwares(string fileName)
    {
      var items = new List<Firmware>();

      var lines = File.ReadAllLines(fileName);
      foreach (var line in lines)
      {
        if (!line.StartsWith(";") && !line.StartsWith("$"))
        {
          var parts = line.SplitWithTrim(new [] { ',' }).ToList();
          items.Add(new Firmware { CatalogNo = parts[0], HardwareNo = parts[2], CalibrationNo = parts[4] });
        }
      }

      return items;
    }

    private void _btnSaveCalibarations_Click(object sender, EventArgs e)
    {
      if (_gItems.CurrentRow != null && _gItems.CurrentRow.DataBoundItem != null)
      {
        var item = (Firmware)_gItems.CurrentRow.DataBoundItem;
        
        var saveFileName = string.Empty;

        using (var dlg = new SaveFileDialog())
        {
          dlg.FileName = "{0}.calibrations.bin".FormatWith(item.CatalogNo);
          dlg.OverwritePrompt = true;
          if (dlg.ShowDialog() != DialogResult.OK)
            return;

          saveFileName = dlg.FileName;
        }

        var bytes = GetCalibrations(item);

        File.WriteAllBytes(saveFileName, bytes.ToArray());
      }
    }

    private void _btnSaveFull_Click(object sender, EventArgs e)
    {
      if (_gItems.CurrentRow != null && _gItems.CurrentRow.DataBoundItem != null)
      {
        var item = (Firmware)_gItems.CurrentRow.DataBoundItem;
        
        var saveFileName = string.Empty;

        using (var dlg = new SaveFileDialog())
        {
          dlg.FileName = "{0}.full.bin".FormatWith(item.CatalogNo);
          dlg.OverwritePrompt = true;
          if (dlg.ShowDialog() != DialogResult.OK)
            return;

          saveFileName = dlg.FileName;
        }

        var bytes = GetFull(item);

        File.WriteAllBytes(saveFileName, bytes.ToArray());
      }
    }
    
    int ConvertHexToInt(string hex)
    {
      return int.Parse(hex, NumberStyles.HexNumber);
    }

    List<byte> ReadFile(string fileName)
    {
      var lines = File.ReadAllLines(fileName);
      var bytes = new List<byte>();
      foreach (var line in lines)
      {
        if (line.StartsWith(":", StringComparison.InvariantCultureIgnoreCase))
        {
          var length  = ConvertHexToInt(line.Substring(1, 2));
          var address = ConvertHexToInt(line.Substring(3, 4));
          var type    = ConvertHexToInt(line.Substring(7, 2));
          
          if (type != 0)
            continue;

          var data = line.Substring(9, length * 2);
          for (var i = 0; i < length; ++i)
          {
            var hex  = data.Substring(i * 2, 2);
            var value = (byte)ConvertHexToInt(hex);

            bytes.Add(value);
          }
        }
      }

      return bytes;
    }

    List<byte> GetCalibrations(Firmware item)
    {
      var fileName = "O{0}.0{1}".FormatWith(item.CalibrationNo.Substring(StringOrigin.Begin, 7), item.CalibrationNo.Substring(StringOrigin.End, 2));
      var fullFileName = "{0}{1}{2}".FormatWith(_folder, Path.DirectorySeparatorChar, fileName);

      var bytes = ReadFile(fullFileName);

      var emptyLength = 0x10000 - bytes.Count;
      for (var i = 0; i < emptyLength; ++i)
        bytes.Add(255);

      return bytes;
    }

    List<byte> GetFull(Firmware item)
    {
      var calibrations = GetCalibrations(item);

      var fileName = "{0}A.0PA".FormatWith(item.HardwareNo);
      var fullFileName = "{0}{1}{2}".FormatWith(_folder, Path.DirectorySeparatorChar, fileName);

      var bytes = ReadFile(fullFileName);

      var emptyLength = 0x70000 - bytes.Count;
      for (var i = 0; i < emptyLength; ++i)
        bytes.Add(255);

      bytes.AddRange(calibrations);

      emptyLength = 0x80000 - bytes.Count;
      for (var i = 0; i < emptyLength; ++i)
        bytes.Add(255);

      return bytes;
    }

    private void _btnClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    void ShowError(Exception ex)
    {
      RadMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
    }

    private void _btnCalibrationsToWinKFP_Click(object sender, EventArgs e)
    {
      try
      {
        ConvertToWinKfp("calibrations", 65536);
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
    }

    private void _btnFullToWinKFP_Click(object sender, EventArgs e)
    {
      try
      {
        ConvertToWinKfp("full", 524288);
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
    }

    void ConvertToWinKfp(string fileType, int expectedLength)
    {
      using (var dlg = new OpenFileDialog())
      {
        dlg.Filter          = "*.{0}.bin|*.{0}.bin".FormatWith(fileType);
        dlg.CheckFileExists = true;

        if (dlg.ShowDialog() == DialogResult.OK)
        {
          var binFileName = dlg.FileName;

          var binFileNameOnly = Path.GetFileNameWithoutExtension(binFileName);

          var catalogNo = string.Empty;
          var dotPos = binFileNameOnly.IndexOf('.');
          if (dotPos >= 0)
            catalogNo = binFileNameOnly.Substring(0, dotPos);
          else
            throw new ApplicationException("Can't identify firmware from file name '{0}'".FormatWith(binFileName));

          var item = _items.FirstOrDefault(i => i.CatalogNo == catalogNo);
          if (item == null)
            throw new ApplicationException("Can't find firmware '{0}'".FormatWith(catalogNo));
            
          var fileName = string.Empty;
          var fileExt = string.Empty;

          if (fileType == "calibrations")
          {
            fileExt = ".0DA";
            fileName = "O{0}{1}".FormatWith(item.CalibrationNo.Substring(StringOrigin.Begin, 7), fileExt);
          }
          else
          {
            fileExt = ".0PA";
            fileName = "{0}A{1}".FormatWith(item.HardwareNo, fileExt);
          }

          var fullFileName = "{0}{1}{2}".FormatWith(_folder, Path.DirectorySeparatorChar, fileName);

          if (!File.Exists(fullFileName))
            throw new ApplicationException("Can't find file '{0}'".FormatWith(fullFileName));

          var result = ReadFile(binFileName, fullFileName, expectedLength);

          using (var memStream = new MemoryStream())
          {
            using (var writer = new StreamWriter(memStream))
            {
              foreach (var line in result)
                writer.Write(line + "\r\n");

              writer.Flush();

              memStream.Position = 0;

              NcsDummy.Classes.Nfs.NfsChecksumFileReaderWriter.ReadWriteBytes(memStream);

              using (var saveDlg = new SaveFileDialog())
              {
                saveDlg.FileName = fullFileName;
                saveDlg.OverwritePrompt = true;
                if (saveDlg.ShowDialog() != DialogResult.OK)
                  return;

                var bkFileName = saveDlg.FileName + ".original";
                if (File.Exists(saveDlg.FileName) && !File.Exists(bkFileName))
                  File.Copy(saveDlg.FileName, bkFileName);

                File.WriteAllBytes(saveDlg.FileName, memStream.ToArray());
              }
            }
          }
        }
      }
    }

    List<string> ReadFile(string binFileName, string winkfpFileName, int expectedLength)
    {
      var binBytes = File.ReadAllBytes(binFileName);
      if (binBytes.Length != expectedLength)
        throw new ApplicationException("File '{0}' has wrong size (expected {1} bytes)".FormatWith(binFileName, expectedLength));

      var lines = File.ReadAllLines(winkfpFileName);
      var result = new List<string>();

      var index = 0;
      foreach (var line in lines)
      {
        if (!line.StartsWith(":", StringComparison.InvariantCultureIgnoreCase))
        {
          result.Add(line);
        }
        else
        {
          var length  = ConvertHexToInt(line.Substring(1, 2));
          var address = ConvertHexToInt(line.Substring(3, 4));
          var type    = ConvertHexToInt(line.Substring(7, 2));
          
          if (type != 0)
          {
            result.Add(line);
            continue;
          }

          var bytes = binBytes.SubArray(index, length);

          index += length;

          var text = "{0}{1}{2}".FormatWith(line.Substring(0, 9), bytes.ToHexString(), "00");
          result.Add(text);
        }
      }

      return result;
    }

    private void _miAbout_Click(object sender, EventArgs e)
    {
      using (var form = new AboutForm())
        form.ShowDialog();
    }
  }
}
