
namespace chess.Views
{
  partial class FrmMatch
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
      this.BtnResign = new System.Windows.Forms.Button();
      this.btnDraw = new System.Windows.Forms.Button();
      this.grpPlayer2 = new System.Windows.Forms.GroupBox();
      this.lblPlayerName = new System.Windows.Forms.Label();
      this.grpPlayer1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtScoreB = new System.Windows.Forms.TextBox();
      this.txtScoreA = new System.Windows.Forms.TextBox();
      this.grpPlayer2.SuspendLayout();
      this.grpPlayer1.SuspendLayout();
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
      // BtnResign
      // 
      this.BtnResign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
      this.BtnResign.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnResign.Location = new System.Drawing.Point(5, 773);
      this.BtnResign.Margin = new System.Windows.Forms.Padding(2);
      this.BtnResign.Name = "BtnResign";
      this.BtnResign.Size = new System.Drawing.Size(160, 39);
      this.BtnResign.TabIndex = 3;
      this.BtnResign.Text = "Resign";
      this.BtnResign.UseVisualStyleBackColor = false;
      this.BtnResign.Click += new System.EventHandler(this.BtnDismiss_Click);
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
      this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
      // 
      // grpPlayer2
      // 
      this.grpPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
      this.grpPlayer2.Controls.Add(this.txtScoreB);
      this.grpPlayer2.Controls.Add(this.lblPlayerName);
      this.grpPlayer2.Font = new System.Drawing.Font("Monotype Corsiva", 26F, System.Drawing.FontStyle.Bold);
      this.grpPlayer2.ForeColor = System.Drawing.Color.Black;
      this.grpPlayer2.Location = new System.Drawing.Point(12, 12);
      this.grpPlayer2.Name = "grpPlayer2";
      this.grpPlayer2.Size = new System.Drawing.Size(314, 350);
      this.grpPlayer2.TabIndex = 5;
      this.grpPlayer2.TabStop = false;
      // 
      // lblPlayerName
      // 
      this.lblPlayerName.AutoSize = true;
      this.lblPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(148)))), ((int)(((byte)(84)))));
      this.lblPlayerName.Location = new System.Drawing.Point(16, 42);
      this.lblPlayerName.Name = "lblPlayerName";
      this.lblPlayerName.Size = new System.Drawing.Size(0, 43);
      this.lblPlayerName.TabIndex = 0;
      // 
      // grpPlayer1
      // 
      this.grpPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
      this.grpPlayer1.Controls.Add(this.txtScoreA);
      this.grpPlayer1.Controls.Add(this.label1);
      this.grpPlayer1.Font = new System.Drawing.Font("Monotype Corsiva", 26F, System.Drawing.FontStyle.Bold);
      this.grpPlayer1.ForeColor = System.Drawing.Color.Black;
      this.grpPlayer1.Location = new System.Drawing.Point(12, 400);
      this.grpPlayer1.Name = "grpPlayer1";
      this.grpPlayer1.Size = new System.Drawing.Size(314, 350);
      this.grpPlayer1.TabIndex = 6;
      this.grpPlayer1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(148)))), ((int)(((byte)(84)))));
      this.label1.Location = new System.Drawing.Point(16, 42);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 43);
      this.label1.TabIndex = 0;
      // 
      // txtScoreB
      // 
      this.txtScoreB.Location = new System.Drawing.Point(22, 45);
      this.txtScoreB.Name = "txtScoreB";
      this.txtScoreB.ReadOnly = true;
      this.txtScoreB.Size = new System.Drawing.Size(162, 46);
      this.txtScoreB.TabIndex = 1;
      // 
      // txtScoreA
      // 
      this.txtScoreA.Location = new System.Drawing.Point(22, 45);
      this.txtScoreA.Name = "txtScoreA";
      this.txtScoreA.ReadOnly = true;
      this.txtScoreA.Size = new System.Drawing.Size(162, 46);
      this.txtScoreA.TabIndex = 2;
      // 
      // FrmMatch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(148)))), ((int)(((byte)(84)))));
      this.ClientSize = new System.Drawing.Size(1144, 826);
      this.Controls.Add(this.grpPlayer1);
      this.Controls.Add(this.grpPlayer2);
      this.Controls.Add(this.btnDraw);
      this.Controls.Add(this.BtnResign);
      this.Controls.Add(this.ChessBoard);
      this.Name = "FrmMatch";
      this.Text = "Chess Match";
      this.Load += new System.EventHandler(this.FormMatch_Load);
      this.grpPlayer2.ResumeLayout(false);
      this.grpPlayer2.PerformLayout();
      this.grpPlayer1.ResumeLayout(false);
      this.grpPlayer1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel ChessBoard;
    private System.Windows.Forms.Button BtnResign;
    private System.Windows.Forms.Button btnDraw;
    private System.Windows.Forms.GroupBox grpPlayer2;
    private System.Windows.Forms.Label lblPlayerName;
    private System.Windows.Forms.GroupBox grpPlayer1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtScoreB;
    private System.Windows.Forms.TextBox txtScoreA;
  }
}