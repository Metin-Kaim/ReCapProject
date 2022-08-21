using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear="2021",DailyPrice=5000,Description="Çoksel Araba"},
                new Car{CarId=2,BrandId=2,ColorId=1,ModelYear="2011",DailyPrice=5000,Description="Çoksel Araba"},
                new Car{CarId=3,BrandId=2,ColorId=3,ModelYear="2001",DailyPrice=5000,Description="Çoksel Araba"},
                new Car{CarId=4,BrandId=1,ColorId=3,ModelYear="2020",DailyPrice=5000,Description="Çoksel Araba"},
                new Car{CarId=5,BrandId=1,ColorId=2,ModelYear="2015",DailyPrice=5000,Description="Çoksel Araba"},

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
           return (Car)_cars.Where(c=>c.CarId==id);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
