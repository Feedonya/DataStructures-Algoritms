using Domain;

namespace _3_layer.Services.Abstract
{
    public interface IDriverService
    {
        void AddDriver(Driver driver);
        void UpdateDriverById(Driver driver);
        Driver GetDriverById(int id);
        void DeleteDriverById(int id);
    }
}
