using Services.Abstract;

namespace API.Controllers
{
    public class DriversController
    {
        private readonly IDriverService _driversService;

        public DriversController(IDriverService driversService)
        {
            _driversService = driversService;
        }

        public void AddDriver(DriverModel model)
        {
            _driversService.AddDriver(model.ToDomain());
        }

        public DriverModel GetDriverById(int id)
        {
            var driver = _driversService.GetDriverById(id);
            return driver?.ToModel();
        }

        public void DeleteDriverById(int id)
        {
            _driversService.DeleteDriverById(id);
        }
    }
}