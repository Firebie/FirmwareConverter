namespace FirmwareConverter
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
      this._miFile = new Telerik.WinControls.UI.RadMenuItem();
      this._miOpen = new Telerik.WinControls.UI.RadMenuItem();
      this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
      this._miExit = new Telerik.WinControls.UI.RadMenuItem();
      this._gItems = new Telerik.WinControls.UI.RadGridView();
      this._btnSaveCalibarations = new Telerik.WinControls.UI.RadButton();
      this._btnSaveFull = new Telerik.WinControls.UI.RadButton();
      this._btnCalibrationsToWinKFP = new Telerik.WinControls.UI.RadButton();
      this._btnClose = new Telerik.WinControls.UI.RadButton();
      this._btnFullToWinKFP = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._gItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._gItems.MasterTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnSaveCalibarations)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnSaveFull)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnCalibrationsToWinKFP)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnClose)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnFullToWinKFP)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radMenu1
      // 
      this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this._miFile});
      this.radMenu1.Location = new System.Drawing.Point(0, 0);
      this.radMenu1.Name = "radMenu1";
      this.radMenu1.Size = new System.Drawing.Size(565, 20);
      this.radMenu1.TabIndex = 0;
      this.radMenu1.Text = "radMenu1";
      // 
      // _miFile
      // 
      this._miFile.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this._miOpen,
            this.radMenuSeparatorItem1,
            this._miExit});
      this._miFile.Name = "_miFile";
      this._miFile.Text = "&File";
      // 
      // _miOpen
      // 
      this._miOpen.Name = "_miOpen";
      this._miOpen.Text = "&Open";
      this._miOpen.Click += new System.EventHandler(this._miOpen_Click);
      // 
      // radMenuSeparatorItem1
      // 
      this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
      this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
      this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // _miExit
      // 
      this._miExit.Name = "_miExit";
      this._miExit.Text = "E&xit";
      this._miExit.Click += new System.EventHandler(this._miExit_Click);
      // 
      // _gItems
      // 
      this._gItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._gItems.Location = new System.Drawing.Point(12, 26);
      // 
      // 
      // 
      this._gItems.MasterTemplate.AllowAddNewRow = false;
      this._gItems.MasterTemplate.AllowDeleteRow = false;
      this._gItems.MasterTemplate.AllowEditRow = false;
      gridViewTextBoxColumn1.FieldName = "CatalogNo";
      gridViewTextBoxColumn1.HeaderText = "Catalog No";
      gridViewTextBoxColumn1.Name = "CatalogNo";
      gridViewTextBoxColumn1.Width = 100;
      gridViewTextBoxColumn2.FieldName = "HardwareNo";
      gridViewTextBoxColumn2.HeaderText = "Hardware No";
      gridViewTextBoxColumn2.Name = "HardwareNo";
      gridViewTextBoxColumn2.Width = 100;
      gridViewTextBoxColumn3.FieldName = "CalibrationNo";
      gridViewTextBoxColumn3.HeaderText = "Calibration No";
      gridViewTextBoxColumn3.Name = "CalibrationNo";
      gridViewTextBoxColumn3.Width = 100;
      this._gItems.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
      this._gItems.MasterTemplate.EnableFiltering = true;
      this._gItems.MasterTemplate.ShowRowHeaderColumn = false;
      this._gItems.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this._gItems.Name = "_gItems";
      this._gItems.ReadOnly = true;
      this._gItems.Size = new System.Drawing.Size(541, 287);
      this._gItems.TabIndex = 1;
      // 
      // _btnSaveCalibarations
      // 
      this._btnSaveCalibarations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._btnSaveCalibarations.Location = new System.Drawing.Point(12, 319);
      this._btnSaveCalibarations.Name = "_btnSaveCalibarations";
      this._btnSaveCalibarations.Size = new System.Drawing.Size(134, 24);
      this._btnSaveCalibarations.TabIndex = 2;
      this._btnSaveCalibarations.Text = "Save calibrations";
      this._btnSaveCalibarations.Click += new System.EventHandler(this._btnSaveCalibarations_Click);
      // 
      // _btnSaveFull
      // 
      this._btnSaveFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._btnSaveFull.Location = new System.Drawing.Point(152, 319);
      this._btnSaveFull.Name = "_btnSaveFull";
      this._btnSaveFull.Size = new System.Drawing.Size(134, 24);
      this._btnSaveFull.TabIndex = 3;
      this._btnSaveFull.Text = "Save full";
      this._btnSaveFull.Click += new System.EventHandler(this._btnSaveFull_Click);
      // 
      // _btnCalibrationsToWinKFP
      // 
      this._btnCalibrationsToWinKFP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._btnCalibrationsToWinKFP.Location = new System.Drawing.Point(12, 349);
      this._btnCalibrationsToWinKFP.Name = "_btnCalibrationsToWinKFP";
      this._btnCalibrationsToWinKFP.Size = new System.Drawing.Size(134, 24);
      this._btnCalibrationsToWinKFP.TabIndex = 4;
      this._btnCalibrationsToWinKFP.Text = "Calibrations to WinKFP";
      this._btnCalibrationsToWinKFP.Click += new System.EventHandler(this._btnCalibrationsToWinKFP_Click);
      // 
      // _btnClose
      // 
      this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this._btnClose.Location = new System.Drawing.Point(443, 349);
      this._btnClose.Name = "_btnClose";
      this._btnClose.Size = new System.Drawing.Size(110, 24);
      this._btnClose.TabIndex = 5;
      this._btnClose.Text = "&Close";
      this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
      // 
      // _btnFullToWinKFP
      // 
      this._btnFullToWinKFP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this._btnFullToWinKFP.Location = new System.Drawing.Point(152, 349);
      this._btnFullToWinKFP.Name = "_btnFullToWinKFP";
      this._btnFullToWinKFP.Size = new System.Drawing.Size(134, 24);
      this._btnFullToWinKFP.TabIndex = 6;
      this._btnFullToWinKFP.Text = "Full to WinKFP";
      this._btnFullToWinKFP.Click += new System.EventHandler(this._btnFullToWinKFP_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this._btnClose;
      this.ClientSize = new System.Drawing.Size(565, 385);
      this.Controls.Add(this._btnFullToWinKFP);
      this.Controls.Add(this._btnClose);
      this.Controls.Add(this._btnCalibrationsToWinKFP);
      this.Controls.Add(this._btnSaveFull);
      this.Controls.Add(this._btnSaveCalibarations);
      this.Controls.Add(this._gItems);
      this.Controls.Add(this.radMenu1);
      this.Name = "MainForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Firmware converter";
      ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._gItems.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._gItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnSaveCalibarations)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnSaveFull)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnCalibrationsToWinKFP)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnClose)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this._btnFullToWinKFP)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadMenu radMenu1;
    private Telerik.WinControls.UI.RadMenuItem _miFile;
    private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
    private Telerik.WinControls.UI.RadMenuItem _miExit;
    private Telerik.WinControls.UI.RadMenuItem _miOpen;
    private Telerik.WinControls.UI.RadGridView _gItems;
    private Telerik.WinControls.UI.RadButton _btnSaveCalibarations;
    private Telerik.WinControls.UI.RadButton _btnSaveFull;
    private Telerik.WinControls.UI.RadButton _btnCalibrationsToWinKFP;
    private Telerik.WinControls.UI.RadButton _btnClose;
    private Telerik.WinControls.UI.RadButton _btnFullToWinKFP;
  }
}

