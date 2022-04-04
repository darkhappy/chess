
namespace chess.Views
{
  partial class FormMatch
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.Location = new System.Drawing.Point(332, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 800);
      this.panel1.TabIndex = 0;
      // 
      // FormMatch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.ClientSize = new System.Drawing.Size(1144, 826);
      this.Controls.Add(this.panel1);
      this.Name = "FormMatch";
      this.Text = "FormMatch";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
  }
}