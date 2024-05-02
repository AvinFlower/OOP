namespace form_Excursion
{
    partial class Add_Employee
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
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            groupBox1 = new GroupBox();
            button2 = new Button();
            comboBox2 = new ComboBox();
            label6 = new Label();
            dateTimePickerBirthDate = new DateTimePicker();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(36, 42);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 57);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(36, 157);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(298, 57);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(36, 279);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(298, 57);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(398, 42);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(298, 57);
            textBox4.TabIndex = 3;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(398, 296);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(298, 40);
            comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 9);
            label1.Name = "label1";
            label1.Size = new Size(113, 32);
            label1.TabIndex = 5;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 122);
            label2.Name = "label2";
            label2.Size = new Size(61, 32);
            label2.TabIndex = 6;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 244);
            label3.Name = "label3";
            label3.Size = new Size(117, 32);
            label3.TabIndex = 7;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(398, 9);
            label4.Name = "label4";
            label4.Size = new Size(239, 32);
            label4.TabIndex = 8;
            label4.Text = "Паспортнык данные";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(398, 265);
            label5.Name = "label5";
            label5.Size = new Size(137, 32);
            label5.TabIndex = 9;
            label5.Text = "Должность";
            // 
            // button1
            // 
            button1.Location = new Point(757, 265);
            button1.Name = "button1";
            button1.Size = new Size(266, 71);
            button1.TabIndex = 10;
            button1.Text = "Добавить сотрудника";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Location = new Point(719, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(313, 200);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Уволить сотрудника";
            // 
            // button2
            // 
            button2.Location = new Point(6, 108);
            button2.Name = "button2";
            button2.Size = new Size(298, 46);
            button2.TabIndex = 11;
            button2.Text = "Удалить сотрудника";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(6, 45);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(298, 40);
            comboBox2.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(398, 128);
            label6.Name = "label6";
            label6.Size = new Size(184, 32);
            label6.TabIndex = 12;
            label6.Text = "Дата рождения";
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Location = new Point(398, 175);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(284, 39);
            dateTimePickerBirthDate.TabIndex = 14;
            // 
            // Add_Employee
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 361);
            Controls.Add(dateTimePickerBirthDate);
            Controls.Add(label6);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Add_Employee";
            Text = "Add_Employee";
            Load += Add_Employee_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private GroupBox groupBox1;
        private Button button2;
        private ComboBox comboBox2;
        private Label label6;
        private DateTimePicker dateTimePickerBirthDate;
    }
}