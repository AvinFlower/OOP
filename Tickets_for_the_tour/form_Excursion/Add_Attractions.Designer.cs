namespace form_Excursion
{
    partial class Add_Attractions
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(29, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 40);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(29, 127);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(739, 40);
            comboBox2.TabIndex = 1;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(310, 33);
            label1.Name = "label1";
            label1.Size = new Size(247, 32);
            label1.TabIndex = 2;
            label1.Text = "Выберите экскурсию";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 92);
            label2.Name = "label2";
            label2.Size = new Size(309, 32);
            label2.TabIndex = 3;
            label2.Text = "Выберите точку маршрута";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 245);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(739, 39);
            textBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 210);
            label3.Name = "label3";
            label3.Size = new Size(475, 32);
            label3.TabIndex = 5;
            label3.Text = "Напишите адрес достопримечательности";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(29, 336);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(739, 39);
            textBox2.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 301);
            label4.Name = "label4";
            label4.Size = new Size(515, 32);
            label4.TabIndex = 7;
            label4.Text = "Напишите название достопримечательности";
            // 
            // button1
            // 
            button1.Location = new Point(340, 392);
            button1.Name = "button1";
            button1.Size = new Size(428, 46);
            button1.TabIndex = 8;
            button1.Text = "Добавить достопримечательность";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Add_Attractions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Add_Attractions";
            Text = "Add_Attractions";
            Load += Add_Attractions_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private Button button1;
    }
}