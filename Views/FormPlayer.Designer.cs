using System.ComponentModel;

namespace chess.Views
{
  partial class FormPlayer
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
      this.LabTitle = new System.Windows.Forms.Label();
      this.btnNew = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnBack = new System.Windows.Forms.Button();
      this.listPlayer = new System.Windows.Forms.ListView();
      this.SuspendLayout();
      // 
      // LabTitle
      // 
      this.LabTitle.AutoSize = true;
      this.LabTitle.Font = new System.Drawing.Font("Matura MT Script Capitals", 24F, System.Drawing.FontStyle.Bold);
      this.LabTitle.Location = new System.Drawing.Point(64, 34);
      this.LabTitle.Name = "LabTitle";
      this.LabTitle.Size = new System.Drawing.Size(404, 64);
      this.LabTitle.TabIndex = 0;
      this.LabTitle.Text = "Player list baby ";
      // 
      // btnNew
      // 
      this.btnNew.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold);
      this.btnNew.Location = new System.Drawing.Point(78, 619);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(299, 60);
      this.btnNew.TabIndex = 2;
      this.btnNew.Text = "New player";
      this.btnNew.UseVisualStyleBackColor = true;
      this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold);
      this.btnDelete.Location = new System.Drawing.Point(398, 619);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(299, 60);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Delete selected";
      this.btnDelete.UseVisualStyleBackColor = true;
      // 
      // btnBack
      // 
      this.btnBack.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold);
      this.btnBack.Location = new System.Drawing.Point(239, 706);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new System.Drawing.Size(299, 60);
      this.btnBack.TabIndex = 4;
      this.btnBack.Text = "Back";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
      // 
      // listPlayer
      // 
      this.listPlayer.HideSelection = false;
      this.listPlayer.Location = new System.Drawing.Point(75, 159);
      this.listPlayer.Name = "listPlayer";
      this.listPlayer.Size = new System.Drawing.Size(622, 424);
      this.listPlayer.TabIndex = 5;
      this.listPlayer.UseCompatibleStateImageBehavior = false;
      // 
      // FormPlayer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 772);
      this.Controls.Add(this.listPlayer);
      this.Controls.Add(this.btnBack);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnNew);
      this.Controls.Add(this.LabTitle);
      this.Name = "FormPlayer";
      this.Text = "FormPlayer";
      this.Load += new System.EventHandler(this.FormPlayer_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label LabTitle;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnBack;
    private System.Windows.Forms.ListView listPlayer;
  }
}