using System.Drawing;

namespace Flange1
{
    partial class MainForm
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
            OuterDiameter = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ProtrusionDiameter = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            HolesAmount = new TextBox();
            label8 = new Label();
            Thickness = new TextBox();
            label9 = new Label();
            DiameterHoles = new TextBox();
            label10 = new Label();
            label11 = new Label();
            Build = new Button();
            label12 = new Label();
            toolTip = new ToolTip(components);
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            groupBox1 = new GroupBox();
            label20 = new Label();
            Step = new TextBox();
            label18 = new Label();
            Height = new TextBox();
            groupBox2 = new GroupBox();
            label19 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 48);
            label1.Name = "label1";
            label1.Size = new Size(226, 20);
            label1.TabIndex = 0;
            label1.Text = "Введите наружный диаметр(a):";
            // 
            // OuterDiameter
            // 
            OuterDiameter.Location = new Point(222, 37);
            OuterDiameter.Name = "OuterDiameter";
            OuterDiameter.Size = new Size(95, 27);
            OuterDiameter.TabIndex = 1;
            OuterDiameter.Text = "200";
            OuterDiameter.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(323, 48);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 2;
            label2.Text = "мм.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(77, 81);
            label3.Name = "label3";
            label3.Size = new Size(152, 20);
            label3.TabIndex = 3;
            label3.Text = "Диаметр выступа(b):";
            label3.Click += label3_Click;
            // 
            // ProtrusionDiameter
            // 
            ProtrusionDiameter.BackColor = Color.White;
            ProtrusionDiameter.Location = new Point(222, 71);
            ProtrusionDiameter.Name = "ProtrusionDiameter";
            ProtrusionDiameter.Size = new Size(95, 27);
            ProtrusionDiameter.TabIndex = 4;
            ProtrusionDiameter.Text = "150";
            ProtrusionDiameter.TextChanged += textBoxB_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(323, 81);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 5;
            label4.Text = "мм.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(141, 111);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 6;
            label5.Text = "Высота(d):";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(323, 115);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 8;
            label6.Text = "мм.";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 144);
            label7.Name = "label7";
            label7.Size = new Size(186, 20);
            label7.TabIndex = 9;
            label7.Text = "Количество отверстий(n):";
            // 
            // HolesAmount
            // 
            HolesAmount.Location = new Point(222, 139);
            HolesAmount.Name = "HolesAmount";
            HolesAmount.Size = new Size(95, 27);
            HolesAmount.TabIndex = 10;
            HolesAmount.Text = "4";
            HolesAmount.TextChanged += HolesAmount_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(128, 179);
            label8.Name = "label8";
            label8.Size = new Size(92, 20);
            label8.TabIndex = 11;
            label8.Text = "Толщина(c):";
            // 
            // Thickness
            // 
            Thickness.Location = new Point(222, 175);
            Thickness.Name = "Thickness";
            Thickness.Size = new Size(95, 27);
            Thickness.TabIndex = 12;
            Thickness.Text = "50";
            Thickness.TextChanged += textBox_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(323, 179);
            label9.Name = "label9";
            label9.Size = new Size(34, 20);
            label9.TabIndex = 13;
            label9.Text = "мм.";
            // 
            // DiameterHoles
            // 
            DiameterHoles.Location = new Point(222, 211);
            DiameterHoles.Name = "DiameterHoles";
            DiameterHoles.Size = new Size(95, 27);
            DiameterHoles.TabIndex = 14;
            DiameterHoles.Text = "15";
            DiameterHoles.TextChanged += textBox6_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(65, 215);
            label10.Name = "label10";
            label10.Size = new Size(166, 20);
            label10.TabIndex = 15;
            label10.Text = "Диаметр отверстий(e):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(325, 227);
            label11.Name = "label11";
            label11.Size = new Size(34, 20);
            label11.TabIndex = 16;
            label11.Text = "мм.";
            // 
            // Build
            // 
            Build.Location = new Point(203, 323);
            Build.Name = "Build";
            Build.Size = new Size(176, 41);
            Build.TabIndex = 17;
            Build.Text = "Собрать";
            Build.UseVisualStyleBackColor = true;
            Build.Click += button1_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(8, 55);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(87, 20);
            label12.TabIndex = 18;
            label12.Text = "От 2 до 400";
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 151);
            label13.Margin = new Padding(5, 0, 5, 0);
            label13.Name = "label13";
            label13.Size = new Size(71, 20);
            label13.TabIndex = 19;
            label13.Text = "От 1 до 8";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(8, 84);
            label14.Margin = new Padding(5, 0, 5, 0);
            label14.Name = "label14";
            label14.Size = new Size(95, 20);
            label14.TabIndex = 20;
            label14.Text = "b <= 0.75 * a";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 115);
            label15.Margin = new Padding(5, 0, 5, 0);
            label15.Name = "label15";
            label15.Size = new Size(87, 20);
            label15.TabIndex = 21;
            label15.Text = "От 2 до 300";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(8, 185);
            label16.Margin = new Padding(5, 0, 5, 0);
            label16.Name = "label16";
            label16.Size = new Size(42, 20);
            label16.TabIndex = 22;
            label16.Text = "c < а";
            label16.Click += label16_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(8, 221);
            label17.Margin = new Padding(5, 0, 5, 0);
            label17.Name = "label17";
            label17.Size = new Size(127, 20);
            label17.TabIndex = 23;
            label17.Text = "0 < е < (a-b)*0,45";
            label17.Click += label17_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(Step);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(Height);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(OuterDiameter);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(ProtrusionDiameter);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(DiameterHoles);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(HolesAmount);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(Thickness);
            groupBox1.Location = new Point(11, 15);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(368, 301);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ввод Размеров";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(321, 260);
            label20.Name = "label20";
            label20.Size = new Size(43, 20);
            label20.TabIndex = 20;
            label20.Text = "град.";
            // 
            // Step
            // 
            Step.Location = new Point(222, 248);
            Step.Margin = new Padding(3, 4, 3, 4);
            Step.Name = "Step";
            Step.Size = new Size(95, 27);
            Step.TabIndex = 19;
            Step.Text = "90";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(111, 253);
            label18.Name = "label18";
            label18.Size = new Size(115, 20);
            label18.TabIndex = 18;
            label18.Text = "Шаг отверстий:";
            // 
            // Height
            // 
            Height.Location = new Point(222, 104);
            Height.Margin = new Padding(3, 4, 3, 4);
            Height.Name = "Height";
            Height.Size = new Size(95, 27);
            Height.TabIndex = 17;
            Height.Text = "50";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label13);
            groupBox2.Location = new Point(386, 15);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(173, 301);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Допустимые размеры";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(8, 260);
            label19.Name = "label19";
            label19.Size = new Size(91, 20);
            label19.TabIndex = 24;
            label19.Text = "0 <= 360 / n";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 376);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Build);
            MaximumSize = new Size(607, 423);
            MinimumSize = new Size(607, 423);
            Name = "MainForm";
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
        private System.Windows.Forms.TextBox OuterDiameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProtrusionDiameter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox HolesAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Thickness;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DiameterHoles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private TextBox Height;
        private Label label20;
        private TextBox Step;
        private Label label18;
        private Label label19;
    }
}
