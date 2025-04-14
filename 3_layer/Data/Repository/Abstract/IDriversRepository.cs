using Entities;

namespace Data.Repositories.Abstract
{
    public interface IDriversRepository
    {
        void AddDriver(DriverEntity driver);
        void UpdateDriver(DriverEntity id);
        DriverEntity GetDriverById(int id);
        void DeleteDriverById(int id);
        List<DriverEntity> GetAllDrivers();
    }
}