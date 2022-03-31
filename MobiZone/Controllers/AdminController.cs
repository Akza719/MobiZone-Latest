using BusinessObjectLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ProductDbContext _context;
        IAdminOperations _admin;
        public AdminController(ProductDbContext context, IAdminOperations admin)
        {
            _context = context;
            _admin = admin;

        }
        public IActionResult Get()
        {
            return new JsonResult("success");
        }
    }
}
