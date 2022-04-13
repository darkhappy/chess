
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
      this.txtScoreB = new System.Windows.Forms.TextBox();
      this.lblPlayerName = new System.Windows.Forms.Label();
      this.grpPlayer1 = new System.Windows.Forms.GroupBox();
      this.txtScoreA = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.txtTurns = new System.Windows.Forms.TextBox();
      this.label18 = new System.Windows.Forms.Label();
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
      this.BtnResign.Click += new System.EventHandler(this.BtnResign_Click);
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
      // txtScoreB
      // 
      this.txtScoreB.Location = new System.Drawing.Point(22, 45);
      this.txtScoreB.Name = "txtScoreB";
      this.txtScoreB.ReadOnly = true;
      this.txtScoreB.Size = new System.Drawing.Size(162, 46);
      this.txtScoreB.TabIndex = 1;
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
      // txtScoreA
      // 
      this.txtScoreA.Location = new System.Drawing.Point(22, 45);
      this.txtScoreA.Name = "txtScoreA";
      this.txtScoreA.ReadOnly = true;
      this.txtScoreA.Size = new System.Drawing.Size(162, 46);
      this.txtScoreA.TabIndex = 2;
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
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label2.Location = new System.Drawing.Point(1137, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(17, 18);
      this.label2.TabIndex = 7;
      this.label2.Text = "8";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label3.Location = new System.Drawing.Point(1137, 115);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(17, 18);
      this.label3.TabIndex = 8;
      this.label3.Text = "7";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label4.Location = new System.Drawing.Point(1137, 215);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(17, 18);
      this.label4.TabIndex = 9;
      this.label4.Text = "6";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label5.Location = new System.Drawing.Point(1137, 315);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(17, 18);
      this.label5.TabIndex = 10;
      this.label5.Text = "5";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label6.Location = new System.Drawing.Point(1137, 415);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(17, 18);
      this.label6.TabIndex = 11;
      this.label6.Text = "4";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label7.Location = new System.Drawing.Point(1137, 515);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(17, 18);
      this.label7.TabIndex = 12;
      this.label7.Text = "3";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label8.Location = new System.Drawing.Point(1137, 615);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(17, 18);
      this.label8.TabIndex = 13;
      this.label8.Text = "2";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label9.Location = new System.Drawing.Point(1137, 715);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(17, 18);
      this.label9.TabIndex = 14;
      this.label9.Text = "1";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label10.Location = new System.Drawing.Point(329, 815);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(17, 18);
      this.label10.TabIndex = 15;
      this.label10.Text = "a";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label11.Location = new System.Drawing.Point(429, 815);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(17, 18);
      this.label11.TabIndex = 16;
      this.label11.Text = "b";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label12.Location = new System.Drawing.Point(529, 815);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(17, 18);
      this.label12.TabIndex = 17;
      this.label12.Text = "c";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label13.Location = new System.Drawing.Point(629, 815);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(17, 18);
      this.label13.TabIndex = 18;
      this.label13.Text = "d";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label14.Location = new System.Drawing.Point(729, 815);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(17, 18);
      this.label14.TabIndex = 19;
      this.label14.Text = "e";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label15.Location = new System.Drawing.Point(829, 815);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(13, 18);
      this.label15.TabIndex = 20;
      this.label15.Text = "f";
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label16.Location = new System.Drawing.Point(929, 815);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(17, 18);
      this.label16.TabIndex = 21;
      this.label16.Text = "g";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
      this.label17.Location = new System.Drawing.Point(1029, 815);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(17, 18);
      this.label17.TabIndex = 22;
      this.label17.Text = "h";
      // 
      // txtTurns
      // 
      this.txtTurns.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
      this.txtTurns.Location = new System.Drawing.Point(97, 365);
      this.txtTurns.Name = "txtTurns";
      this.txtTurns.ReadOnly = true;
      this.txtTurns.Size = new System.Drawing.Size(68, 32);
      this.txtTurns.TabIndex = 23;
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.BackColor = System.Drawing.Color.Transparent;
      this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
      this.label18.Location = new System.Drawing.Point(12, 368);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(84, 26);
      this.label18.TabIndex = 24;
      this.label18.Text = "Turns : ";
      // 
      // FrmMatch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(148)))), ((int)(((byte)(84)))));
      this.ClientSize = new System.Drawing.Size(1168, 844);
      this.Controls.Add(this.label18);
      this.Controls.Add(this.txtTurns);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
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
      this.PerformLayout();

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
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.TextBox txtTurns;
    private System.Windows.Forms.Label label18;
  }
}