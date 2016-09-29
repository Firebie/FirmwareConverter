namespace FirmwareConverter
{
  partial class AboutForm
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
      this._btnClose = new Telerik.WinControls.UI.RadButton();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this._btnClose)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // _btnClose
      // 
      this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this._btnClose.Location = new System.Drawing.Point(235, 82);
      this._btnClose.Name = "_btnClose";
      this._btnClose.Size = new System.Drawing.Size(110, 24);
      this._btnClose.TabIndex = 6;
      this._btnClose.Text = "&Close";
      // 
      // radLabel1
      // 
      this.radLabel1.Location = new System.Drawing.Point(12, 12);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(105, 18);
      this.radLabel1.TabIndex = 8;
      this.radLabel1.Text = "Copyright (c) firebie";
      // 
      // radLabel2
      // 
      this.radLabel2.Location = new System.Drawing.Point(12, 36);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(337, 18);
      this.radLabel2.TabIndex = 9;
      this.radLabel2.Text = "NFS files code copyright (c) revtor (Thanks for great NCS Dummy!)";
      // 
      // radLabel3
      // 
      this.radLabel3.Location = new System.Drawing.Point(12, 60);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(105, 18);
      this.radLabel3.TabIndex = 10;
      this.radLabel3.Text = "This software is free";
      // 
      // AboutForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this._btnClose;
      this.ClientSize = new System.Drawing.Size(357, 118);
      this.Controls.Add(this.radLabel3);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this._btnClose);
      this.Name = "AboutForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About";
      ((System.ComponentModel.ISupportInitialize)(this._btnClose)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadButton _btnClose;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadLabel radLabel3;
  }
}