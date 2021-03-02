﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int ColorId);
        Color GetByName(string ColorName);
        void Add(Color color);
        void Delete(Color color);
        void Update(Color color);
    }
}