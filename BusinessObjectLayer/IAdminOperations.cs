using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer
{
     public interface IAdminOperations
    {
        void AddAdmin(AdminLogin admin);
        IEnumerable<AdminLogin> Get();

    }
}
