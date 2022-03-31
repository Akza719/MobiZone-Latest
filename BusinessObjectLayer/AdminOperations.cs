using DomainLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer
{
    public class AdminOperations:IAdminOperations
    {
        ProductDbContext _context;
        IRepositoryOperations<AdminLogin> _repo;
        public AdminOperations(ProductDbContext context)
        {
            _context = context;
            _repo = new RepositoryOperations<AdminLogin>(context);
        }
        public void AddAdmin(AdminLogin admin)
        {
            _repo.Add(admin);
            _repo.Save();
        }
        public IEnumerable<AdminLogin> Get()
        {
            return _repo.Get();
        }

    }
}
