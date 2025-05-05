namespace WinForms
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
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            showAllButton = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            figuresListBox = new ListBox();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // showAllButton
            // 
            showAllButton.Location = new Point(262, 278);
            showAllButton.Name = "showAllButton";
            showAllButton.Size = new Size(120, 29);
            showAllButton.TabIndex = 0;
            showAllButton.Text = "Показать все";
            showAllButton.UseVisualStyleBackColor = true;
            showAllButton.UseWaitCursor = true;
            showAllButton.Click += showAllButton_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(86, 290);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.UseWaitCursor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(354, 57);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.UseWaitCursor = true;
            // 
            // button4
            // 
            button4.Location = new Point(354, 93);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.UseWaitCursor = true;
            // 
            // figuresListBox
            // 
            figuresListBox.Dock = DockStyle.Fill;
            figuresListBox.FormattingEnabled = true;
            figuresListBox.Location = new Point(0, 0);
            figuresListBox.Name = "figuresListBox";
            figuresListBox.Size = new Size(800, 450);
            figuresListBox.TabIndex = 4;
            figuresListBox.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 38);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 5;
            label1.Text = "label1";
            label1.UseWaitCursor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(55, 122);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 6;
            textBox1.UseWaitCursor = true;
        }

        #endregion

        private Button showAllButton;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListBox figuresListBox;
        private Label label1;
        private TextBox textBox1;
    }
}
