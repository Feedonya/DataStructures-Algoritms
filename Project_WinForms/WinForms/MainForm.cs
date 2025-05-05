using System;
using System.Windows.Forms;
using Project.Data;
using Project.Domain.Services;

namespace Project.WinForms
{
    public partial class MainForm : Form
    {
        private readonly IFigureService _figureService;

        public MainForm()
        {
            InitializeComponent();
            _figureService = new FigureService(new FigureRepository());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshFiguresList();
        }

        private void RefreshFiguresList()
        {
            var figures = _figureService.GetAllFigures();
            figuresListBox.DataSource = null;
            figuresListBox.DataSource = figures;
            figuresListBox.DisplayMember = "ToString";
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            RefreshFiguresList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddFigureForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    _figureService.AddFigure(addForm.CreatedFigure);
                    RefreshFiguresList();
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(indexTextBox.Text, out int index))
            {
                try
                {
                    _figureService.RemoveFigure(index);
                    RefreshFiguresList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректный индекс", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Дизайнер формы (не изменяйте этот код)
        private void InitializeComponent()
        {
            this.figuresListBox = new System.Windows.Forms.ListBox();
            this.showAllButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // figuresListBox
            // 
            this.figuresListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.figuresListBox.FormattingEnabled = true;
            this.figuresListBox.ItemHeight = 20;
            this.figuresListBox.Location = new System.Drawing.Point(0, 0);
            this.figuresListBox.Name = "figuresListBox";
            this.figuresListBox.Size = new System.Drawing.Size(800, 344);
            this.figuresListBox.TabIndex = 0;
            // 
            // showAllButton
            // 
            this.showAllButton.Location = new System.Drawing.Point(12, 350);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(120, 30);
            this.showAllButton.TabIndex = 1;
            this.showAllButton.Text = "Показать все";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.showAllButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(160, 350);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(120, 30);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(308, 350);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(120, 30);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Удалить";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(672, 350);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(120, 30);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите индекс фигуры:";
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(160, 387);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.PlaceholderText = "Индекс...";
            this.indexTextBox.Size = new System.Drawing.Size(120, 27);
            this.indexTextBox.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.showAllButton);
            this.Controls.Add(this.figuresListBox);
            this.Name = "MainForm";
            this.Text = "Менеджер фигур";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox figuresListBox;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox indexTextBox;
    }
}