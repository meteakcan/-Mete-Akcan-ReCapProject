using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName==null)
            {
                return new ErrorResult(Message.NameInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Message.Added);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Message.Listed);
        }

        public IDataResult<Brand> GetById(int BrandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == BrandId), Message.Listed);
            // b=> : veritebanına SELECT * FROM Categories WHERE.... işlemini yapar(Linq)
        }

        public IDataResult<Brand> GetByName(string BrandName)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandName == BrandName), Message.Listed);
            // c=> : veritebanına SELECT * FROM Categories WHERE.... işlemini yapar(Linq)
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Message.Updated);
        }
    }
}
