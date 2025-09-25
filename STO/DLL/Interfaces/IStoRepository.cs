using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IStoRepository
    {
        Task<Car> AddCar(Car car);
        Task DelCar(Car car);
        Task<Car[]> GetAllCars();
        Task<Car> UpdateCar(int id, Car newCar);
        Task<Car> SearchCarsById(int id);
        Task<Car> UpdateCarsPrice(int id, decimal newPrice);
        Task<Car[]> ShowCars();
    }
}
