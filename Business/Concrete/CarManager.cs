using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2 && car.DailyPrice <= 0) //error
                return new ErrorResult("Ekleme işlemi başarısız.");

            _carDal.Add(car);
            return new SuccessResult("Ekleme işlemi gerçekleşti.");

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Silme işlemi gerçekleşti.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 23)//23-24
                return new ErrorResult("23.00 ile 24.00 arasında sistem bakıma alındığı için güncelleme yapamazsınız.");

            _carDal.Update(car);
            return new SuccessResult("Güncelleme işlemi gerçekleşti.");
        }
    }
}
