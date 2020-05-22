namespace ExcelApp
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.openFile = new System.Windows.Forms.Button();
            this.winners = new System.Windows.Forms.Button();
            this.safeFile = new System.Windows.Forms.Button();
            this.randTime = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGrid
            // 
            this.dtGrid.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtGrid.Location = new System.Drawing.Point(0, 27);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.Size = new System.Drawing.Size(784, 396);
            this.dtGrid.TabIndex = 4;
            this.dtGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtGrid_DataError);
            // 
            // openFile
            // 
            this.openFile.BackgroundImage = global::ExcelApp.Properties.Resources.openFile;
            this.openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openFile.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFile.Location = new System.Drawing.Point(13, 429);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(380, 60);
            this.openFile.TabIndex = 5;
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // winners
            // 
            this.winners.BackgroundImage = global::ExcelApp.Properties.Resources.winners;
            this.winners.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.winners.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.winners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winners.Location = new System.Drawing.Point(393, 489);
            this.winners.Name = "winners";
            this.winners.Size = new System.Drawing.Size(380, 60);
            this.winners.TabIndex = 6;
            this.winners.UseVisualStyleBackColor = true;
            this.winners.Click += new System.EventHandler(this.winners_Click);
            // 
            // safeFile
            // 
            this.safeFile.BackgroundImage = global::ExcelApp.Properties.Resources.safeFile;
            this.safeFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.safeFile.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.safeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.safeFile.Location = new System.Drawing.Point(13, 489);
            this.safeFile.Name = "safeFile";
            this.safeFile.Size = new System.Drawing.Size(380, 60);
            this.safeFile.TabIndex = 7;
            this.safeFile.UseVisualStyleBackColor = true;
            this.safeFile.Click += new System.EventHandler(this.safeFile_Click);
            // 
            // randTime
            // 
            this.randTime.BackgroundImage = global::ExcelApp.Properties.Resources.rand;
            this.randTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.randTime.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.randTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.randTime.Location = new System.Drawing.Point(393, 429);
            this.randTime.Name = "randTime";
            this.randTime.Size = new System.Drawing.Size(380, 60);
            this.randTime.TabIndex = 8;
            this.randTime.UseVisualStyleBackColor = true;
            this.randTime.Click += new System.EventHandler(this.randTime_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // txtRes
            // 
            this.txtRes.Location = new System.Drawing.Point(143, 2);
            this.txtRes.Name = "txtRes";
            this.txtRes.Size = new System.Drawing.Size(100, 20);
            this.txtRes.TabIndex = 10;
            this.txtRes.TextChanged += new System.EventHandler(this.txtRes_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Введи балл для победы:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRes);
            this.Controls.Add(this.randTime);
            this.Controls.Add(this.safeFile);
            this.Controls.Add(this.winners);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.dtGrid);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExcelApp";
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button winners;
        private System.Windows.Forms.Button safeFile;
        private System.Windows.Forms.Button randTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox txtRes;
        private System.Windows.Forms.Label label1;
    }
}

