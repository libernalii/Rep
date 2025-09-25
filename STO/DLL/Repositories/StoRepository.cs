using DLL.Interfaces;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class StoRepository : IStoRepository
    {
        private readonly STOContext _context;
        public StoRepository(STOContext context)
        {
            _context = context;
        }

        public async Task<Car> AddCar(Car car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task DelCar(Car car)
        {
            _context.Remove(car);
            await _context.SaveChangesAsync();
        }

        public Task<Car[]> GetAllCars()
        {
            return _context.Set<Car>().ToArrayAsync();
        }

        public Task<Car> SearchCarsById(int id)
        {
            return _context.Set<Car>().FirstAsync(x => x.Id == id);
        }

        public Task<Car[]> ShowCars()
        {
            return _context.Set<Car>().ToArrayAsync();
        }

        public async Task<Car> UpdateCar(int id, Car newCar)
        {
            var car = await _context.Set<Car>().FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            car.Brand = newCar.Brand;
            car.Model = newCar.Model;
            car.Year = newCar.Year;
            car.Price = newCar.Price;
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCarsPrice(int id, decimal newPrice)
        {
            var car = await _context.Set<Car>().FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            car.Price = newPrice;
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
