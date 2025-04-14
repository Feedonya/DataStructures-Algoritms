using Data.Repositories.Abstract;
using Domain;
using Mappers;

namespace Services
{
    public class DriversService : IDriverService
    {
        private readonly IDriversRepository _driversRepository;

        public DriversService(IDriversRepository driversRepository)
        {
            _driversRepository = driversRepository;
        }

        public void AddDriver(Driver driver)
        {
            _driversRepository.AddDriver(driver.ToEntity());
        }

        public void DeleteDriverById(int id)
        {
            _driversRepository.DeleteDriverById(id);
        }

        public Driver GetDriverById(int id)
        {
            var entity = _driversRepository.GetDriverById(id);
            return entity?.ToDomain();
        }

        public void UpdateDriverById(Driver driver)
        {
            _driversRepository.UpdateDriver(driver.ToEntity());
        }
    }
}