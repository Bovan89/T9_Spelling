namespace T9_Spelling
{
    partial class T9SpellingForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.bStartProcess = new System.Windows.Forms.Button();
            this.bOpenFile = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.bSaveFile = new System.Windows.Forms.Button();
            this.tbFilePath2 = new System.Windows.Forms.TextBox();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // bStartProcess
            // 
            this.bStartProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bStartProcess.Location = new System.Drawing.Point(295, 307);
            this.bStartProcess.Name = "bStartProcess";
            this.bStartProcess.Size = new System.Drawing.Size(129, 26);
            this.bStartProcess.TabIndex = 0;
            this.bStartProcess.Text = "Начать обработку";
            this.bStartProcess.UseVisualStyleBackColor = true;
            this.bStartProcess.Click += new System.EventHandler(this.bStartProcess_Click);
            // 
            // bOpenFile
            // 
            this.bOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenFile.Location = new System.Drawing.Point(429, 12);
            this.bOpenFile.Name = "bOpenFile";
            this.bOpenFile.Size = new System.Drawing.Size(130, 26);
            this.bOpenFile.TabIndex = 1;
            this.bOpenFile.Text = "Открыть файл";
            this.bOpenFile.UseVisualStyleBackColor = true;
            this.bOpenFile.Click += new System.EventHandler(this.bOpenFile_Click);
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.Location = new System.Drawing.Point(430, 307);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(129, 26);
            this.bExit.TabIndex = 0;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFilePath.Location = new System.Drawing.Point(12, 12);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(411, 26);
            this.tbFilePath.TabIndex = 2;
            this.tbFilePath.Text = "E:\\Хрома\\C-small-practice.in";
            // 
            // bSaveFile
            // 
            this.bSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSaveFile.Location = new System.Drawing.Point(429, 44);
            this.bSaveFile.Name = "bSaveFile";
            this.bSaveFile.Size = new System.Drawing.Size(130, 26);
            this.bSaveFile.TabIndex = 1;
            this.bSaveFile.Text = "Сохранить в файл";
            this.bSaveFile.UseVisualStyleBackColor = true;
            this.bSaveFile.Click += new System.EventHandler(this.bSaveFile_Click);
            // 
            // tbFilePath2
            // 
            this.tbFilePath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilePath2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbFilePath2.Location = new System.Drawing.Point(12, 44);
            this.tbFilePath2.Name = "tbFilePath2";
            this.tbFilePath2.ReadOnly = true;
            this.tbFilePath2.Size = new System.Drawing.Size(411, 26);
            this.tbFilePath2.TabIndex = 2;
            this.tbFilePath2.Text = "E:\\Хрома\\C-small-practice.out";
            // 
            // T9SpellingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 345);
            this.Controls.Add(this.tbFilePath2);
            this.Controls.Add(this.bSaveFile);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.bOpenFile);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bStartProcess);
            this.Name = "T9SpellingForm";
            this.Text = "T9 Spelling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button bStartProcess;
        private System.Windows.Forms.Button bOpenFile;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button bSaveFile;
        private System.Windows.Forms.TextBox tbFilePath2;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}

