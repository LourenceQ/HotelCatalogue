﻿using HotelCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace HotelCatalogue.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);
        Task<IPagedList<T>> GetPagedList(
            RequestParams requestParams,
            List<string> includes = null);

        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        void DeleteRage(IEnumerable<T> entities);
        void Update(T entity);
    }
}
