namespace LR5_poly_mov
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
            this.showGoodEdges = new System.Windows.Forms.CheckBox();
            this.bfs = new System.Windows.Forms.Button();
            this.setPosBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.finishXBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.finishYBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startXBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startYBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mapBox = new System.Windows.Forms.PictureBox();
            this.mapDownload = new System.Windows.Forms.Button();
            this.mapListBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.finishBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.showAllEdges = new System.Windows.Forms.CheckBox();
            this.showPerfectEdges = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maxD = new System.Windows.Forms.NumericUpDown();
            this.wayCheck = new System.Windows.Forms.CheckBox();
            this.orangeBox = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxD)).BeginInit();
            this.SuspendLayout();
            // 
            // showGoodEdges
            // 
            this.showGoodEdges.AutoSize = true;
            this.showGoodEdges.Location = new System.Drawing.Point(12, 374);
            this.showGoodEdges.Name = "showGoodEdges";
            this.showGoodEdges.Size = new System.Drawing.Size(194, 36);
            this.showGoodEdges.TabIndex = 22;
            this.showGoodEdges.Text = "Показать допустимые по\r\nдлине пути";
            this.showGoodEdges.UseVisualStyleBackColor = true;
            this.showGoodEdges.CheckedChanged += new System.EventHandler(this.showGoodEdges_CheckedChanged);
            // 
            // bfs
            // 
            this.bfs.Location = new System.Drawing.Point(12, 288);
            this.bfs.Name = "bfs";
            this.bfs.Size = new System.Drawing.Size(143, 32);
            this.bfs.TabIndex = 21;
            this.bfs.Text = "Поиск пути";
            this.bfs.UseVisualStyleBackColor = true;
            this.bfs.Click += new System.EventHandler(this.bfs_Click);
            // 
            // setPosBtn
            // 
            this.setPosBtn.Location = new System.Drawing.Point(7, 112);
            this.setPosBtn.Name = "setPosBtn";
            this.setPosBtn.Size = new System.Drawing.Size(188, 34);
            this.setPosBtn.TabIndex = 20;
            this.setPosBtn.Text = "Поменять позиции";
            this.setPosBtn.UseVisualStyleBackColor = true;
            this.setPosBtn.Click += new System.EventHandler(this.setPosBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.finishXBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.finishYBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(104, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 100);
            this.groupBox2.TabIndex = 19;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startXBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.startYBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "START";
            // 
            // startXBox
            // 
            this.startXBox.Location = new System.Drawing.Point(33, 30);
            this.startXBox.Name = "startXBox";
            this.startXBox.Size = new System.Drawing.Size(42, 22);
            this.startXBox.TabIndex = 4;
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
            // mapBox
            // 
            this.mapBox.BackColor = System.Drawing.SystemColors.Window;
            this.mapBox.Location = new System.Drawing.Point(227, 12);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(854, 492);
            this.mapBox.TabIndex = 16;
            this.mapBox.TabStop = false;
            this.mapBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseUp);
            // 
            // mapDownload
            // 
            this.mapDownload.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapDownload.Location = new System.Drawing.Point(12, 12);
            this.mapDownload.Name = "mapDownload";
            this.mapDownload.Size = new System.Drawing.Size(188, 31);
            this.mapDownload.TabIndex = 15;
            this.mapDownload.Text = "Загрузить карту";
            this.mapDownload.UseVisualStyleBackColor = false;
            this.mapDownload.Click += new System.EventHandler(this.mapDownload_Click);
            // 
            // mapListBox
            // 
            this.mapListBox.FormattingEnabled = true;
            this.mapListBox.ItemHeight = 16;
            this.mapListBox.Location = new System.Drawing.Point(12, 49);
            this.mapListBox.Name = "mapListBox";
            this.mapListBox.Size = new System.Drawing.Size(188, 52);
            this.mapListBox.TabIndex = 24;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(209, 179);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.setPosBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(201, 150);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Координаты";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.finishBtn);
            this.tabPage2.Controls.Add(this.startBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(201, 150);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Кликом";
            // 
            // finishBtn
            // 
            this.finishBtn.Location = new System.Drawing.Point(6, 75);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(189, 37);
            this.finishBtn.TabIndex = 1;
            this.finishBtn.Text = "Установить финиш";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(6, 31);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(189, 38);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Установить старт";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // showAllEdges
            // 
            this.showAllEdges.AutoSize = true;
            this.showAllEdges.Location = new System.Drawing.Point(12, 349);
            this.showAllEdges.Name = "showAllEdges";
            this.showAllEdges.Size = new System.Drawing.Size(161, 20);
            this.showAllEdges.TabIndex = 27;
            this.showAllEdges.Text = "Показать все ребра";
            this.showAllEdges.UseVisualStyleBackColor = true;
            this.showAllEdges.CheckedChanged += new System.EventHandler(this.showAllEdges_CheckedChanged);
            // 
            // showPerfectEdges
            // 
            this.showPerfectEdges.AutoSize = true;
            this.showPerfectEdges.Location = new System.Drawing.Point(12, 416);
            this.showPerfectEdges.Name = "showPerfectEdges";
            this.showPerfectEdges.Size = new System.Drawing.Size(200, 20);
            this.showPerfectEdges.TabIndex = 28;
            this.showPerfectEdges.Text = "Показать доступные пути";
            this.showPerfectEdges.UseVisualStyleBackColor = true;
            this.showPerfectEdges.CheckedChanged += new System.EventHandler(this.showPerfectEdges_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Дистанция";
            // 
            // maxD
            // 
            this.maxD.Location = new System.Drawing.Point(92, 321);
            this.maxD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxD.Name = "maxD";
            this.maxD.Size = new System.Drawing.Size(63, 22);
            this.maxD.TabIndex = 31;
            // 
            // wayCheck
            // 
            this.wayCheck.AutoSize = true;
            this.wayCheck.Location = new System.Drawing.Point(12, 446);
            this.wayCheck.Name = "wayCheck";
            this.wayCheck.Size = new System.Drawing.Size(152, 20);
            this.wayCheck.TabIndex = 32;
            this.wayCheck.Text = "Показать маршрут";
            this.wayCheck.UseVisualStyleBackColor = true;
            this.wayCheck.CheckedChanged += new System.EventHandler(this.wayCheck_CheckedChanged);
            // 
            // orangeBox
            // 
            this.orangeBox.AutoSize = true;
            this.orangeBox.Location = new System.Drawing.Point(12, 473);
            this.orangeBox.Name = "orangeBox";
            this.orangeBox.Size = new System.Drawing.Size(176, 36);
            this.orangeBox.TabIndex = 33;
            this.orangeBox.Text = "Закрасить оранжевым\r\nполигоны";
            this.orangeBox.UseVisualStyleBackColor = true;
            this.orangeBox.CheckedChanged += new System.EventHandler(this.orangeBox_CheckedChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(161, 288);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(60, 55);
            this.SaveBtn.TabIndex = 34;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 519);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.orangeBox);
            this.Controls.Add(this.wayCheck);
            this.Controls.Add(this.maxD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.showPerfectEdges);
            this.Controls.Add(this.showAllEdges);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.mapListBox);
            this.Controls.Add(this.showGoodEdges);
            this.Controls.Add(this.bfs);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.mapDownload);
            this.Name = "Form1";
            this.Text = "FedotovaTA221-327";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maxD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox showGoodEdges;
        private System.Windows.Forms.Button bfs;
        private System.Windows.Forms.Button setPosBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox finishXBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox finishYBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox startXBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startYBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox mapBox;
        private System.Windows.Forms.Button mapDownload;
        private System.Windows.Forms.ListBox mapListBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.CheckBox showAllEdges;
        private System.Windows.Forms.CheckBox showPerfectEdges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown maxD;
        private System.Windows.Forms.CheckBox wayCheck;
        private System.Windows.Forms.CheckBox orangeBox;
        private System.Windows.Forms.Button SaveBtn;
    }
}

