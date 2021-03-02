using Business.Abstract;
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

        public void Add(Brand brand)
        {
            if (brand.BrandName==null)
            {
                Console.WriteLine("Hatalı veri girişi!");
            }
            else
            {
                _brandDal.Add(brand);
                Console.WriteLine("Eklendi!");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Silindi!");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int BrandId)
        {
            return _brandDal.Get(b => b.BrandId == BrandId);
            // b=> : veritebanına SELECT * fROM Categories WHERE.... işlemini yapar(Linq)
        }

        public Brand GetByName(string BrandName)
        {
            return _brandDal.Get(b => b.BrandName == BrandName);
            // c=> : veritebanına SELECT * fROM Categories WHERE.... işlemini yapar(Linq)
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Güncellendi!");
        }
    }
}
