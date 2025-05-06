using Project.Entities;
using Project.Data;
using Project.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
{
    public partial class AddFigureForm : Form
    {
        public Figure CreatedFigure { get; private set; }

        public AddFigureForm()
        {
            InitializeComponent();
            figureTypeComboBox.Items.AddRange(new[] { "Triangle", "Circle", "Rectangle" });
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            switch (figureTypeComboBox.SelectedItem?.ToString())
            {
                case "Triangle":
                    CreateTriangle();
                    break;
                case "Circle":
                    CreateCircle();
                    break;
                case "Rectangle":
                    CreateRectangle();
                    break;
                default:
                    MessageBox.Show("Выберите тип фигуры");
                    return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CreateTriangle()
        {
            if (double.TryParse(aTextBox.Text, out double a) &&
                double.TryParse(bTextBox.Text, out double b) &&
                double.TryParse(cTextBox.Text, out double c))
            {
                try
                {
                    CreatedFigure = new Triangle(a, b, c);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Неверный формат чисел");
            }
        }

        private void CreateCircle()
        {
            if (double.TryParse(radiusTextBox.Text, out double radius))
            {
                try
                {
                    CreatedFigure = new Circle(radius);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Неверный формат радиуса");
            }
        }

        private void CreateRectangle()
        {
            if (double.TryParse(widthTextBox.Text, out double width) &&
                double.TryParse(heightTextBox.Text, out double height))
            {
                try
                {
                    CreatedFigure = new Project.Entities.Rectangle(width, height);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Неверный формат размеров");
            }
        }

        private void figureTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Скрыть все поля
            aTextBox.Visible = false;
            bTextBox.Visible = false;
            cTextBox.Visible = false;
            radiusTextBox.Visible = false;
            widthTextBox.Visible = false;
            heightTextBox.Visible = false;

            // Показать нужные поля
            switch (figureTypeComboBox.SelectedItem?.ToString())
            {
                case "Triangle":
                    aTextBox.Visible = true;
                    bTextBox.Visible = true;
                    cTextBox.Visible = true;
                    break;
                case "Circle":
                    radiusTextBox.Visible = true;
                    break;
                case "Rectangle":
                    widthTextBox.Visible = true;
                    heightTextBox.Visible = true;
                    break;
            }
        }
    }
}
