using System;
using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);

        List<Car> GetByDailyPrice(int min, int max);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

    }
}
