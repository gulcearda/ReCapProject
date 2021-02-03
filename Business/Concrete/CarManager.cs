using System;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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

        
        public System.Collections.Generic.List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
