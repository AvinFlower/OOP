namespace form_Excursion
{
    partial class Form_Ticket
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxLastName = new TextBox();
            textBoxFirstName = new TextBox();
            textBoxMiddleName = new TextBox();
            textBoxPassportData = new TextBox();
            button1 = new Button();
            dateTimePickerBirthDate = new DateTimePicker();
            label6 = new Label();
            comboBox1 = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(98, 32);
            label1.Name = "label1";
            label1.Size = new Size(74, 40);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(302, 32);
            label2.Name = "label2";
            label2.Size = new Size(146, 40);
            label2.TabIndex = 1;
            label2.Text = "Фамилию";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(542, 32);
            label3.Name = "label3";
            label3.Size = new Size(139, 40);
            label3.TabIndex = 2;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(252, 150);
            label4.Name = "label4";
            label4.Size = new Size(349, 40);
            label4.TabIndex = 3;
            label4.Text = "Серия и номер паспорта";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(34, 297);
            label5.Name = "label5";
            label5.Size = new Size(223, 40);
            label5.TabIndex = 4;
            label5.Text = "Дата рождения";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(34, 75);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(200, 39);
            textBoxLastName.TabIndex = 6;
            textBoxLastName.TextChanged += textBoxLastName_TextChanged;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(274, 75);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(200, 39);
            textBoxFirstName.TabIndex = 7;
            textBoxFirstName.TextChanged += textBoxFirstName_TextChanged;
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Location = new Point(511, 75);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.Size = new Size(200, 39);
            textBoxMiddleName.TabIndex = 8;
            textBoxMiddleName.TextChanged += textBoxMiddleName_TextChanged;
            // 
            // textBoxPassportData
            // 
            textBoxPassportData.Location = new Point(34, 150);
            textBoxPassportData.Name = "textBoxPassportData";
            textBoxPassportData.Size = new Size(200, 39);
            textBoxPassportData.TabIndex = 9;
            textBoxPassportData.TextChanged += textBox5_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(252, 527);
            button1.Name = "button1";
            button1.Size = new Size(222, 58);
            button1.TabIndex = 10;
            button1.Text = "Купить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Location = new Point(34, 340);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(400, 39);
            dateTimePickerBirthDate.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(89, 460);
            label6.Name = "label6";
            label6.Size = new Size(536, 40);
            label6.TabIndex = 14;
            label6.Text = "Стоимость билета на экскурсию - 2000";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(244, 417);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(274, 382);
            label7.Name = "label7";
            label7.Size = new Size(183, 32);
            label7.TabIndex = 16;
            label7.Text = "Способ оплаты";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(34, 206);
            label8.Name = "label8";
            label8.Size = new Size(190, 40);
            label8.TabIndex = 17;
            label8.Text = "Гражданство";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(34, 249);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 39);
            textBox1.TabIndex = 18;
            // 
            // Form_Ticket
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 597);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(dateTimePickerBirthDate);
            Controls.Add(button1);
            Controls.Add(textBoxPassportData);
            Controls.Add(textBoxMiddleName);
            Controls.Add(textBoxFirstName);
            Controls.Add(textBoxLastName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form_Ticket";
            Text = "Form_Ticket";
            Load += Form_Ticket_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxLastName;
        private TextBox textBoxFirstName;
        private TextBox textBoxMiddleName;
        private TextBox textBoxPassportData;
        private Button button1;
        private DateTimePicker dateTimePickerBirthDate;
        private Label label6;
        private ComboBox comboBox1;
        private Label label7;
        private Label label8;
        private TextBox textBox1;
    }
}