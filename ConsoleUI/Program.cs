using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var entity in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("car id: {0} - brand id: {1} ", entity.CarId, entity.BrandId);
            }

            Console.WriteLine();

            foreach (var entity in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine("car id: {0} - color id: {1} ", entity.CarId, entity.ColorId);
            }

            Console.WriteLine();

            Car car = carManager.GetById(3);

            Console.WriteLine("car id: {0} - color id: {1} ", car.CarId, car.ColorId);
        }
    }
}
