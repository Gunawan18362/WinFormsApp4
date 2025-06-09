namespace Ibu_hamil
{
    partial class Form11
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Ibu_Hamil = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            SuspendLayout();
            // 
            // Ibu_Hamil
            // 
            Ibu_Hamil.AutoSize = true;
            Ibu_Hamil.Font = new Font("Segoe UI Black", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Ibu_Hamil.Location = new Point(548, 58);
            Ibu_Hamil.Name = "Ibu_Hamil";
            Ibu_Hamil.Size = new Size(260, 59);
            Ibu_Hamil.TabIndex = 0;
            Ibu_Hamil.Text = "IBU HAMIL";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(246, 226);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(562, 39);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bell MT", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(246, 189);
            label1.Name = "label1";
            label1.Size = new Size(89, 34);
            label1.TabIndex = 2;
            label1.Text = "Nama";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bell MT", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(246, 305);
            label2.Name = "label2";
            label2.Size = new Size(214, 34);
            label2.TabIndex = 3;
            label2.Text = "Usia Kehamilan";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bell MT", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(246, 400);
            label3.Name = "label3";
            label3.Size = new Size(144, 34);
            label3.TabIndex = 4;
            label3.Text = "Trimester";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(246, 342);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(562, 39);
            textBox2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(246, 453);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(562, 39);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Chartreuse;
            button1.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(548, 560);
            button1.Name = "button1";
            button1.Size = new Size(260, 46);
            button1.TabIndex = 9;
            button1.Text = "SIMPAN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1389, 896);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(Ibu_Hamil);
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Ibu_Hamil;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private Button button1;
    }
}
