using DataAccess;
using System;

namespace BusinessLogic.DataBaseServices
{
    public abstract class DataBaseService: IDisposable
    {
        protected MenuDataContext _context;
        public DataBaseService()
        {
            _context = new MenuDataContext();
        }

        protected int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
