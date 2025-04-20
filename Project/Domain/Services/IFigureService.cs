using System.Collections.Generic;
using Project.Entities;

namespace Project.Domain.Services
{
    public interface IFigureService
    {
        List<Figure> GetAllFigures();
        void AddFigure(Figure figure);
        Figure GetFigureByIndex(int index);
        void RemoveFigure(int index);
    }
}