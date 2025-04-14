using System.Collections.Generic;
using System.Linq;
using Data.Repositories.Abstract;
using Entities;

namespace Data.Repositories
{
    internal class DriversRepository : IDriversRepository
    {
        private static List<DriverEntity> list = new List<DriverEntity>();
        private static int currentId = 1;

        public void AddDriver(DriverEntity driver)
        {
            driver.Id = currentId++;
            driver.CreatedDate = System.DateTime.Now;
            list.Add(driver);
        }

        public void DeleteDriverById(int id)
        {
            var driver = list.FirstOrDefault(d => d.Id == id);
            if (driver != null) list.Remove(driver);
        }

        public DriverEntity GetDriverById(int id)
        {
            return list.FirstOrDefault(d => d.Id == id);
        }

        public void UpdateDriver(DriverEntity updated)
        {
            var driver = list.FirstOrDefault(d => d.Id == updated.Id);
            if (driver != null)
            {
                driver.Name = updated.Name;
                driver.Age = updated.Age;
            }
        }

        public List<DriverEntity> GetAllDrivers()
        {
            return list;
        }
    }
}