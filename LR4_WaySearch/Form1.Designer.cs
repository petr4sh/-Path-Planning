namespace LR4_WaySearch
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
            this.mapDownload = new System.Windows.Forms.Button();
            this.mapBox = new System.Windows.Forms.PictureBox();
            this.mapSave = new System.Windows.Forms.Button();
            this.startXBox = new System.Windows.Forms.TextBox();
            this.startYBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.finishXBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.finishYBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.setPosBtn = new System.Windows.Forms.Button();
            this.bfs = new System.Windows.Forms.Button();
            this.modeLab = new System.Windows.Forms.CheckBox();
            this.showAllWays = new System.Windows.Forms.CheckBox();
            this.SaveWay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapDownload
            // 
            this.mapDownload.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapDownload.Location = new System.Drawing.Point(12, 12);
            this.mapDownload.Name = "mapDownload";
            this.mapDownload.Size = new System.Drawing.Size(188, 31);
            this.mapDownload.TabIndex = 0;
            this.mapDownload.Text = "Загрузить карту";
            this.mapDownload.UseVisualStyleBackColor = false;
            this.mapDownload.Click += new System.EventHandler(this.mapDownload_Click);
            // 
            // mapBox
            // 
            this.mapBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mapBox.Location = new System.Drawing.Point(207, 12);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(854, 492);
            this.mapBox.TabIndex = 2;
            this.mapBox.TabStop = false;
            this.mapBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapBox_Paint);
            this.mapBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseUp);
            // 
            // mapSave
            // 
            this.mapSave.Enabled = false;
            this.mapSave.Location = new System.Drawing.Point(12, 50);
            this.mapSave.Name = "mapSave";
            this.mapSave.Size = new System.Drawing.Size(188, 33);
            this.mapSave.TabIndex = 3;
            this.mapSave.Text = "Сохранить карту";
            this.mapSave.UseVisualStyleBackColor = true;
            this.mapSave.Click += new System.EventHandler(this.mapSave_Click);
            // 
            // startXBox
            // 
            this.startXBox.Location = new System.Drawing.Point(33, 30);
            this.startXBox.Name = "startXBox";
            this.startXBox.Size = new System.Drawing.Size(42, 22);
            this.startXBox.TabIndex = 4;
            // 
            // startYBox
            // 
            this.startYBox.Location = new System.Drawing.Point(33, 59);
            this.startYBox.Name = "startYBox";
            this.startYBox.Size = new System.Drawing.Size(42, 22);
            this.startYBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startXBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.startYBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "START";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.finishXBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.finishYBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(111, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FINISH";
            // 
            // finishXBox
            // 
            this.finishXBox.Location = new System.Drawing.Point(33, 30);
            this.finishXBox.Name = "finishXBox";
            this.finishXBox.Size = new System.Drawing.Size(41, 22);
            this.finishXBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y";
            // 
            // finishYBox
            // 
            this.finishYBox.Location = new System.Drawing.Point(33, 59);
            this.finishYBox.Name = "finishYBox";
            this.finishYBox.Size = new System.Drawing.Size(41, 22);
            this.finishYBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "X";
            // 
            // setPosBtn
            // 
            this.setPosBtn.Location = new System.Drawing.Point(12, 233);
            this.setPosBtn.Name = "setPosBtn";
            this.setPosBtn.Size = new System.Drawing.Size(188, 34);
            this.setPosBtn.TabIndex = 10;
            this.setPosBtn.Text = "Поменять позиции";
            this.setPosBtn.UseVisualStyleBackColor = true;
            this.setPosBtn.Click += new System.EventHandler(this.setPosBtn_Click);
            // 
            // bfs
            // 
            this.bfs.Location = new System.Drawing.Point(12, 273);
            this.bfs.Name = "bfs";
            this.bfs.Size = new System.Drawing.Size(188, 32);
            this.bfs.TabIndex = 11;
            this.bfs.Text = "Поиск пути";
            this.bfs.UseVisualStyleBackColor = true;
            this.bfs.Click += new System.EventHandler(this.bfs_Click);
            // 
            // modeLab
            // 
            this.modeLab.AutoSize = true;
            this.modeLab.Location = new System.Drawing.Point(14, 89);
            this.modeLab.Name = "modeLab";
            this.modeLab.Size = new System.Drawing.Size(166, 20);
            this.modeLab.TabIndex = 12;
            this.modeLab.Text = "Редактор лабиринта";
            this.modeLab.UseVisualStyleBackColor = true;
            this.modeLab.CheckedChanged += new System.EventHandler(this.modeLab_CheckedChanged);
            // 
            // showAllWays
            // 
            this.showAllWays.AutoSize = true;
            this.showAllWays.Location = new System.Drawing.Point(12, 311);
            this.showAllWays.Name = "showAllWays";
            this.showAllWays.Size = new System.Drawing.Size(152, 20);
            this.showAllWays.TabIndex = 13;
            this.showAllWays.Text = "Показать все пути";
            this.showAllWays.UseVisualStyleBackColor = true;
            this.showAllWays.CheckedChanged += new System.EventHandler(this.showAllWays_CheckedChanged);
            // 
            // SaveWay
            // 
            this.SaveWay.Location = new System.Drawing.Point(12, 356);
            this.SaveWay.Name = "SaveWay";
            this.SaveWay.Size = new System.Drawing.Size(188, 36);
            this.SaveWay.TabIndex = 14;
            this.SaveWay.Text = "Сохранить маршрут";
            this.SaveWay.UseVisualStyleBackColor = true;
            this.SaveWay.Click += new System.EventHandler(this.SaveWay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 523);
            this.Controls.Add(this.SaveWay);
            this.Controls.Add(this.showAllWays);
            this.Controls.Add(this.modeLab);
            this.Controls.Add(this.bfs);
            this.Controls.Add(this.setPosBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mapSave);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.mapDownload);
            this.Name = "Form1";
            this.Text = "FedotovaTA221-327";
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mapDownload;
        private System.Windows.Forms.PictureBox mapBox;
        private System.Windows.Forms.Button mapSave;
        private System.Windows.Forms.TextBox startXBox;
        private System.Windows.Forms.TextBox startYBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox finishXBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox finishYBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button setPosBtn;
        private System.Windows.Forms.Button bfs;
        private System.Windows.Forms.CheckBox modeLab;
        private System.Windows.Forms.CheckBox showAllWays;
        private System.Windows.Forms.Button SaveWay;
    }
}

