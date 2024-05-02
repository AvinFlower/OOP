namespace Admin
{
    partial class ChangeDB
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
            comboBox1 = new ComboBox();
            listView1 = new ListView();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Honeydew;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(13, 241);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(257, 69);
            button1.TabIndex = 42;
            button1.Text = "Change";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.ForeColor = Color.Navy;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(13, 206);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(257, 28);
            comboBox1.TabIndex = 46;
            // 
            // listView1
            // 
            listView1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.GridLines = true;
            listView1.Location = new Point(13, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(521, 188);
            listView1.TabIndex = 47;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            button2.BackColor = Color.MistyRose;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(278, 241);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(255, 69);
            button2.TabIndex = 48;
            button2.Text = "Назад на главную";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // ChangeDB
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(546, 324);
            Controls.Add(button2);
            Controls.Add(listView1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "ChangeDB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangeDB";
            Load += ChangeDB_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private ComboBox comboBox1;
        private ListView listView1;
        private Button button2;
    }
}