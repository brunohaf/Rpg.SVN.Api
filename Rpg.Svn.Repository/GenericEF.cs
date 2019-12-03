using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Rpg.Svn.Core.Contracts;
using Rpg.Svn.Core.Models;
using Rpg.Svn.Repository.Lib;


namespace Rpg.Svn.Repository
{
    public class GenericEF<T, U> : IGenericEF<T> where T : class
    {
        private DbContext _dbContext { get; set; }
        public GenericEF()
        {
            _dbContext = (DbContext)Activator.CreateInstance(typeof(U));
        }

        public virtual BaseResponse<T> Save(T objct)
        {
            var resultado = new BaseResponse<T>();
            var obj = (object)objct;
            try
            {
                PropertyInfo[] chavesPrimarias = obj.GetType().GetProperties().Where(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute))).ToArray();

                if (chavesPrimarias == null || chavesPrimarias.Length == 0)
                    chavesPrimarias = obj.GetType().GetProperties().Where(p => p.PropertyType == typeof(int) || p.PropertyType == typeof(decimal) || p.PropertyType == typeof(Int64) || p.PropertyType == typeof(double)).ToArray();

                if (chavesPrimarias == null || chavesPrimarias.Length == 0)
                    chavesPrimarias = obj.GetType().GetProperties();

                var entry = _dbContext.Entry(obj);
                var dbSet = _dbContext.Set<T>();
                var keyValues = new List<object>();
                foreach (var chave in chavesPrimarias)
                    keyValues.Add(entry.Property(chave.Name).CurrentValue);

                var stored = dbSet.Find(keyValues.ToArray());

                bool isUpdate = stored != null;

                if (!isUpdate)
                {
                    entry.State = EntityState.Added;
                }
                else
                {
                    _dbContext.Entry(stored).State = EntityState.Detached;
                    entry.State = EntityState.Modified;
                }

                int retlinhas = _dbContext.SaveChanges();

                resultado.Content = ((T)obj);

                if (retlinhas == 0)
                {
                    resultado.Success = false;
                    resultado.Message = "O registro não foi salvo.";
                }
            }
            catch (Exception ex)
            {
                resultado.Success = false;
                resultado.Message = ex.Message;
            }

            return resultado;
        }

        public BaseResponse<T> Delete(T objct)
        {
            var resultado = new BaseResponse<T>();
            var obj = (object)objct;

            try
            {
                var props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (props != null && props.Length > 0)
                {
                    var propsPrimitive = props.Where(p => p.IsPrimitive()).ToArray();
                    _dbContext.Entry(obj).State = EntityState.Deleted;

                    int retlinhas = _dbContext.SaveChanges();
                    resultado.Content = ((T)obj);

                    if (retlinhas == 0)
                    {
                        resultado.Success = false;
                        resultado.Message = "O registro não foi excluído";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Success = false;
                resultado.Message = ex.Message;
            }

            return resultado;
        }

        public BaseResponse<T>.Collection Filter(Expression<Func<T, bool>> filter = null, bool lazyLoading = false, List<string> removeProperty = null, int? skip = null, int? take = null)
        {
            return Filter<object>(filter, lazyLoading: lazyLoading, removeProperty: removeProperty, skip: skip, take: take);
        }
        public BaseResponse<T>.Collection Filter<K>(Expression<Func<T, bool>> filter = null, Expression<Func<T, K>> orderBy = null, bool lazyLoading = false, bool asc = true, List<string> removeProperty = null, int? skip = null, int? take = null)
        {
            var resultado = new BaseResponse<T>.Collection();

            try
            {
                IQueryable<T> query = _dbContext.Set<T>();

                if (orderBy != null)
                {
                    if (asc)
                        query = query.OrderBy(orderBy);
                    else
                        query = query.OrderByDescending(orderBy);
                }

                filter = CreateLambdaActive(lazyLoading, ref query, filter, removeProperty);

                if (filter != null)
                    query = query.Where(filter);

                if (skip.HasValue && take.HasValue)
                {
                    query = query.Skip((skip.Value - 1) * take.Value).Take(take.Value);
                }

                resultado.List = query.ToList();
                resultado.Total = resultado.List.Count;
            }
            catch (Exception ex)
            {
                resultado.Success = false;
                resultado.Message = ex.Message;
            }

            return resultado;
        }

        private Expression<Func<T, bool>> CreateLambdaActive(bool lazyLoading, ref IQueryable<T> query, Expression<Func<T, bool>> lambda = null, List<string> removeProperty = null)
        {
            try
            {
                var objList = Activator.CreateInstance<T>();
                var props = objList.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                if (lazyLoading)
                {
                    foreach (var includeProperty in props.Where(p => !p.IsPrimitive()))
                    {
                        if (lazyLoading && !includeProperty.CustomAttributes.Any(x => x.AttributeType.Name.Trim().ToUpper().Equals("NOTMAPPEDATTRIBUTE")))
                        {
                            if (removeProperty != null)
                            {
                                if (!removeProperty.Any(rm => rm.ToUpper().Equals(includeProperty.Name.ToUpper())))
                                    query = query.Include(includeProperty.Name);
                            }
                            else
                            {
                                query = query.Include(includeProperty.Name);

                            }
                        }
                    }
                }

                return lambda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
