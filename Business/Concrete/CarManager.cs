using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)//
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Price >= min && c.Price <= max), Message.Listed);
        }

        public IDataResult<List<Car>> GetAll()//
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Message.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Message.Listed);
        }

        public IDataResult<List<Car>> GetAllByCarId(int CarId)//
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == CarId), Message.Listed);
        }
        public IResult Add(Car car)//
        {
            if (car.Description==null && car.Price==0)
            {
                return new ErrorResult(Message.NameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(Car car)//
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.Deleted);
        }

        public IResult Update(Car car)//
        {
            _carDal.Update(car);
            return new SuccessResult(Message.Updated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Message.Listed);
        }
    }
}
