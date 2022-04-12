using System.ComponentModel;

namespace chess.Views
{
  partial class FormMenu
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
      this.labTitle = new System.Windows.Forms.Label();
      this.BtnNew = new System.Windows.Forms.Button();
      this.BtnManage = new System.Windows.Forms.Button();
      this.BtnExit = new System.Windows.Forms.Button();
      this.listPlayer = new System.Windows.Forms.ListView();
      this.labPlayer1 = new System.Windows.Forms.Label();
      this.txbPlayer1 = new System.Windows.Forms.TextBox();
      this.txbPlayer2 = new System.Windows.Forms.TextBox();
      this.labPlayer2 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnCancel1 = new System.Windows.Forms.Button();
      this.btnCancel2 = new System.Windows.Forms.Button();
      this.labError = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // labTitle
      // 
      this.labTitle.AutoSize = true;
      this.labTitle.Font = new System.Drawing.Font("Matura MT Script Capitals", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labTitle.Location = new System.Drawing.Point(44, 18);
      this.labTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labTitle.Name = "labTitle";
      this.labTitle.Size = new System.Drawing.Size(493, 42);
      this.labTitle.TabIndex = 0;
      this.labTitle.Text = "Welcom to chess big chad boy !";
      // 
      // BtnNew
      // 
      this.BtnNew.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnNew.Location = new System.Drawing.Point(318, 297);
      this.BtnNew.Margin = new System.Windows.Forms.Padding(2);
      this.BtnNew.Name = "BtnNew";
      this.BtnNew.Size = new System.Drawing.Size(199, 39);
      this.BtnNew.TabIndex = 1;
      this.BtnNew.Text = "Play";
      this.BtnNew.UseVisualStyleBackColor = true;
      this.BtnNew.Click += new System.EventHandler(this.Start);
      // 
      // BtnManage
      // 
      this.BtnManage.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnManage.Location = new System.Drawing.Point(65, 370);
      this.BtnManage.Margin = new System.Windows.Forms.Padding(2);
      this.BtnManage.Name = "BtnManage";
      this.BtnManage.Size = new System.Drawing.Size(199, 39);
      this.BtnManage.TabIndex = 2;
      this.BtnManage.Text = "Manage Player";
      this.BtnManage.UseVisualStyleBackColor = true;
      this.BtnManage.Click += new System.EventHandler(this.ManagePlayer);
      // 
      // BtnExit
      // 
      this.BtnExit.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnExit.Location = new System.Drawing.Point(318, 370);
      this.BtnExit.Margin = new System.Windows.Forms.Padding(2);
      this.BtnExit.Name = "BtnExit";
      this.BtnExit.Size = new System.Drawing.Size(199, 39);
      this.BtnExit.TabIndex = 3;
      this.BtnExit.Text = "Exit";
      this.BtnExit.UseVisualStyleBackColor = true;
      this.BtnExit.Click += new System.EventHandler(this.Exit);
      // 
      // listPlayer
      // 
      this.listPlayer.HideSelection = false;
      this.listPlayer.Location = new System.Drawing.Point(65, 116);
      this.listPlayer.Margin = new System.Windows.Forms.Padding(2);
      this.listPlayer.Name = "listPlayer";
      this.listPlayer.Size = new System.Drawing.Size(199, 220);
      this.listPlayer.TabIndex = 6;
      this.listPlayer.UseCompatibleStateImageBehavior = false;
      this.listPlayer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPlayer_MouseDoubleClick);
      // 
      // labPlayer1
      // 
      this.labPlayer1.AutoSize = true;
      this.labPlayer1.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F);
      this.labPlayer1.Location = new System.Drawing.Point(314, 102);
      this.labPlayer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labPlayer1.Name = "labPlayer1";
      this.labPlayer1.Size = new System.Drawing.Size(74, 22);
      this.labPlayer1.TabIndex = 8;
      this.labPlayer1.Text = "Player 1:";
      // 
      // txbPlayer1
      // 
      this.txbPlayer1.Enabled = false;
      this.txbPlayer1.Location = new System.Drawing.Point(318, 127);
      this.txbPlayer1.Name = "txbPlayer1";
      this.txbPlayer1.Size = new System.Drawing.Size(164, 20);
      this.txbPlayer1.TabIndex = 10;
      // 
      // txbPlayer2
      // 
      this.txbPlayer2.Enabled = false;
      this.txbPlayer2.Location = new System.Drawing.Point(318, 188);
      this.txbPlayer2.Name = "txbPlayer2";
      this.txbPlayer2.Size = new System.Drawing.Size(164, 20);
      this.txbPlayer2.TabIndex = 12;
      // 
      // labPlayer2
      // 
      this.labPlayer2.AutoSize = true;
      this.labPlayer2.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F);
      this.labPlayer2.Location = new System.Drawing.Point(314, 163);
      this.labPlayer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labPlayer2.Name = "labPlayer2";
      this.labPlayer2.Size = new System.Drawing.Size(75, 22);
      this.labPlayer2.TabIndex = 11;
      this.labPlayer2.Text = "Player 2:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F);
      this.label2.Location = new System.Drawing.Point(61, 90);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(147, 22);
      this.label2.TabIndex = 13;
      this.label2.Text = "Choose the players:";
      // 
      // btnCancel1
      // 
      this.btnCancel1.BackColor = System.Drawing.Color.DarkRed;
      this.btnCancel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnCancel1.Location = new System.Drawing.Point(488, 124);
      this.btnCancel1.Name = "btnCancel1";
      this.btnCancel1.Size = new System.Drawing.Size(25, 25);
      this.btnCancel1.TabIndex = 14;
      this.btnCancel1.Text = "X";
      this.btnCancel1.UseVisualStyleBackColor = false;
      this.btnCancel1.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnCancel2
      // 
      this.btnCancel2.BackColor = System.Drawing.Color.DarkRed;
      this.btnCancel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnCancel2.Location = new System.Drawing.Point(488, 186);
      this.btnCancel2.Name = "btnCancel2";
      this.btnCancel2.Size = new System.Drawing.Size(25, 25);
      this.btnCancel2.TabIndex = 15;
      this.btnCancel2.Text = "X";
      this.btnCancel2.UseVisualStyleBackColor = false;
      this.btnCancel2.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // labError
      // 
      this.labError.AutoSize = true;
      this.labError.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F);
      this.labError.ForeColor = System.Drawing.Color.Red;
      this.labError.Location = new System.Drawing.Point(314, 245);
      this.labError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labError.Name = "labError";
      this.labError.Size = new System.Drawing.Size(192, 22);
      this.labError.TabIndex = 16;
      this.labError.Text = "This player already exists";
      this.labError.Visible = false;
      // 
      // FormMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(580, 436);
      this.Controls.Add(this.labError);
      this.Controls.Add(this.btnCancel2);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txbPlayer2);
      this.Controls.Add(this.labPlayer2);
      this.Controls.Add(this.txbPlayer1);
      this.Controls.Add(this.labPlayer1);
      this.Controls.Add(this.listPlayer);
      this.Controls.Add(this.BtnExit);
      this.Controls.Add(this.BtnManage);
      this.Controls.Add(this.BtnNew);
      this.Controls.Add(this.labTitle);
      this.Controls.Add(this.btnCancel1);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "FormMenu";
      this.Text = "FormMenu";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labTitle;
    private System.Windows.Forms.Button BtnNew;
    private System.Windows.Forms.Button BtnManage;
    private System.Windows.Forms.Button BtnExit;
    private System.Windows.Forms.ListView listPlayer;
    private System.Windows.Forms.Label labPlayer1;
    private System.Windows.Forms.TextBox txbPlayer1;
    private System.Windows.Forms.TextBox txbPlayer2;
    private System.Windows.Forms.Label labPlayer2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnCancel1;
    private System.Windows.Forms.Button btnCancel2;
    private System.Windows.Forms.Label labError;
  }
}