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
      this.cmbPromotion = new System.Windows.Forms.ComboBox();
      this.pbQueen = new System.Windows.Forms.PictureBox();
      this.pbKnight = new System.Windows.Forms.PictureBox();
      this.pbRook = new System.Windows.Forms.PictureBox();
      this.pbBishop = new System.Windows.Forms.PictureBox();
      this.labTitle = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pbQueen)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbKnight)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbRook)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbBishop)).BeginInit();
      this.SuspendLayout();
      // 
      // BtnPromote
      // 
      this.BtnPromote.BackColor = System.Drawing.SystemColors.Control;
      this.BtnPromote.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnPromote.Location = new System.Drawing.Point(155, 496);
      this.BtnPromote.Margin = new System.Windows.Forms.Padding(2);
      this.BtnPromote.Name = "BtnPromote";
      this.BtnPromote.Size = new System.Drawing.Size(199, 39);
      this.BtnPromote.TabIndex = 2;
      this.BtnPromote.Text = "Play";
      this.BtnPromote.UseVisualStyleBackColor = false;
      this.BtnPromote.Click += new System.EventHandler(this.BtnPromote_Click);
      // 
      // cmbPromotion
      // 
      this.cmbPromotion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbPromotion.FormattingEnabled = true;
      this.cmbPromotion.Items.AddRange(new object[] {
            "Queen",
            "Rook",
            "Bishop",
            "Knight"});
      this.cmbPromotion.Location = new System.Drawing.Point(415, 508);
      this.cmbPromotion.Name = "cmbPromotion";
      this.cmbPromotion.Size = new System.Drawing.Size(199, 21);
      this.cmbPromotion.TabIndex = 3;
      // 
      // pbQueen
      // 
      this.pbQueen.Image = global::chess.Properties.Resources.w_queen;
      this.pbQueen.Location = new System.Drawing.Point(97, 112);
      this.pbQueen.Name = "pbQueen";
      this.pbQueen.Size = new System.Drawing.Size(128, 128);
      this.pbQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbQueen.TabIndex = 4;
      this.pbQueen.TabStop = false;
      this.pbQueen.Click += new System.EventHandler(this.Promotion_Click);
      // 
      // pbKnight
      // 
      this.pbKnight.Image = global::chess.Properties.Resources.w_knight;
      this.pbKnight.Location = new System.Drawing.Point(341, 112);
      this.pbKnight.Name = "pbKnight";
      this.pbKnight.Size = new System.Drawing.Size(128, 128);
      this.pbKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbKnight.TabIndex = 5;
      this.pbKnight.TabStop = false;
      this.pbKnight.Click += new System.EventHandler(this.Promotion_Click);
      // 
      // pbRook
      // 
      this.pbRook.Image = global::chess.Properties.Resources.w_rook;
      this.pbRook.Location = new System.Drawing.Point(97, 298);
      this.pbRook.Name = "pbRook";
      this.pbRook.Size = new System.Drawing.Size(128, 128);
      this.pbRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbRook.TabIndex = 6;
      this.pbRook.TabStop = false;
      this.pbRook.Click += new System.EventHandler(this.Promotion_Click);
      // 
      // pbBishop
      // 
      this.pbBishop.Image = global::chess.Properties.Resources.w_bishop;
      this.pbBishop.Location = new System.Drawing.Point(341, 298);
      this.pbBishop.Name = "pbBishop";
      this.pbBishop.Size = new System.Drawing.Size(128, 128);
      this.pbBishop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbBishop.TabIndex = 7;
      this.pbBishop.TabStop = false;
      this.pbBishop.Click += new System.EventHandler(this.Promotion_Click);
      // 
      // labTitle
      // 
      this.labTitle.AutoSize = true;
      this.labTitle.Font = new System.Drawing.Font("Matura MT Script Capitals", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labTitle.Location = new System.Drawing.Point(41, 29);
      this.labTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labTitle.Name = "labTitle";
      this.labTitle.Size = new System.Drawing.Size(480, 42);
      this.labTitle.TabIndex = 8;
      this.labTitle.Text = " Sup boy, make your promotion";
      // 
      // FormPromotion
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(148)))), ((int)(((byte)(84)))));
      this.ClientSize = new System.Drawing.Size(575, 560);
      this.ControlBox = false;
      this.Controls.Add(this.labTitle);
      this.Controls.Add(this.pbBishop);
      this.Controls.Add(this.pbRook);
      this.Controls.Add(this.pbKnight);
      this.Controls.Add(this.pbQueen);
      this.Controls.Add(this.cmbPromotion);
      this.Controls.Add(this.BtnPromote);
      this.Name = "FormPromotion";
      this.Text = "FormPromotion";
      ((System.ComponentModel.ISupportInitialize)(this.pbQueen)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbKnight)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbRook)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbBishop)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button BtnPromote;
    private System.Windows.Forms.ComboBox cmbPromotion;
    private System.Windows.Forms.PictureBox pbKnight;
    private System.Windows.Forms.PictureBox pbRook;
    private System.Windows.Forms.PictureBox pbBishop;
    private System.Windows.Forms.Label labTitle;
    private System.Windows.Forms.PictureBox pbQueen;
  }
}