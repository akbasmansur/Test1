using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taste.DataAccess.Data.Repository.IRepository;

namespace Taste.DataAccess.Data.Repository {
    class UnitOfWork:IUnitOfWork {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) {
            _db=db;
            Category=new CategoryRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public void Dispose() {
            _db.Dispose();
        }

        public void Save() {
            _db.SaveChanges();
        }
    }
}
