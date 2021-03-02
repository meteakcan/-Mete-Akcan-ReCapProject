using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.ColorName == null)
            {
                Console.WriteLine("Hatalı veri girişi!");
            }
            else
            {
                _colorDal.Add(color);
                Console.WriteLine("Eklendi!");
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Silindi!");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int ColorId)
        {
            return _colorDal.Get(c => c.ColorId == ColorId);
        }

        public Color GetByName(string ColorName)
        {
            return _colorDal.Get(c => c.ColorName == ColorName);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Güncellendi!");
        }
    }
}

