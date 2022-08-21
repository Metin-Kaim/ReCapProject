using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + "  " + car.BrandId + "  " + car.ColorId);
            }

            #region Add_Function
            carManager.Add(new Car
            {
                CarId = 6,
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 2000,
                ModelYear = "2022",
                Description = "Nice!!"
            });

            Console.WriteLine("-------Add------");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + "  " + car.BrandId + "  " + car.ColorId);
            }
            #endregion

            #region Delete_Function

            Console.WriteLine("-------Delete------");

            carManager.Delete(new Car { CarId = 1 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + "  " + car.BrandId + "  " + car.ColorId);
            }
            #endregion
        }
    }
}
