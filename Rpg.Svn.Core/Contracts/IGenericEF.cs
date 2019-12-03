using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Rpg.Svn.Core.Models;

namespace Rpg.Svn.Core.Contracts
{
    public interface IGenericEF<T> where T : class
    {
        BaseResponse<T> Save(T objct);
        BaseResponse<T> Delete(T objct);

        BaseResponse<T>.Collection Filter(Expression<Func<T, bool>> filter = null, bool lazyLoading = false, List<string> removeProperty = null, int? skip = null, int? take = null);
        BaseResponse<T>.Collection Filter<K>(Expression<Func<T, bool>> filter = null, Expression<Func<T, K>> orderBy = null, bool lazyLoading = false,
                                             bool asc = true, List<string> removeProperty = null, int? skip = null, int? take = null);
    }
}
