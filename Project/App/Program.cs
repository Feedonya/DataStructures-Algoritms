using Project.App;
using Project.Data;
using Project.Domain.Services;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new FigureRepository();
            var service = new FigureService(repository);
            var app = new ConsoleApp(service);

            app.Run();
        }
    }
}