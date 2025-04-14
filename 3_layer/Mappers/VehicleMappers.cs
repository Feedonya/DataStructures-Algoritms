using Domain;
using Entities;

namespace Mappers
{
    public static class VehicleMapper
    {
        public static Vehicle ToDomain(this VehicleEntity entity)
        {
            if (entity == null) return null;
            return new Vehicle
            {
                Model = entity.Model,
                GovermentNumber = entity.GovermentNumber,
                DriverId = entity.DriverId
            };
        }

        public static VehicleEntity ToEntity(this Vehicle vehicle)
        {
            return new VehicleEntity
            {
                Model = vehicle.Model,
                GovermentNumber = vehicle.GovermentNumber,
                DriverId = vehicle.DriverId
            };
        }
    }
}