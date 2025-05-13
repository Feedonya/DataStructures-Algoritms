using Project.Data;
using Project.Domain.Services;

namespace WinForms
{
    public partial class MainForm : Form
    {
        private readonly IFigureService _figureService;
        public MainForm()
        {
            InitializeComponent();
            _figureService = new FigureService(new FigureRepository());
        }

        private void figuresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void RefreshFiguresList()
        {
            var figures = _figureService.GetAllFigures();
            figuresListBox.DataSource = null;

            // Создаем список строк с индексами
            var displayItems = new List<string>();
            for (int i = 0; i < figures.Count; i++)
            {
                displayItems.Add($"[{i}] {figures[i]}");
            }

            figuresListBox.DataSource = displayItems;
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            if (_figureService != null) {
                _figureService.SortFigures();
                RefreshFiguresList();
            }
        }
    }
}
