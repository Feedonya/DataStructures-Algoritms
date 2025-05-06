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
            widthTextBox.Size = new Size(125, 27);
            widthTextBox.TabIndex = 1;
            widthTextBox.Text = "Ширина";
            // 
            // cTextBox
            // 
            cTextBox.Location = new Point(41, 208);
            cTextBox.Name = "cTextBox";
            cTextBox.Size = new Size(125, 27);
            cTextBox.TabIndex = 2;
            cTextBox.Text = "Сторона C";
            // 
            // heightTextBox
            // 
            heightTextBox.Location = new Point(41, 449);
            heightTextBox.Name = "heightTextBox";
            heightTextBox.Size = new Size(125, 27);
            heightTextBox.TabIndex = 3;
            heightTextBox.Text = "Высота";
            // 
            // radiusTextBox
            // 
            radiusTextBox.Location = new Point(41, 300);
            radiusTextBox.Name = "radiusTextBox";
            radiusTextBox.Size = new Size(125, 27);
            radiusTextBox.TabIndex = 4;
            radiusTextBox.Text = "Радиус";
            // 
            // bTextBox
            // 
            bTextBox.Location = new Point(41, 149);
            bTextBox.Name = "bTextBox";
            bTextBox.Size = new Size(125, 27);
            bTextBox.TabIndex = 5;
            bTextBox.Text = "Сторона B";
            // 
            // aTextBox
            // 
            aTextBox.Location = new Point(41, 95);
            aTextBox.Name = "aTextBox";
            aTextBox.Size = new Size(125, 27);
            aTextBox.TabIndex = 6;
            aTextBox.Text = "Сторона A";
            // 
            // createButton
            // 
            createButton.Location = new Point(98, 552);
            createButton.Name = "createButton";
            createButton.Size = new Size(94, 29);
            createButton.TabIndex = 7;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
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