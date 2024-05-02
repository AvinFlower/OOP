namespace form_Excursion
{
    partial class Edit_Flights
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
            button1 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(423, 296);
            button1.Name = "button1";
            button1.Size = new Size(342, 89);
            button1.TabIndex = 27;
            button1.Text = "Применить изменения";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(523, 116);
            label6.Name = "label6";
            label6.Size = new Size(119, 32);
            label6.TabIndex = 26;
            label6.Text = "Теплоход";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(523, 22);
            label5.Name = "label5";
            label5.Size = new Size(127, 32);
            label5.TabIndex = 25;
            label5.Text = "Экскурсия";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 311);
            label4.Name = "label4";
            label4.Size = new Size(327, 32);
            label4.TabIndex = 24;
            label4.Text = "Длительность поездки (дни)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 213);
            label3.Name = "label3";
            label3.Size = new Size(229, 32);
            label3.TabIndex = 23;
            label3.Text = "Место прибывания";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 118);
            label2.Name = "label2";
            label2.Size = new Size(234, 32);
            label2.TabIndex = 22;
            label2.Text = "Место отправления";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 22);
            label1.Name = "label1";
            label1.Size = new Size(349, 32);
            label1.TabIndex = 21;
            label1.Text = "Выберите время отправления";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(523, 151);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(242, 40);
            comboBox2.TabIndex = 20;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(523, 56);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 19;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(27, 346);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(240, 39);
            numericUpDown1.TabIndex = 18;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(27, 248);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 39);
            textBox2.TabIndex = 17;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 162);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 39);
            textBox1.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(27, 57);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(400, 39);
            dateTimePicker1.TabIndex = 15;
            dateTimePicker1.Value = new DateTime(2023, 12, 28, 19, 46, 17, 0);
            // 
            // Edit_Flights
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 406);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker1);
            Name = "Edit_Flights";
            Text = "Edit_Flights";
            Load += Edit_Flights_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox2;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
    }
}