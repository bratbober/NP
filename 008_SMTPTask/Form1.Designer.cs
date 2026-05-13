namespace _008_SMTPTask
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button3 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(89, 55);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(89, 105);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(251, 27);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 58);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 2;
            label1.Text = "Email: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 105);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 3;
            label2.Text = "Code: ";
            // 
            // button1
            // 
            button1.Location = new Point(356, 55);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(467, 58);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Send again";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick_1;
            // 
            // button3
            // 
            button3.Location = new Point(356, 105);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 6;
            button3.Text = "Press";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 384);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 7;
            label3.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private System.Windows.Forms.Timer timer1;
        private Button button3;
        private Label label3;
    }
}
