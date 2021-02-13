using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        //injection yapacaksın unutma
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >=2)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç eklendi");
            }

            else if (car.Description.Length<2)
            {
                Console.WriteLine("Aracın ismi min 2 karakter olmalıdır");
            }

            else if (car.DailyPrice == 0)
            {
                Console.WriteLine("Aracın günlük fiyatı 0'dan büyük olmalıdır");
            }
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(int min, int max)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
