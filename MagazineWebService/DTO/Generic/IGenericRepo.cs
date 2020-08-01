using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.DTO.Generic
{
    public interface IGenericRepo<T> where T : class
    {
        public Task<bool> CheckById(Guid Id);
        public Task<T> CheckByFilter(Expression<Func<T, bool>> filter);
        public Task<bool> Insert(Expression<Func<T, bool>> filter = null,T Model=null);
        public Task<bool> Delete(Guid Id);
        public Task<bool> Remove(Guid Id);
        public Task<bool> Update(Expression<Func<T, bool>> filter = null, T Model=null);
        public Task<T> UpdateS(Expression<Func<T, bool>> filter = null, T Model=null);
        public Task<ICollection<TR>> Get<TR>(
            Expression<Func<T, TR>> select,
            Expression<Func<T, bool>> filter,
            Func<IQueryable<TR>, IOrderedQueryable<TR>> orderBy,
            int Take = 5, int Skip = 0) where TR : class;

    }
}
