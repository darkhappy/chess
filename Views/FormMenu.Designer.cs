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
      this.SuspendLayout();
      // 
      // labTitle
      // 
      this.labTitle.AutoSize = true;
      this.labTitle.Font = new System.Drawing.Font("Matura MT Script Capitals", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labTitle.Location = new System.Drawing.Point(66, 27);
      this.labTitle.Name = "labTitle";
      this.labTitle.Size = new System.Drawing.Size(729, 64);
      this.labTitle.TabIndex = 0;
      this.labTitle.Text = "Welcom to chess big chad boy !";
      // 
      // BtnNew
      // 
      this.BtnNew.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnNew.Location = new System.Drawing.Point(184, 151);
      this.BtnNew.Name = "BtnNew";
      this.BtnNew.Size = new System.Drawing.Size(490, 89);
      this.BtnNew.TabIndex = 1;
      this.BtnNew.Text = "Wanna play some fun game ^^";
      this.BtnNew.UseVisualStyleBackColor = true;
      // 
      // BtnManage
      // 
      this.BtnManage.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnManage.Location = new System.Drawing.Point(184, 292);
      this.BtnManage.Name = "BtnManage";
      this.BtnManage.Size = new System.Drawing.Size(490, 89);
      this.BtnManage.TabIndex = 2;
      this.BtnManage.Text = "Not enough player? Click here !";
      this.BtnManage.UseVisualStyleBackColor = true;
      // 
      // BtnExit
      // 
      this.BtnExit.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BtnExit.Location = new System.Drawing.Point(184, 432);
      this.BtnExit.Name = "BtnExit";
      this.BtnExit.Size = new System.Drawing.Size(490, 89);
      this.BtnExit.TabIndex = 3;
      this.BtnExit.Text = "Sooo boring. Hasta la vista boy";
      this.BtnExit.UseVisualStyleBackColor = true;
      this.BtnExit.Click += new System.EventHandler(this.Exit);
      // 
      // FormMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(870, 671);
      this.Controls.Add(this.BtnExit);
      this.Controls.Add(this.BtnManage);
      this.Controls.Add(this.BtnNew);
      this.Controls.Add(this.labTitle);
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
  }
}