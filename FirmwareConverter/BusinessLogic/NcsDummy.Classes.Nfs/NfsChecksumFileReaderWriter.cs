using NcsDummy.Classes.Checksums;
using NcsDummy.Classes.Nfs.Lines;
using System;
using System.IO;

namespace NcsDummy.Classes.Nfs
{
	public class NfsChecksumFileReaderWriter
	{
		public static bool ReadWriteBytes(Stream stream)
		{
			int num = 1;
			ushort num2 = 0;
			NfsLines nfsLines = new NfsLines();
			NfsBuffer nfsBuffer = new NfsBuffer();
			Crc16 crc = new Crc16();
			int num3;
			while ((num3 = stream.ReadByte()) > -1)
			{
				if (num3 == 0)
				{
					throw new Exception("Not a valid NFS file.");
				}
				if (nfsBuffer.Read((byte)num3) || stream.Position == stream.Length)
				{
					NfsLine nfsLine = NfsLineBuilder.BuildLine(nfsBuffer.GetBytes(), stream.Position, num);
					if (nfsLine is HexLine)
					{
						HexLine hexLine = (HexLine)nfsLine;
						num2 = crc.CalculateCrc(hexLine.CrcBytes, num2);
					}
					else if (nfsLine is KeywordLine)
					{
						KeywordLine keywordLine = (KeywordLine)nfsLine;
						keywordLine.SetCrc(num2, num);
					}
					if (nfsLine.ChecksumChanged)
					{
						nfsLines.Add(nfsLine);
					}
					nfsBuffer.Clear();
					num++;
				}
			}
			foreach (NfsLine current in nfsLines)
			{
				current.Write(stream);
			}
			return true;
		}
	}
}
