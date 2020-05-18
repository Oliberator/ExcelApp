namespace ExcelApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.openFile = new System.Windows.Forms.Button();
            this.winners = new System.Windows.Forms.Button();
            this.safeFile = new System.Windows.Forms.Button();
            this.randTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGrid
            // 
            this.dtGrid.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtGrid.Location = new System.Drawing.Point(13, 12);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.Size = new System.Drawing.Size(760, 411);
            this.dtGrid.TabIndex = 4;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.randTime);
            this.Controls.Add(this.safeFile);
            this.Controls.Add(this.winners);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.dtGrid);
            this.Name = "Form1";
            this.Text = "ExcelApp";
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button winners;
        private System.Windows.Forms.Button safeFile;
        private System.Windows.Forms.Button randTime;
    }
}

