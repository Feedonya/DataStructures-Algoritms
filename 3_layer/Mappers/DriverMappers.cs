using Domain;
using Entities;

namespace Mappers
{
    public static class DriverMapper
    {
        public static DriverEntity ToEntity(this Driver driver)
        {
            return new DriverEntity
            {
                Age = driver.Age,
                Name = driver.Name
            };
        }

        public static Driver ToDomain(this DriverEntity entity)
        {
            if (entity == null) return null;
            return new Driver
            {
                Name = entity.Name,
                Age = entity.Age
            };
        }
    }
}