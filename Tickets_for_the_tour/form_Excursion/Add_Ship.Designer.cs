namespace form_Excursion
{
    partial class Add_Ship
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
            comboBox1 = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            button2 = new Button();
            comboBox2 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(537, 39);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(33, 121);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(537, 39);
            numericUpDown1.TabIndex = 1;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(33, 208);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(537, 39);
            numericUpDown2.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(33, 304);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(33, 368);
            button1.Name = "button1";
            button1.Size = new Size(242, 61);
            button1.TabIndex = 4;
            button1.Text = "Добавить судно";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 9);
            label1.Name = "label1";
            label1.Size = new Size(189, 32);
            label1.TabIndex = 5;
            label1.Text = "Название судна";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 86);
            label2.Name = "label2";
            label2.Size = new Size(351, 32);
            label2.TabIndex = 6;
            label2.Text = "Максимальная скорость судна";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 173);
            label3.Name = "label3";
            label3.Size = new Size(537, 32);
            label3.TabIndex = 7;
            label3.Text = "Максимальное колличество пассажиров судна";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 269);
            label4.Name = "label4";
            label4.Size = new Size(293, 32);
            label4.TabIndex = 8;
            label4.Text = "Уровень комфорта судна";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Location = new Point(345, 269);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(257, 169);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Удалить корабль";
            // 
            // button2
            // 
            button2.Location = new Point(6, 99);
            button2.Name = "button2";
            button2.Size = new Size(242, 61);
            button2.TabIndex = 5;
            button2.Text = "Удалить судно";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(6, 38);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(242, 40);
            comboBox2.TabIndex = 4;
            // 
            // Add_Ship
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 450);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Add_Ship";
            Text = "Add_Ship";
            Load += Add_Ship_Load;
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
        private ComboBox comboBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private Button button2;
        private ComboBox comboBox2;
    }
}