
using DLL;
using DLL.Models;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var options = new DbContextOptionsBuilder<STOContext>()
           .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StoDB;Integrated Security=True;")
           .Options;
var context = new STOContext(options);
var repository = new StoRepository(context);

Console.WriteLine("=== Car Management System ===");
Console.WriteLine("1 - Add Car");
Console.WriteLine("2 - Delete Car");
Console.WriteLine("3 - Update Car");
Console.WriteLine("4 - Show All Cars");
Console.WriteLine("5 - Search Car by ID");
Console.WriteLine("6 - Show 20 Cars");
Console.WriteLine("7 - Update Only Price");
Console.WriteLine("0 - Exit");

string choice;

do
{
    Console.Write("\nEnter choice: ");
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
            Console.Write("Enter car`s brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter car`s model: ");
            string model = Console.ReadLine();
            Console.Write("Enter car`s year: ");
            DateTime year = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter car`s price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Car car = new Car()
            {
                Brand = brand,
                Model = model,
                Year = year,
                Price = price,
            };
            await repository.AddCar(car);
            }

            break;

        case "2":
            {
            Console.Write("Enter number car for deleted: ");
            Car[] car = await repository.GetAllCars();
            for (int i = 0; i < car.Length; i++)
            {
                Console.WriteLine($"{i}: {car[i].Brand} {car[i].Model} - {car[i].Price}");
            }
            int id = Convert.ToInt32(Console.ReadLine());
            await repository.DelCar(await repository.SearchCarsById(car[id].Id));
            }
            break;

        case "3":
            {
                Console.Write("Enter number car for updated: ");
                Car[] cars = await repository.GetAllCars();
                for (int i = 0; i < cars.Length; i++)
                {
                    Console.WriteLine($"{i}: {cars[i].Brand} {cars[i].Model} - {cars[i].Price}");
                }
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter car`s brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter car`s model: ");
                string model = Console.ReadLine();
                Console.Write("Enter car`s year: ");
                DateTime year = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter car`s price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                Car car = new Car()
                {
                    Brand = brand,
                    Model = model,
                    Year = year,
                    Price = price,
                };
                await repository.UpdateCar(id,car);
            }
            break;

        case "6":
            {
                Car[] car =  await repository.ShowCars();
                for(int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"{i}: {car[i].Brand} {car[i].Model} - {car[i].Price}");
                }
            }
            break;

        case "5":
            {
                Console.Write("Enter number car for search: ");
                int id = Convert.ToInt32(Console.ReadLine());
                await repository.SearchCarsById(id);
            }
            break;

        case "4":
            {
                Car[] car = await repository.GetAllCars();
                for (int i = 0; i < car.Length; i++)
                {
                    Console.WriteLine($"{i}: {car[i].Brand} {car[i].Model} - {car[i].Price}");
                }
            }
            break;

        case "7":
            {
                Console.Write("Enter number car for updated price: ");
                Car[] cars = await repository.GetAllCars();
                for (int i = 0; i < cars.Length; i++)
                {
                    Console.WriteLine($"{i}: {cars[i].Brand} {cars[i].Model} - {cars[i].Price}");
                }
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new price: ");
                decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                await repository.UpdateCarsPrice(id, newPrice);
            }
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }

} while (choice != "0");

