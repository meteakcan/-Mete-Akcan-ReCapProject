using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //buraya bellekteki verileri(normalde veritabanından gelecek) ve yaptıracağımız metotları yazarız.Linq kullanırız.
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
          {
                new Car{CarId=1,BrandId=1,ColorId=3,ModelYear=2018,Price=150,Description="Brand=Volkswagen Color=Red"},
                new Car{CarId=2,BrandId=2,ColorId=1,ModelYear=2019,Price=200,Description="Brand=Renault Color=Black"},
                new Car{CarId=3,BrandId=1,ColorId=1,ModelYear=2010,Price=700,Description="Brand=Volkswagen Color=Black"},
                new Car{CarId=4,BrandId=3,ColorId=2,ModelYear=2017,Price=250,Description="Brand=Fiat Color=White"},
          };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);


        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int CarId)
        {
            return _cars.Where(c => c.CarId == CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Price = car.Price;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
