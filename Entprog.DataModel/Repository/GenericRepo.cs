using Enrollment.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entprog.DataModel.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext context;
        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }
        //new add
        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        //new delete
        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
        //new exists
        public async Task<bool> Exists(int id)
        {
            T entity = await context.Set<T>().FindAsync(id);
            if (entity != null) return true;
            else return false;
        }
        //new getallasync
        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        //new getasync
        public async Task<T> GetAsync(int id)
        {
            T entity = await context.Set<T>().FindAsync(id);
            return entity;
        }
        //new unpdateasync
        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
