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
using Whitelagon.Application.Common;

namespace Whitelagon.Infrastructure.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private ApplicationDbcontext db;

        public VillaRepository(ApplicationDbcontext _Db) : base(_Db)
        {
            db = _Db;
        }

        public void Add(Villa Entity)
        {
            db.Add(Entity);
        }

        public Villa Get(Expression<Func<Villa, bool>>? filter, string? includeproperties = null)
        {
            IQueryable<Villa> query = db.Set<Villa>();
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

        public IEnumerable<Villa> GetAll(Expression<Func<Villa, bool>>? filter=null, string? includeproperties=null)
        {
            IQueryable<Villa> query = db.Set<Villa>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeproperties))
            {
                //Villa
                foreach (var includeproperty in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeproperty.Trim());
                }
            }
            return query.ToList();
        }

        public void Remove(Villa Entity)
        {
            db.Remove(Entity);
        }

        public void Save()
        {
            db.SaveChanges();
        }
            public void Update(Villa Entity)
            {
                db.Update(Entity);
            }
        }
    } 
