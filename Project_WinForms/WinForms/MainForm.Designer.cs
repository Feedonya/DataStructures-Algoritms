namespace WinForms
{
    partial class MainForm
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
            showAllButton = new Button();
            addButton = new Button();
            removeButton = new Button();
            exitButton = new Button();
            Label = new Label();
            indexTextBox = new TextBox();
            figuresListBox = new ListBox();
            sortButton = new Button();
            SuspendLayout();
            // 
            // showAllButton
            // 
            showAllButton.Location = new Point(45, 358);
            showAllButton.Name = "showAllButton";
            showAllButton.Size = new Size(108, 29);
            showAllButton.TabIndex = 0;
            showAllButton.Text = "Показать всё";
            showAllButton.UseVisualStyleBackColor = true;
            showAllButton.Click += showAllButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(167, 358);
            addButton.Name = "addButton";
            addButton.Size = new Size(109, 29);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(438, 292);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(109, 29);
            removeButton.TabIndex = 2;
            removeButton.Text = "Удалить";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(438, 358);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(109, 29);
            exitButton.TabIndex = 3;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Location = new Point(29, 292);
            Label.Name = "Label";
            Label.Size = new Size(176, 20);
            Label.TabIndex = 4;
            Label.Text = "Введите индекс фигуры:";
            // 
            // indexTextBox
            // 
            indexTextBox.Location = new Point(232, 289);
            indexTextBox.Name = "indexTextBox";
            indexTextBox.PlaceholderText = "Индекс...";
            indexTextBox.Size = new Size(175, 27);
            indexTextBox.TabIndex = 5;
            // 
            // figuresListBox
            // 
            figuresListBox.Dock = DockStyle.Fill;
            figuresListBox.FormattingEnabled = true;
            figuresListBox.Location = new Point(0, 0);
            figuresListBox.Name = "figuresListBox";
            figuresListBox.Size = new Size(607, 436);
            figuresListBox.TabIndex = 6;
            figuresListBox.SelectedIndexChanged += figuresListBox_SelectedIndexChanged;
            // 
            // sortButton
            // 
            sortButton.Location = new Point(293, 358);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(125, 29);
            sortButton.TabIndex = 7;
            sortButton.Text = "Отсортировать";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 436);
            Controls.Add(sortButton);
            Controls.Add(removeButton);
            Controls.Add(exitButton);
            Controls.Add(addButton);
            Controls.Add(Label);
            Controls.Add(showAllButton);
            Controls.Add(indexTextBox);
            Controls.Add(figuresListBox);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button showAllButton;
        private Button addButton;
        private Button removeButton;
        private Button exitButton;
        private Label Label;
        private TextBox indexTextBox;
        private ListBox figuresListBox;
        private Button sortButton;
    }
}