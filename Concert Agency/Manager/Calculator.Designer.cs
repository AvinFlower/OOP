namespace Manager
{
    partial class Calculator
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
            button1 = new Button();
            npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button19 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 21);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(290, 58);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 105);
            button1.Name = "button1";
            button1.Size = new Size(68, 55);
            button1.TabIndex = 1;
            button1.Text = "AC";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ClearButton_Click;
            // 
            // npgsqlCommandBuilder1
            // 
            npgsqlCommandBuilder1.QuotePrefix = "\"";
            npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(234, 104);
            button3.Name = "button3";
            button3.Size = new Size(68, 55);
            button3.TabIndex = 3;
            button3.Text = "/";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OperationButton_Click;
            // 
            // button4
            // 
            button4.Location = new Point(234, 166);
            button4.Name = "button4";
            button4.Size = new Size(68, 55);
            button4.TabIndex = 4;
            button4.Text = "*";
            button4.UseVisualStyleBackColor = true;
            button4.Click += OperationButton_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(234, 227);
            button5.Name = "button5";
            button5.Size = new Size(68, 55);
            button5.TabIndex = 5;
            button5.Text = "-";
            button5.UseVisualStyleBackColor = true;
            button5.Click += OperationButton_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(234, 288);
            button6.Name = "button6";
            button6.Size = new Size(68, 55);
            button6.TabIndex = 6;
            button6.Text = "+";
            button6.UseVisualStyleBackColor = true;
            button6.Click += OperationButton_Click;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(234, 349);
            button7.Name = "button7";
            button7.Size = new Size(68, 55);
            button7.TabIndex = 7;
            button7.Text = "=";
            button7.UseVisualStyleBackColor = true;
            button7.Click += EqualsButton_Click;
            // 
            // button8
            // 
            button8.Location = new Point(12, 166);
            button8.Name = "button8";
            button8.Size = new Size(68, 55);
            button8.TabIndex = 8;
            button8.Text = "7";
            button8.UseVisualStyleBackColor = true;
            button8.Click += NumberButton_Click;
            // 
            // button9
            // 
            button9.Location = new Point(86, 166);
            button9.Name = "button9";
            button9.Size = new Size(68, 55);
            button9.TabIndex = 9;
            button9.Text = "8";
            button9.UseVisualStyleBackColor = true;
            button9.Click += NumberButton_Click;
            // 
            // button10
            // 
            button10.Location = new Point(160, 166);
            button10.Name = "button10";
            button10.Size = new Size(68, 55);
            button10.TabIndex = 10;
            button10.Text = "9";
            button10.UseVisualStyleBackColor = true;
            button10.Click += NumberButton_Click;
            // 
            // button11
            // 
            button11.Location = new Point(12, 227);
            button11.Name = "button11";
            button11.Size = new Size(68, 55);
            button11.TabIndex = 11;
            button11.Text = "4";
            button11.UseVisualStyleBackColor = true;
            button11.Click += NumberButton_Click;
            // 
            // button12
            // 
            button12.Location = new Point(12, 288);
            button12.Name = "button12";
            button12.Size = new Size(68, 55);
            button12.TabIndex = 12;
            button12.Text = "1";
            button12.UseVisualStyleBackColor = true;
            button12.Click += NumberButton_Click;
            // 
            // button13
            // 
            button13.Location = new Point(12, 349);
            button13.Name = "button13";
            button13.Size = new Size(142, 55);
            button13.TabIndex = 13;
            button13.Text = "0";
            button13.UseVisualStyleBackColor = true;
            button13.Click += NumberButton_Click;
            // 
            // button14
            // 
            button14.Location = new Point(86, 227);
            button14.Name = "button14";
            button14.Size = new Size(68, 55);
            button14.TabIndex = 14;
            button14.Text = "5";
            button14.UseVisualStyleBackColor = true;
            button14.Click += NumberButton_Click;
            // 
            // button15
            // 
            button15.Location = new Point(160, 227);
            button15.Name = "button15";
            button15.Size = new Size(68, 55);
            button15.TabIndex = 15;
            button15.Text = "6";
            button15.UseVisualStyleBackColor = true;
            button15.Click += NumberButton_Click;
            // 
            // button16
            // 
            button16.Location = new Point(86, 288);
            button16.Name = "button16";
            button16.Size = new Size(68, 55);
            button16.TabIndex = 16;
            button16.Text = "2";
            button16.UseVisualStyleBackColor = true;
            button16.Click += NumberButton_Click;
            // 
            // button17
            // 
            button17.Location = new Point(160, 288);
            button17.Name = "button17";
            button17.Size = new Size(68, 55);
            button17.TabIndex = 17;
            button17.Text = "3";
            button17.UseVisualStyleBackColor = true;
            button17.Click += NumberButton_Click;
            // 
            // button19
            // 
            button19.Location = new Point(160, 348);
            button19.Name = "button19";
            button19.Size = new Size(68, 55);
            button19.TabIndex = 19;
            button19.Text = ".";
            button19.UseVisualStyleBackColor = true;
            button19.Click += NumberButton_Click;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 415);
            Controls.Add(button19);
            Controls.Add(button17);
            Controls.Add(button16);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Calculator";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button19;
    }
}