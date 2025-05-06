namespace WinForms
{
    partial class AddFigureForm
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
            figureTypeComboBox = new ComboBox();
            widthTextBox = new TextBox();
            cTextBox = new TextBox();
            heightTextBox = new TextBox();
            radiusTextBox = new TextBox();
            bTextBox = new TextBox();
            aTextBox = new TextBox();
            createButton = new Button();
            SuspendLayout();
            // 
            // figureTypeComboBox
            // 
            figureTypeComboBox.FormattingEnabled = true;
            figureTypeComboBox.Location = new Point(41, 25);
            figureTypeComboBox.Name = "figureTypeComboBox";
            figureTypeComboBox.Size = new Size(151, 28);
            figureTypeComboBox.TabIndex = 0;
            figureTypeComboBox.SelectedIndexChanged += figureTypeComboBox_SelectedIndexChanged;
            // 
            // widthTextBox
            // 
            widthTextBox.Location = new Point(41, 387);
            widthTextBox.Name = "widthTextBox";
            widthTextBox.PlaceholderText = "Ширина";
            widthTextBox.Size = new Size(125, 27);
            widthTextBox.TabIndex = 5;
            // 
            // cTextBox
            // 
            cTextBox.Location = new Point(41, 208);
            cTextBox.Name = "cTextBox";
            cTextBox.PlaceholderText = "Сторона C";
            cTextBox.Size = new Size(125, 27);
            cTextBox.TabIndex = 3;
            // 
            // heightTextBox
            // 
            heightTextBox.Location = new Point(41, 449);
            heightTextBox.Name = "heightTextBox";
            heightTextBox.PlaceholderText = "Высота";
            heightTextBox.Size = new Size(125, 27);
            heightTextBox.TabIndex = 6;
            // 
            // radiusTextBox
            // 
            radiusTextBox.Location = new Point(41, 300);
            radiusTextBox.Name = "radiusTextBox";
            radiusTextBox.PlaceholderText = "Радиус";
            radiusTextBox.Size = new Size(125, 27);
            radiusTextBox.TabIndex = 4;
            // 
            // bTextBox
            // 
            bTextBox.Location = new Point(41, 149);
            bTextBox.Name = "bTextBox";
            bTextBox.PlaceholderText = "Сторона B";
            bTextBox.Size = new Size(125, 27);
            bTextBox.TabIndex = 2;
            // 
            // aTextBox
            // 
            aTextBox.Location = new Point(41, 95);
            aTextBox.Name = "aTextBox";
            aTextBox.PlaceholderText = "Сторона A";
            aTextBox.Size = new Size(125, 27);
            aTextBox.TabIndex = 1;
            aTextBox.Tag = "";
            // 
            // createButton
            // 
            createButton.Location = new Point(98, 552);
            createButton.Name = "createButton";
            createButton.Size = new Size(94, 29);
            createButton.TabIndex = 7;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += CreateButton_Click;
            // 
            // AddFigureForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 630);
            Controls.Add(createButton);
            Controls.Add(aTextBox);
            Controls.Add(bTextBox);
            Controls.Add(radiusTextBox);
            Controls.Add(heightTextBox);
            Controls.Add(cTextBox);
            Controls.Add(widthTextBox);
            Controls.Add(figureTypeComboBox);
            Name = "AddFigureForm";
            Text = "AddFigureForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox figureTypeComboBox;
        private TextBox widthTextBox;
        private TextBox cTextBox;
        private TextBox heightTextBox;
        private TextBox radiusTextBox;
        private TextBox bTextBox;
        private TextBox aTextBox;
        private Button createButton;
    }
}