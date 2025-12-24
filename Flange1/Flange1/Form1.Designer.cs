using System.Drawing;

namespace Flange1
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textBoxA = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBoxB = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBoxN = new TextBox();
            label8 = new Label();
            textBoxC = new TextBox();
            label9 = new Label();
            textBoxE = new TextBox();
            label10 = new Label();
            label11 = new Label();
            Build = new Button();
            label12 = new Label();
            toolTip1 = new ToolTip(components);
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            groupBox1 = new GroupBox();
            textBoxD = new TextBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 36);
            label1.Name = "label1";
            label1.Size = new Size(177, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите наружный диаметр(a):";
            // 
            // textBoxA
            // 
            textBoxA.Location = new Point(194, 33);
            textBoxA.Margin = new Padding(3, 2, 3, 2);
            textBoxA.Name = "textBoxA";
            textBoxA.Size = new Size(84, 23);
            textBoxA.TabIndex = 1;
            textBoxA.Text = "200";
            textBoxA.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(283, 36);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 2;
            label2.Text = "мм.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 61);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 3;
            label3.Text = "Диаметр выступа(b):";
            label3.Click += label3_Click;
            // 
            // textBoxB
            // 
            textBoxB.BackColor = Color.LightGray;
            textBoxB.Location = new Point(194, 55);
            textBoxB.Margin = new Padding(3, 2, 3, 2);
            textBoxB.Name = "textBoxB";
            textBoxB.Size = new Size(84, 23);
            textBoxB.TabIndex = 4;
            textBoxB.Text = "150";
            textBoxB.TextChanged += textBoxB_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(283, 61);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 5;
            label4.Text = "мм.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(122, 86);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 6;
            label5.Text = "Высота(d):";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(283, 86);
            label6.Name = "label6";
            label6.Size = new Size(28, 15);
            label6.TabIndex = 8;
            label6.Text = "мм.";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(38, 111);
            label7.Name = "label7";
            label7.Size = new Size(149, 15);
            label7.TabIndex = 9;
            label7.Text = "Количество отверстий(n):";
            // 
            // textBoxN
            // 
            textBoxN.Location = new Point(194, 105);
            textBoxN.Margin = new Padding(3, 2, 3, 2);
            textBoxN.Name = "textBoxN";
            textBoxN.Size = new Size(84, 23);
            textBoxN.TabIndex = 10;
            textBoxN.Text = "4";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(111, 139);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 11;
            label8.Text = "Толщина(c):";
            // 
            // textBoxC
            // 
            textBoxC.Location = new Point(194, 131);
            textBoxC.Margin = new Padding(3, 2, 3, 2);
            textBoxC.Name = "textBoxC";
            textBoxC.Size = new Size(84, 23);
            textBoxC.TabIndex = 12;
            textBoxC.Text = "50";
            textBoxC.TextChanged += textBox_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(283, 134);
            label9.Name = "label9";
            label9.Size = new Size(28, 15);
            label9.TabIndex = 13;
            label9.Text = "мм.";
            // 
            // textBoxE
            // 
            textBoxE.Location = new Point(194, 158);
            textBoxE.Margin = new Padding(3, 2, 3, 2);
            textBoxE.Name = "textBoxE";
            textBoxE.Size = new Size(84, 23);
            textBoxE.TabIndex = 14;
            textBoxE.Text = "15";
            textBoxE.TextChanged += textBox6_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(57, 166);
            label10.Name = "label10";
            label10.Size = new Size(131, 15);
            label10.TabIndex = 15;
            label10.Text = "Диаметр отверстий(e):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(284, 170);
            label11.Name = "label11";
            label11.Size = new Size(28, 15);
            label11.TabIndex = 16;
            label11.Text = "мм.";
            // 
            // Build
            // 
            Build.Location = new Point(164, 207);
            Build.Margin = new Padding(3, 2, 3, 2);
            Build.Name = "Build";
            Build.Size = new Size(154, 31);
            Build.TabIndex = 17;
            Build.Text = "Собрать";
            Build.UseVisualStyleBackColor = true;
            Build.Click += button1_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 36);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(67, 15);
            label12.TabIndex = 18;
            label12.Text = "От 2 до 400";
            label12.Click += label12_Click;
            // 
            // toolTip1
            // 
            toolTip1.Popup += toolTip1_Popup;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 111);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(55, 15);
            label13.TabIndex = 19;
            label13.Text = "От 1 до 8";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 61);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(74, 15);
            label14.TabIndex = 20;
            label14.Text = "b <= 0.75 * a";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 86);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(67, 15);
            label15.TabIndex = 21;
            label15.Text = "От 2 до 300";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 137);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(33, 15);
            label16.TabIndex = 22;
            label16.Text = "c < а";
            label16.Click += label16_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 162);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(102, 15);
            label17.TabIndex = 23;
            label17.Text = "0 <d <c и 0 <d <a";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxD);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxA);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxB);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBoxE);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(textBoxN);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBoxC);
            groupBox1.Location = new Point(10, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(316, 191);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ввод Размеров";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBoxD
            // 
            textBoxD.Location = new Point(194, 80);
            textBoxD.Name = "textBoxD";
            textBoxD.Size = new Size(84, 23);
            textBoxD.TabIndex = 17;
            textBoxD.Text = "50";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label13);
            groupBox2.Location = new Point(332, 11);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(157, 191);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Допустимые размеры";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 254);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Build);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Плагин создания закрытых фланцев";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxE;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private TextBox textBoxD;
    }
}
