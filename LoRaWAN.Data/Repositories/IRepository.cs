﻿using LoRaWAN.Entity.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LoRaWAN.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(Expression<Func<TEntity, bool>> criteria);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> criteria = null);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> criteria, DataRequest sorting);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> criteria, int startIndex, int pageSize, string orderBy, string sortDirection);

        TEntity Add(TEntity entity);

        List<TEntity> AddRange(List<TEntity> entities);

        TEntity Edit(TEntity entity);
        bool EditReturnBool(TEntity entity);
        //bool EditBatch(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TEntity>> updateExpression);
        //bool EditBatch(Expression<Func<TEntity, bool>> expression, TEntity entity);

        void Delete(TEntity entity);
        bool DeleteReturnBool(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> criteria);

        void DeleteRange(List<TEntity> entities);
        void DeleteRange(Expression<Func<TEntity, bool>> criteria);
        bool DeleteRangeReturn(List<TEntity> entities);
        bool DeleteRangeReturn(Expression<Func<TEntity, bool>> criteria);

        TEntity Single(Expression<Func<TEntity, bool>> criteria);

        TEntity First(Expression<Func<TEntity, bool>> criteria);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> criteria);

        TEntity LastOrDefault(Expression<Func<TEntity, bool>> criteria);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> criteria);

        bool Any(Expression<Func<TEntity, bool>> criteria);

        int Count();

        int Count(Expression<Func<TEntity, bool>> criteria);



    }
}
