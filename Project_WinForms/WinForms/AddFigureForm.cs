using Project.Entities;

namespace WinForms
{
    public partial class AddFigureForm : Form
    {
        public Figure CreatedFigure { get; private set; }

        public AddFigureForm()
        {
            InitializeComponent();
            figureTypeComboBox.Items.AddRange(new[] { "Triangle", "Circle", "Rectangle" });
            HideAllFields();
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
            // Скрыть все поля по умолчанию
            HideAllFields();

            // Показать нужные поля в зависимости от типа фигуры
            switch (figureTypeComboBox.SelectedItem?.ToString())
            {
                case "Triangle":
                    ShowTriangleFields();
                    break;
                case "Circle":
                    ShowCircleFields();
                    break;
                case "Rectangle":
                    ShowRectangleFields();
                    break;
            }
        }

        private void HideAllFields()
        {
            aTextBox.Visible = false;
            bTextBox.Visible = false;
            cTextBox.Visible = false;
            radiusTextBox.Visible = false;
            widthTextBox.Visible = false;
            heightTextBox.Visible = false;
        }

        private void ShowTriangleFields()
        {
            aTextBox.Visible = true;
            bTextBox.Visible = true;
            cTextBox.Visible = true;
        }

        private void ShowCircleFields()
        {
            radiusTextBox.Visible = true;
        }

        private void ShowRectangleFields()
        {
            widthTextBox.Visible = true;
            heightTextBox.Visible = true;
        }
    }
}
