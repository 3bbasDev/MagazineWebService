using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using MagazineWebService.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MagazineWebService.DTO.Generic
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class 
    {
        private readonly MagazineContext _dbContext;
        private readonly IMapper _mapper;
        private DbSet<T> _entity;
        public GenericRepo(MagazineContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
            _entity = context.Set<T>();

        }
        public async Task<bool> Delete(Guid Id)
        {
            T entity = await _entity.FindAsync(Id);
            if (entity == null) return false;
            //entity.IsDeleted = entity.IsDeleted == false;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<TR>> Get<TR>(
            Expression<Func<T, TR>> select,
            Expression<Func<T, bool>> filter,
            Func<IQueryable<TR>, IOrderedQueryable<TR>> orderBy,
            int Take = 5, int Skip = 0)where TR :class
        {
            var query = new List<TR>();
            if (filter != null)
            {
                query = orderBy!=null? await orderBy(_entity.Where(filter).Select(select)).Skip(Skip * Take).Take(Take).ToListAsync<TR>()
                    : await _entity.Where(filter).Select(select).Skip(Skip * Take).Take(Take).ToListAsync<TR>();
            }
            else
            {
                query = orderBy!=null? await orderBy(_entity.Select(select)).Skip(Skip * Take).Take(Take).ToListAsync<TR>()
                    : await _entity.Select(select).Skip(Skip * Take).Take(Take).ToListAsync<TR>();
            }
            return query;
            //query = filter != null ? query.Where(filter) : query
            //if (orderBy != null)
            //{
            //    return await Task.FromResult(orderBy(query).Skip(Skip * Take).Take(Take).ToList());
            //}
            //else
            //{
            //    return await Task.FromResult(query.Skip(Skip * Take).Take(Take).ToList());
            //}
        }

        public async Task<bool> CheckById(Guid Id)
        {
            if (await _entity.FindAsync(Id) == null) return false;
            return true;
        }

        public async Task<bool> Insert(Expression<Func<T, bool>> filter = null,T Model = null)
        {

            if (filter != null)
            {
                var query = await _entity.Where(filter).FirstOrDefaultAsync();

                if (query != null) return false;
            }

            var Entity = _mapper.Map<T>(Model);

            await _entity.AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove(Guid Id)
        {

            T entity = await _entity.FindAsync(Id);
            if (entity == null) return false;
            _entity.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Expression<Func<T, bool>> filter , T Model)
        {
            var Entity = await _entity.Where(filter).FirstOrDefaultAsync();
            if (Entity == null) return false;
            _mapper.Map(Model, Entity);
            
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> UpdateS(Expression<Func<T, bool>> filter, T Model)
        {
            var Entity = await _entity.Where(filter).FirstOrDefaultAsync();
            if (Entity == null) return null;
            _mapper.Map(Model, Entity);

            await _dbContext.SaveChangesAsync();
            return Model;
        }

        public async Task<T> CheckByFilter(Expression<Func<T, bool>> filter)
        {
            var query = await _entity.Where(filter ).FirstOrDefaultAsync();

            if (query != null) return query;
            return null;
        }

    }
}
