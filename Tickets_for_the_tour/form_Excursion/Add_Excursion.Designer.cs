namespace form_Excursion
{
    partial class Add_Excursion
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
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 39);
            textBox1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 101);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(240, 39);
            numericUpDown1.TabIndex = 1;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(12, 164);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(240, 39);
            numericUpDown2.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 227);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 39);
            textBox2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(304, 41);
            label1.Name = "label1";
            label1.Size = new Size(332, 32);
            label1.TabIndex = 4;
            label1.Text = "Введите название экскурсии";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(304, 103);
            label2.Name = "label2";
            label2.Size = new Size(432, 32);
            label2.TabIndex = 5;
            label2.Text = "Стоимость билета на экскурсию (руб)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 166);
            label3.Name = "label3";
            label3.Size = new Size(423, 32);
            label3.TabIndex = 6;
            label3.Text = "Расстояние маршрута экскурсии (км)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(304, 230);
            label4.Name = "label4";
            label4.Size = new Size(331, 32);
            label4.TabIndex = 7;
            label4.Text = "Введите название маршрута";
            // 
            // button1
            // 
            button1.Location = new Point(12, 300);
            button1.Name = "button1";
            button1.Size = new Size(280, 63);
            button1.TabIndex = 8;
            button1.Text = "Добавить экскурсию";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(12, 381);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(715, 86);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Удалить/Изменить экскурсию";
            // 
            // button3
            // 
            button3.Location = new Point(411, 40);
            button3.Name = "button3";
            button3.Size = new Size(145, 40);
            button3.TabIndex = 11;
            button3.Text = "Изменить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(260, 38);
            button2.Name = "button2";
            button2.Size = new Size(145, 40);
            button2.TabIndex = 10;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Add_Excursion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 473);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Add_Excursion";
            Text = "Add_Excursion";
            Load += Add_Excursion_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private Button button2;
        private Button button3;
    }
}