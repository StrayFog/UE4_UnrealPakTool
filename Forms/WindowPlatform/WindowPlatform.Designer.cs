namespace StrayFog_Framework_Pak.Forms.WindowPlatform
{
    partial class WindowPlatform
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbPlatform = new System.Windows.Forms.Label();
            this.lbOldUnrealPakExe = new System.Windows.Forms.Label();
            this.tbOldUnrealPakExe = new System.Windows.Forms.TextBox();
            this.tbOldVersionName = new System.Windows.Forms.TextBox();
            this.lbOldVersionName = new System.Windows.Forms.Label();
            this.tbOldVersionDirectory = new System.Windows.Forms.TextBox();
            this.lbOldVersionDirectory = new System.Windows.Forms.Label();
            this.tbNewVersionDirectory = new System.Windows.Forms.TextBox();
            this.lbNewVersionDirectory = new System.Windows.Forms.Label();
            this.tbNewVersionName = new System.Windows.Forms.TextBox();
            this.lbNewVersionName = new System.Windows.Forms.Label();
            this.btnBuilding = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.pbProgressBar = new System.Windows.Forms.ProgressBar();
            this.lbProgressValue = new System.Windows.Forms.Label();
            this.tbProgressTip = new System.Windows.Forms.Label();
            this.lbEngineDirShow = new System.Windows.Forms.Label();
            this.tbOldProjectDir = new System.Windows.Forms.TextBox();
            this.lbOldProjectDir = new System.Windows.Forms.Label();
            this.lbOldEngineDir = new System.Windows.Forms.Label();
            this.tbNewProjectDir = new System.Windows.Forms.TextBox();
            this.lbNewProjectDir = new System.Windows.Forms.Label();
            this.lbNewEngineDir = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNewUnrealPakExe = new System.Windows.Forms.TextBox();
            this.lbNewUnrealPakExe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(71, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "平台：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPlatform
            // 
            this.lbPlatform.AutoSize = true;
            this.lbPlatform.Location = new System.Drawing.Point(152, 13);
            this.lbPlatform.Name = "lbPlatform";
            this.lbPlatform.Size = new System.Drawing.Size(53, 12);
            this.lbPlatform.TabIndex = 1;
            this.lbPlatform.Text = "Platform";
            // 
            // lbOldUnrealPakExe
            // 
            this.lbOldUnrealPakExe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbOldUnrealPakExe.Location = new System.Drawing.Point(12, 66);
            this.lbOldUnrealPakExe.Name = "lbOldUnrealPakExe";
            this.lbOldUnrealPakExe.Size = new System.Drawing.Size(134, 12);
            this.lbOldUnrealPakExe.TabIndex = 2;
            this.lbOldUnrealPakExe.Text = "旧UnrealPak.exe路径：";
            this.lbOldUnrealPakExe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOldUnrealPakExe
            // 
            this.tbOldUnrealPakExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOldUnrealPakExe.Location = new System.Drawing.Point(154, 63);
            this.tbOldUnrealPakExe.Name = "tbOldUnrealPakExe";
            this.tbOldUnrealPakExe.Size = new System.Drawing.Size(1289, 21);
            this.tbOldUnrealPakExe.TabIndex = 3;
            this.tbOldUnrealPakExe.TextChanged += new System.EventHandler(this.tbOldUnrealPakExe_TextChanged);
            // 
            // tbOldVersionName
            // 
            this.tbOldVersionName.Location = new System.Drawing.Point(154, 139);
            this.tbOldVersionName.Name = "tbOldVersionName";
            this.tbOldVersionName.Size = new System.Drawing.Size(93, 21);
            this.tbOldVersionName.TabIndex = 5;
            // 
            // lbOldVersionName
            // 
            this.lbOldVersionName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbOldVersionName.Location = new System.Drawing.Point(12, 142);
            this.lbOldVersionName.Name = "lbOldVersionName";
            this.lbOldVersionName.Size = new System.Drawing.Size(134, 12);
            this.lbOldVersionName.TabIndex = 4;
            this.lbOldVersionName.Text = "旧版本名称：";
            this.lbOldVersionName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOldVersionDirectory
            // 
            this.tbOldVersionDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOldVersionDirectory.Location = new System.Drawing.Point(343, 139);
            this.tbOldVersionDirectory.Name = "tbOldVersionDirectory";
            this.tbOldVersionDirectory.Size = new System.Drawing.Size(1100, 21);
            this.tbOldVersionDirectory.TabIndex = 7;
            // 
            // lbOldVersionDirectory
            // 
            this.lbOldVersionDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbOldVersionDirectory.Location = new System.Drawing.Point(250, 142);
            this.lbOldVersionDirectory.Name = "lbOldVersionDirectory";
            this.lbOldVersionDirectory.Size = new System.Drawing.Size(87, 12);
            this.lbOldVersionDirectory.TabIndex = 6;
            this.lbOldVersionDirectory.Text = "旧版本目录：";
            this.lbOldVersionDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNewVersionDirectory
            // 
            this.tbNewVersionDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewVersionDirectory.Location = new System.Drawing.Point(343, 303);
            this.tbNewVersionDirectory.Name = "tbNewVersionDirectory";
            this.tbNewVersionDirectory.Size = new System.Drawing.Size(1100, 21);
            this.tbNewVersionDirectory.TabIndex = 11;
            // 
            // lbNewVersionDirectory
            // 
            this.lbNewVersionDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNewVersionDirectory.Location = new System.Drawing.Point(252, 308);
            this.lbNewVersionDirectory.Name = "lbNewVersionDirectory";
            this.lbNewVersionDirectory.Size = new System.Drawing.Size(85, 12);
            this.lbNewVersionDirectory.TabIndex = 10;
            this.lbNewVersionDirectory.Text = "新版本目录：";
            this.lbNewVersionDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNewVersionName
            // 
            this.tbNewVersionName.Location = new System.Drawing.Point(154, 304);
            this.tbNewVersionName.Name = "tbNewVersionName";
            this.tbNewVersionName.Size = new System.Drawing.Size(95, 21);
            this.tbNewVersionName.TabIndex = 9;
            // 
            // lbNewVersionName
            // 
            this.lbNewVersionName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNewVersionName.Location = new System.Drawing.Point(12, 311);
            this.lbNewVersionName.Name = "lbNewVersionName";
            this.lbNewVersionName.Size = new System.Drawing.Size(134, 12);
            this.lbNewVersionName.TabIndex = 8;
            this.lbNewVersionName.Text = "新版本名称：";
            this.lbNewVersionName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuilding
            // 
            this.btnBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuilding.Location = new System.Drawing.Point(14, 337);
            this.btnBuilding.Name = "btnBuilding";
            this.btnBuilding.Size = new System.Drawing.Size(1431, 23);
            this.btnBuilding.TabIndex = 12;
            this.btnBuilding.Text = "生成更新包";
            this.btnBuilding.UseVisualStyleBackColor = true;
            this.btnBuilding.Click += new System.EventHandler(this.btnBuilding_Click);
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(14, 407);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(1431, 277);
            this.tbLog.TabIndex = 13;
            // 
            // pbProgressBar
            // 
            this.pbProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgressBar.Location = new System.Drawing.Point(14, 387);
            this.pbProgressBar.Name = "pbProgressBar";
            this.pbProgressBar.Size = new System.Drawing.Size(1382, 14);
            this.pbProgressBar.TabIndex = 14;
            // 
            // lbProgressValue
            // 
            this.lbProgressValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProgressValue.AutoSize = true;
            this.lbProgressValue.BackColor = System.Drawing.Color.Transparent;
            this.lbProgressValue.ForeColor = System.Drawing.Color.Black;
            this.lbProgressValue.Location = new System.Drawing.Point(1402, 387);
            this.lbProgressValue.Name = "lbProgressValue";
            this.lbProgressValue.Size = new System.Drawing.Size(29, 12);
            this.lbProgressValue.TabIndex = 16;
            this.lbProgressValue.Text = "100%";
            this.lbProgressValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbProgressTip
            // 
            this.tbProgressTip.AutoSize = true;
            this.tbProgressTip.Location = new System.Drawing.Point(14, 363);
            this.tbProgressTip.Name = "tbProgressTip";
            this.tbProgressTip.Size = new System.Drawing.Size(53, 12);
            this.tbProgressTip.TabIndex = 17;
            this.tbProgressTip.Text = "进度提示";
            // 
            // lbEngineDirShow
            // 
            this.lbEngineDirShow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbEngineDirShow.Location = new System.Drawing.Point(12, 38);
            this.lbEngineDirShow.Name = "lbEngineDirShow";
            this.lbEngineDirShow.Size = new System.Drawing.Size(134, 12);
            this.lbEngineDirShow.TabIndex = 18;
            this.lbEngineDirShow.Text = "旧引擎目录：";
            this.lbEngineDirShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOldProjectDir
            // 
            this.tbOldProjectDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOldProjectDir.Location = new System.Drawing.Point(154, 104);
            this.tbOldProjectDir.Name = "tbOldProjectDir";
            this.tbOldProjectDir.Size = new System.Drawing.Size(1289, 21);
            this.tbOldProjectDir.TabIndex = 21;
            // 
            // lbOldProjectDir
            // 
            this.lbOldProjectDir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbOldProjectDir.Location = new System.Drawing.Point(12, 107);
            this.lbOldProjectDir.Name = "lbOldProjectDir";
            this.lbOldProjectDir.Size = new System.Drawing.Size(134, 12);
            this.lbOldProjectDir.TabIndex = 20;
            this.lbOldProjectDir.Text = "旧工程目录：";
            this.lbOldProjectDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbOldEngineDir
            // 
            this.lbOldEngineDir.AutoSize = true;
            this.lbOldEngineDir.Location = new System.Drawing.Point(152, 38);
            this.lbOldEngineDir.Name = "lbOldEngineDir";
            this.lbOldEngineDir.Size = new System.Drawing.Size(77, 12);
            this.lbOldEngineDir.TabIndex = 22;
            this.lbOldEngineDir.Text = "显示引擎目录";
            // 
            // tbNewProjectDir
            // 
            this.tbNewProjectDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewProjectDir.Location = new System.Drawing.Point(154, 265);
            this.tbNewProjectDir.Name = "tbNewProjectDir";
            this.tbNewProjectDir.Size = new System.Drawing.Size(1289, 21);
            this.tbNewProjectDir.TabIndex = 24;
            // 
            // lbNewProjectDir
            // 
            this.lbNewProjectDir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNewProjectDir.Location = new System.Drawing.Point(12, 270);
            this.lbNewProjectDir.Name = "lbNewProjectDir";
            this.lbNewProjectDir.Size = new System.Drawing.Size(134, 12);
            this.lbNewProjectDir.TabIndex = 23;
            this.lbNewProjectDir.Text = "新工程目录：";
            this.lbNewProjectDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbNewEngineDir
            // 
            this.lbNewEngineDir.AutoSize = true;
            this.lbNewEngineDir.Location = new System.Drawing.Point(152, 203);
            this.lbNewEngineDir.Name = "lbNewEngineDir";
            this.lbNewEngineDir.Size = new System.Drawing.Size(77, 12);
            this.lbNewEngineDir.TabIndex = 28;
            this.lbNewEngineDir.Text = "显示引擎目录";
            // 
            // label3
            // 
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(12, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "新引擎目录：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNewUnrealPakExe
            // 
            this.tbNewUnrealPakExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewUnrealPakExe.Location = new System.Drawing.Point(154, 228);
            this.tbNewUnrealPakExe.Name = "tbNewUnrealPakExe";
            this.tbNewUnrealPakExe.Size = new System.Drawing.Size(1289, 21);
            this.tbNewUnrealPakExe.TabIndex = 26;
            this.tbNewUnrealPakExe.TextChanged += new System.EventHandler(this.tbNewUnrealPakExe_TextChanged);
            // 
            // lbNewUnrealPakExe
            // 
            this.lbNewUnrealPakExe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbNewUnrealPakExe.Location = new System.Drawing.Point(12, 231);
            this.lbNewUnrealPakExe.Name = "lbNewUnrealPakExe";
            this.lbNewUnrealPakExe.Size = new System.Drawing.Size(134, 12);
            this.lbNewUnrealPakExe.TabIndex = 25;
            this.lbNewUnrealPakExe.Text = "新UnrealPak.exe路径：";
            this.lbNewUnrealPakExe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WindowPlatform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 701);
            this.Controls.Add(this.lbNewEngineDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNewUnrealPakExe);
            this.Controls.Add(this.lbNewUnrealPakExe);
            this.Controls.Add(this.tbNewProjectDir);
            this.Controls.Add(this.lbNewProjectDir);
            this.Controls.Add(this.lbOldEngineDir);
            this.Controls.Add(this.tbOldProjectDir);
            this.Controls.Add(this.lbOldProjectDir);
            this.Controls.Add(this.lbEngineDirShow);
            this.Controls.Add(this.tbProgressTip);
            this.Controls.Add(this.lbProgressValue);
            this.Controls.Add(this.pbProgressBar);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnBuilding);
            this.Controls.Add(this.tbNewVersionDirectory);
            this.Controls.Add(this.lbNewVersionDirectory);
            this.Controls.Add(this.tbNewVersionName);
            this.Controls.Add(this.lbNewVersionName);
            this.Controls.Add(this.tbOldVersionDirectory);
            this.Controls.Add(this.lbOldVersionDirectory);
            this.Controls.Add(this.tbOldVersionName);
            this.Controls.Add(this.lbOldVersionName);
            this.Controls.Add(this.tbOldUnrealPakExe);
            this.Controls.Add(this.lbOldUnrealPakExe);
            this.Controls.Add(this.lbPlatform);
            this.Controls.Add(this.label1);
            this.Name = "WindowPlatform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BasePlatformWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPlatform;
        private System.Windows.Forms.Label lbOldUnrealPakExe;
        private System.Windows.Forms.TextBox tbOldUnrealPakExe;
        private System.Windows.Forms.TextBox tbOldVersionName;
        private System.Windows.Forms.Label lbOldVersionName;
        private System.Windows.Forms.TextBox tbOldVersionDirectory;
        private System.Windows.Forms.Label lbOldVersionDirectory;
        private System.Windows.Forms.TextBox tbNewVersionDirectory;
        private System.Windows.Forms.Label lbNewVersionDirectory;
        private System.Windows.Forms.TextBox tbNewVersionName;
        private System.Windows.Forms.Label lbNewVersionName;
        private System.Windows.Forms.Button btnBuilding;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.ProgressBar pbProgressBar;
        private System.Windows.Forms.Label lbProgressValue;
        private System.Windows.Forms.Label tbProgressTip;
        private System.Windows.Forms.Label lbEngineDirShow;
        private System.Windows.Forms.TextBox tbOldProjectDir;
        private System.Windows.Forms.Label lbOldProjectDir;
        private System.Windows.Forms.Label lbOldEngineDir;
        private System.Windows.Forms.TextBox tbNewProjectDir;
        private System.Windows.Forms.Label lbNewProjectDir;
        private System.Windows.Forms.Label lbNewEngineDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNewUnrealPakExe;
        private System.Windows.Forms.Label lbNewUnrealPakExe;
    }
}