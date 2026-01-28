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
            label1.Location = new Point(11, 36);
            label1.Name = "label1";
            label1.Size = new Size(177, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите наружный диаметр(a):";
            // 
            // OuterDiameter
            // 
            OuterDiameter.Location = new Point(194, 28);
            OuterDiameter.Margin = new Padding(3, 2, 3, 2);
            OuterDiameter.Name = "OuterDiameter";
            OuterDiameter.Size = new Size(84, 23);
            OuterDiameter.TabIndex = 1;
            OuterDiameter.Text = "200";
            OuterDiameter.TextChanged += OuterDiameter_TextChanged;
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
            label3.Location = new Point(67, 61);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 3;
            label3.Text = "Диаметр выступа(b):";
            // 
            // ProtrusionDiameter
            // 
            ProtrusionDiameter.BackColor = Color.White;
            ProtrusionDiameter.Location = new Point(194, 53);
            ProtrusionDiameter.Margin = new Padding(3, 2, 3, 2);
            ProtrusionDiameter.Name = "ProtrusionDiameter";
            ProtrusionDiameter.Size = new Size(84, 23);
            ProtrusionDiameter.TabIndex = 4;
            ProtrusionDiameter.Text = "150";
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
            label5.Location = new Point(123, 83);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 6;
            label5.Text = "Высота(d):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(283, 86);
            label6.Name = "label6";
            label6.Size = new Size(28, 15);
            label6.TabIndex = 8;
            label6.Text = "мм.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 108);
            label7.Name = "label7";
            label7.Size = new Size(149, 15);
            label7.TabIndex = 9;
            label7.Text = "Количество отверстий(n):";
            // 
            // HolesAmount
            // 
            HolesAmount.Location = new Point(194, 104);
            HolesAmount.Margin = new Padding(3, 2, 3, 2);
            HolesAmount.Name = "HolesAmount";
            HolesAmount.Size = new Size(84, 23);
            HolesAmount.TabIndex = 10;
            HolesAmount.Text = "4";
            HolesAmount.TextChanged += HolesAmount_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(112, 134);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 11;
            label8.Text = "Толщина(c):";
            // 
            // Thickness
            // 
            Thickness.Location = new Point(194, 131);
            Thickness.Margin = new Padding(3, 2, 3, 2);
            Thickness.Name = "Thickness";
            Thickness.Size = new Size(84, 23);
            Thickness.TabIndex = 12;
            Thickness.Text = "50";
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
            // DiameterHoles
            // 
            DiameterHoles.Location = new Point(194, 158);
            DiameterHoles.Margin = new Padding(3, 2, 3, 2);
            DiameterHoles.Name = "DiameterHoles";
            DiameterHoles.Size = new Size(84, 23);
            DiameterHoles.TabIndex = 14;
            DiameterHoles.Text = "15";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(57, 161);
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
            Build.Location = new Point(178, 242);
            Build.Margin = new Padding(3, 2, 3, 2);
            Build.Name = "Build";
            Build.Size = new Size(154, 31);
            Build.TabIndex = 17;
            Build.Text = "Собрать";
            Build.UseVisualStyleBackColor = true;
            Build.Click += Build_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 41);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(67, 15);
            label12.TabIndex = 18;
            label12.Text = "От 2 до 400";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 113);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(55, 15);
            label13.TabIndex = 19;
            label13.Text = "От 1 до 8";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 63);
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
            label16.Location = new Point(7, 139);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(33, 15);
            label16.TabIndex = 22;
            label16.Text = "c < а";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(7, 166);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(99, 15);
            label17.TabIndex = 23;
            label17.Text = "0 < е < (a-b)*0,45";
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
            groupBox1.Location = new Point(10, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(322, 226);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ввод Размеров";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(281, 195);
            label20.Name = "label20";
            label20.Size = new Size(34, 15);
            label20.TabIndex = 20;
            label20.Text = "град.";
            // 
            // Step
            // 
            Step.Location = new Point(194, 186);
            Step.Name = "Step";
            Step.Size = new Size(84, 23);
            Step.TabIndex = 19;
            Step.Text = "90";
            Step.TextChanged += Step_TextChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(97, 190);
            label18.Name = "label18";
            label18.Size = new Size(91, 15);
            label18.TabIndex = 18;
            label18.Text = "Шаг отверстий:";
            // 
            // Height
            // 
            Height.Location = new Point(194, 78);
            Height.Name = "Height";
            Height.Size = new Size(84, 23);
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
            groupBox2.Location = new Point(338, 11);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(151, 226);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Допустимые размеры";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(7, 195);
            label19.Name = "label19";
            label19.Size = new Size(71, 15);
            label19.TabIndex = 24;
            label19.Text = "0 <= 360 / n";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 288);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Build);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(533, 327);
            MinimumSize = new Size(533, 327);
            Name = "MainForm";
            Text = "Плагин создания закрытых фланцев";
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
