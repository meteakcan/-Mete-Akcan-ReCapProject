using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetByUnitPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.Price >= min && c.Price <= max);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByCarId(int CarId)
        {
            return _carDal.GetAll(c => c.CarId == CarId);
        }

        public void Add(Car car)
        {
            if (car.Description==null && car.Price==0)
            {
                Console.WriteLine("Hatalı veri girişi!");
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Eklendi!");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Silindi!");
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Güncellendi!");
        }
    }
}
