namespace Oyun_Proje.Desktop
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblStartInfo = new System.Windows.Forms.Label();
            this.lblTopSkors = new System.Windows.Forms.Label();
            this.MenuSittingPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MenuSittingPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(445, 185);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(404, 22);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(543, 133);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(191, 38);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Your Name:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(496, 448);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(296, 39);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F);
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(509, 538);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(272, 25);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Press i for keypad information.";
            // 
            // lblStartInfo
            // 
            this.lblStartInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblStartInfo.AutoSize = true;
            this.lblStartInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.lblStartInfo.ForeColor = System.Drawing.Color.White;
            this.lblStartInfo.Location = new System.Drawing.Point(409, 619);
            this.lblStartInfo.Name = "lblStartInfo";
            this.lblStartInfo.Size = new System.Drawing.Size(485, 20);
            this.lblStartInfo.TabIndex = 4;
            this.lblStartInfo.Text = "Type your name and press enter or the button to start the game.";
            // 
            // lblTopSkors
            // 
            this.lblTopSkors.AutoSize = true;
            this.lblTopSkors.ForeColor = System.Drawing.Color.White;
            this.lblTopSkors.Location = new System.Drawing.Point(22, 16);
            this.lblTopSkors.Name = "lblTopSkors";
            this.lblTopSkors.Size = new System.Drawing.Size(70, 16);
            this.lblTopSkors.TabIndex = 5;
            this.lblTopSkors.Text = "Top Skors";
            // 
            // MenuSittingPicture
            // 
            this.MenuSittingPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MenuSittingPicture.Image = ((System.Drawing.Image)(resources.GetObject("MenuSittingPicture.Image")));
            this.MenuSittingPicture.Location = new System.Drawing.Point(-2, 309);
            this.MenuSittingPicture.Name = "MenuSittingPicture";
            this.MenuSittingPicture.Size = new System.Drawing.Size(364, 345);
            this.MenuSittingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MenuSittingPicture.TabIndex = 6;
            this.MenuSittingPicture.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(952, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 335);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // AnaForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStartInfo);
            this.Controls.Add(this.MenuSittingPicture);
            this.Controls.Add(this.lblTopSkors);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1300, 700);
            this.Name = "AnaForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oyun Menü";
            ((System.ComponentModel.ISupportInitialize)(this.MenuSittingPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblStartInfo;
        private System.Windows.Forms.Label lblTopSkors;
        private System.Windows.Forms.PictureBox MenuSittingPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

