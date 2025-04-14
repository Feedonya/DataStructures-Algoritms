using Entities;

namespace Data.Repositories.Abstract
{
    public interface IVehiclesRepository
    {
        void AddVehicle(VehicleEntity vehicle);
        void UpdateVehicle(VehicleEntity id);
        VehicleEntity GetVehicleById(int id);
        void DeleteVehicleById(int id);
    }
}