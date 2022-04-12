
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
      this.ChessBoard = new System.Windows.Forms.Panel();
      this.BtnDismiss = new System.Windows.Forms.Button();
      this.btnDraw = new System.Windows.Forms.Button();
      this.grpPlayer2 = new System.Windows.Forms.GroupBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.SuspendLayout();
      // 
      // ChessBoard
      // 
      this.ChessBoard.BackColor = System.Drawing.SystemColors.Control;
      this.ChessBoard.Location = new System.Drawing.Point(332, 12);
      this.ChessBoard.Name = "ChessBoard";
      this.ChessBoard.Size = new System.Drawing.Size(800, 800);
      this.ChessBoard.TabIndex = 0;
      this.ChessBoard.Click += new System.EventHandler(this.GridClick);
      this.ChessBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.ChessBoard_Paint);
      // 
      // BtnDismiss
      // 
      this.BtnDismiss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
      this.BtnDismiss.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnDismiss.Location = new System.Drawing.Point(5, 773);
      this.BtnDismiss.Margin = new System.Windows.Forms.Padding(2);
      this.BtnDismiss.Name = "BtnDismiss";
      this.BtnDismiss.Size = new System.Drawing.Size(160, 39);
      this.BtnDismiss.TabIndex = 3;
      this.BtnDismiss.Text = "Dismiss";
      this.BtnDismiss.UseVisualStyleBackColor = false;
      this.BtnDismiss.Click += new System.EventHandler(this.BtnDismiss_Click);
      // 
      // btnDraw
      // 
      this.btnDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
      this.btnDraw.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDraw.Location = new System.Drawing.Point(168, 773);
      this.btnDraw.Margin = new System.Windows.Forms.Padding(2);
      this.btnDraw.Name = "btnDraw";
      this.btnDraw.Size = new System.Drawing.Size(160, 39);
      this.btnDraw.TabIndex = 4;
      this.btnDraw.Text = "Draw Match";
      this.btnDraw.UseVisualStyleBackColor = false;
      // 
      // grpPlayer2
      // 
      this.grpPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
      this.grpPlayer2.Font = new System.Drawing.Font("Monotype Corsiva", 26F, System.Drawing.FontStyle.Bold);
      this.grpPlayer2.ForeColor = System.Drawing.Color.Black;
      this.grpPlayer2.Location = new System.Drawing.Point(12, 12);
      this.grpPlayer2.Name = "grpPlayer2";
      this.grpPlayer2.Size = new System.Drawing.Size(314, 350);
      this.grpPlayer2.TabIndex = 5;
      this.grpPlayer2.TabStop = false;
      this.grpPlayer2.Text = "PLayer 2";
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
      this.groupBox1.Font = new System.Drawing.Font("Monotype Corsiva", 26F, System.Drawing.FontStyle.Bold);
      this.groupBox1.ForeColor = System.Drawing.Color.Black;
      this.groupBox1.Location = new System.Drawing.Point(12, 400);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(314, 350);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "PLayer 2";
      // 
      // FormMatch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(148)))), ((int)(((byte)(84)))));
      this.ClientSize = new System.Drawing.Size(1144, 826);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.grpPlayer2);
      this.Controls.Add(this.btnDraw);
      this.Controls.Add(this.BtnDismiss);
      this.Controls.Add(this.ChessBoard);
      this.Name = "FormMatch";
      this.Text = "FormMatch";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel ChessBoard;
    private System.Windows.Forms.Button BtnDismiss;
    private System.Windows.Forms.Button btnDraw;
    private System.Windows.Forms.GroupBox grpPlayer2;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}