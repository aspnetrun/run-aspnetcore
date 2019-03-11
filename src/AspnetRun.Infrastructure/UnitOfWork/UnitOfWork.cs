using AspnetRun.Core.Interfaces;
using AspnetRun.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AspnetRunContext _context;

        public UnitOfWork(AspnetRunContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
