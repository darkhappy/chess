using System.ComponentModel;

namespace chess.Views
{
  partial class FormPromotion
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
      this.BtnPromote = new System.Windows.Forms.Button();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // BtnPromote
      // 
      this.BtnPromote.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnPromote.Location = new System.Drawing.Point(258, 257);
      this.BtnPromote.Margin = new System.Windows.Forms.Padding(2);
      this.BtnPromote.Name = "BtnPromote";
      this.BtnPromote.Size = new System.Drawing.Size(199, 39);
      this.BtnPromote.TabIndex = 2;
      this.BtnPromote.Text = "Play";
      this.BtnPromote.UseVisualStyleBackColor = true;
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[] {
            "Queen",
            "Rook",
            "Bishop",
            "Knight"});
      this.comboBox1.Location = new System.Drawing.Point(258, 157);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(199, 21);
      this.comboBox1.TabIndex = 3;
      // 
      // FormPromotion
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.BtnPromote);
      this.Name = "FormPromotion";
      this.Text = "FormPromotion";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button BtnPromote;
    private System.Windows.Forms.ComboBox comboBox1;
  }
}