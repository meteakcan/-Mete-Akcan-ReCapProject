﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

//Core : Evrensel katman(Bütün .NET projelerinde kullanılabilir.)
//Core katmanı diğer hiçbir katmanı referans almaz.
//namespace(isim uzayı) = classlara,interface vs.'lere daha kolay ulaşablimek içindir.
//↓↓↓Core klasörünün içindeki DataAccess klasöründe bulunur.
namespace DataAccess.Abstract
{

    //generic constraint=kısıtlama
    //class=referans tip
    //IEntity=IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new=new'lenebilir olmalı.
    public interface IEntityRepository<T> where T : class, IEntity, new() //T : bana çalışacağım tipi söyle
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filter=ürünleri kategoriye,fiyata vs.'ye göre listele.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategory(int categoryId);
    }
}