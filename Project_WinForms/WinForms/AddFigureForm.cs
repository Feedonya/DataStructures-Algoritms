using System;
using System.Windows.Forms;
using Project.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project.WinForms
{
    public partial class AddFigureForm : Form
    {
        public Figure CreatedFigure { get; private set; }

        public AddFigureForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
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
                    CreatedFigure = new Rectangle(width, height);
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

        // Дизайнер формы (добавьте элементы через Visual Studio)
    }
}