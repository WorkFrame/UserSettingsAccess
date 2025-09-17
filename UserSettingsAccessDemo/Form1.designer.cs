namespace NetEti.DemoApplications
{
  partial class Form1
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
      this.tbxResults = new System.Windows.Forms.TextBox();
      this.btnGo = new System.Windows.Forms.Button();
      this.tbxKey = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // tbxResults
      // 
      this.tbxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxResults.Location = new System.Drawing.Point(27, 58);
      this.tbxResults.Multiline = true;
      this.tbxResults.Name = "tbxResults";
      this.tbxResults.Size = new System.Drawing.Size(231, 108);
      this.tbxResults.TabIndex = 0;
      // 
      // btnGo
      // 
      this.btnGo.Location = new System.Drawing.Point(104, 201);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(75, 23);
      this.btnGo.TabIndex = 1;
      this.btnGo.Text = "go!";
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
      // 
      // tbxKey
      // 
      this.tbxKey.Location = new System.Drawing.Point(82, 20);
      this.tbxKey.Name = "tbxKey";
      this.tbxKey.Size = new System.Drawing.Size(110, 20);
      this.tbxKey.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(24, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Schlüssel";
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 249);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbxKey);
      this.Controls.Add(this.btnGo);
      this.Controls.Add(this.tbxResults);
      this.Name = "FrmMain";
      this.Text = "UserSettingsAccessDemo";
      this.Load += new System.EventHandler(this.FrmMain_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbxResults;
    private System.Windows.Forms.Button btnGo;
    private System.Windows.Forms.TextBox tbxKey;
    private System.Windows.Forms.Label label1;
  }
}

