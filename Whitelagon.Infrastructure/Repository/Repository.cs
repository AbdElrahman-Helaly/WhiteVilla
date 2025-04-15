using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Whitelagon.admin.Entities;
using Whitelagon.Application.Common;
using Whitelagon.Infrastructure.Data;

namespace Whitelagon.Infrastructure.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    { 
            private ApplicationDbcontext db;
            internal DbSet<T> dbset;

        public Repository(ApplicationDbcontext _Db)
        {
            db = _Db;
            dbset = _Db.Set<T>();
        }
       
        
        void  IRepository<T>.Add(T Entity)
            {
                db.Add(Entity);
            }
        T IRepository<T>.Get(Expression<Func<T, bool>>? filter, string? includeproperties)
            {
                IQueryable<T> query = db.Set<T>();
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (!string.IsNullOrEmpty(includeproperties))
                {
                    //Villa
                    foreach (var includeproperty in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeproperty);
                    }
                }
                return query.FirstOrDefault();
            }

         IEnumerable<T> IRepository<T>.GetAll(Expression<Func<T, bool>>? filter, string? includeproperties)
            {
                IQueryable<T> query = db.Set<T>();
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (!string.IsNullOrEmpty(includeproperties))
                {
                    //Villa
                    foreach (var includeproperty in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeproperty);
                    }
                }
                return query.ToList();

            }

        void IRepository<T>.Remove(T Entity)
            {
                db.Remove(Entity);
            }
        
         

         
        }
    }


