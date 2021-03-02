using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color { ColorName = "Yeşil" };
            colorManager.Add(color1);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + "-" + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand { BrandName = "Ford" };
            brandManager.Add(brand1);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "-" + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car { ColorId = 4, Description = "açıklama7", ModelYear = 2015, Price = 165, BrandId = 4 };
            carManager.Add(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "/" + car.Price);
            }
        }
    }
}
