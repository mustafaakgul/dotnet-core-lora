using LoRaWAN.Entity.DTOs.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace LoRaWAN.Data.Extensions
{
    public static class EfRepositoryExtension
    {
        public static IQueryable<TEntity> CriteriaOrDefault<TEntity>(this IQueryable<TEntity> queries, Expression<Func<TEntity, bool>> criteria)
        {
            if (criteria != null)
                queries = queries.Where(criteria);

            return queries;
        }
        public static IQueryable<TEntity> SortOrDefault<TEntity>(this IQueryable<TEntity> queries, DataRequest request)
        {
            queries = queries.OrderBy($"{request.Sort.Order} {request.Sort.Direction}");

            if (request.Limit > 0)
                queries = queries.Skip(request.Offset).Take(request.Limit);

            return queries;
        }
        public static IQueryable<TEntity> Pagination<TEntity, TModel>(this IQueryable<TEntity> queries, DataRequest<TModel> request)
        {
            if (request.Limit > 0)
                queries = queries.Skip(request.Offset).Take(request.Limit);

            return queries;
        }

        public static IQueryable<TEntity> ToDataResult<TEntity>(this IQueryable<TEntity> queries, DataRequest request)
        {
            queries = queries.OrderBy($"{request.Sort.Order} {request.Sort.Direction}");

            if (request.Limit > 0)
                queries = queries.Skip(request.Offset).Take(request.Limit);

            return queries;
        }
    }
}
