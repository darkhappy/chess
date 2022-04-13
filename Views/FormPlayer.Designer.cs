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
      this.tbxName = new System.Windows.Forms.TextBox();
      this.labName = new System.Windows.Forms.Label();
      this.labError = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // LabTitle
      // 
      this.LabTitle.AutoSize = true;
      this.LabTitle.Font = new System.Drawing.Font("Matura MT Script Capitals", 24F, System.Drawing.FontStyle.Bold);
      this.LabTitle.Location = new System.Drawing.Point(43, 19);
      this.LabTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.LabTitle.Name = "LabTitle";
      this.LabTitle.Size = new System.Drawing.Size(273, 42);
      this.LabTitle.TabIndex = 0;
      this.LabTitle.Text = "Player list baby ";
      // 
      // btnNew
      // 
      this.btnNew.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold);
      this.btnNew.Location = new System.Drawing.Point(50, 385);
      this.btnNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(199, 39);
      this.btnNew.TabIndex = 2;
      this.btnNew.Text = "New player";
      this.btnNew.UseVisualStyleBackColor = true;
      this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold);
      this.btnDelete.Location = new System.Drawing.Point(50, 455);
      this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(199, 39);
      this.btnDelete.TabIndex = 3;
      this.btnDelete.Text = "Delete selected";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnBack
      // 
      this.btnBack.Font = new System.Drawing.Font("Monotype Corsiva", 16F, System.Drawing.FontStyle.Bold);
      this.btnBack.Location = new System.Drawing.Point(265, 455);
      this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new System.Drawing.Size(199, 39);
      this.btnBack.TabIndex = 4;
      this.btnBack.Text = "Back";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
      // 
      // listPlayer
      // 
      this.listPlayer.HideSelection = false;
      this.listPlayer.Location = new System.Drawing.Point(50, 77);
      this.listPlayer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.listPlayer.Name = "listPlayer";
      this.listPlayer.Size = new System.Drawing.Size(416, 291);
      this.listPlayer.TabIndex = 5;
      this.listPlayer.UseCompatibleStateImageBehavior = false;
      // 
      // tbxName
      // 
      this.tbxName.Location = new System.Drawing.Point(265, 408);
      this.tbxName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.tbxName.Name = "tbxName";
      this.tbxName.Size = new System.Drawing.Size(201, 20);
      this.tbxName.TabIndex = 6;
      // 
      // labName
      // 
      this.labName.AutoSize = true;
      this.labName.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F);
      this.labName.Location = new System.Drawing.Point(261, 385);
      this.labName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labName.Name = "labName";
      this.labName.Size = new System.Drawing.Size(115, 22);
      this.labName.TabIndex = 7;
      this.labName.Text = "Player\'s name:";
      // 
      // labError
      // 
      this.labError.AutoSize = true;
      this.labError.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F);
      this.labError.ForeColor = System.Drawing.Color.Red;
      this.labError.Location = new System.Drawing.Point(267, 426);
      this.labError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labError.Name = "labError";
      this.labError.Size = new System.Drawing.Size(192, 22);
      this.labError.TabIndex = 8;
      this.labError.Text = "This player already exists";
      this.labError.Visible = false;
      // 
      // FormPlayer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(533, 502);
      this.Controls.Add(this.labError);
      this.Controls.Add(this.tbxName);
      this.Controls.Add(this.labName);
      this.Controls.Add(this.listPlayer);
      this.Controls.Add(this.btnBack);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnNew);
      this.Controls.Add(this.LabTitle);
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    private System.Windows.Forms.TextBox tbxName;
    private System.Windows.Forms.Label labName;
    private System.Windows.Forms.Label labError;
  }
}