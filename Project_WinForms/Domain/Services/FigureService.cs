using Project.Data;
using Project.Entities;

namespace Project.Domain.Services
{
    public class FigureService : IFigureService
    {
        private readonly FigureRepository _repository;

        public FigureService(FigureRepository repository)
        {
            _repository = repository;
        }

        public List<Figure> GetAllFigures()
        {
            return _repository.GetAll();
        }

        public void AddFigure(Figure figure)
        {
            if (figure != null)
            {
                var figures = _repository.GetAll();
                figures.Add(figure);
                _repository.SaveAll(figures);
            }
        }

        public Figure GetFigureByIndex(int index)
        {
            var figures = _repository.GetAll();
            if (index < 0 || index >= figures.Count)
                throw new IndexOutOfRangeException("Индекс фигуры вне диапазона");

            return figures[index];
        }

        public void RemoveFigure(int index)
        {
            var figures = _repository.GetAll();
            if (index < 0 || index >= figures.Count)
                throw new IndexOutOfRangeException("Индекс фигуры вне диапазона");

            figures.RemoveAt(index);
            _repository.SaveAll(figures);
        }

        public void SortFigures()
        {
            var figures = _repository.GetAll();
            figures.Sort();
            _repository.SaveAll(figures);
        }
    }
}