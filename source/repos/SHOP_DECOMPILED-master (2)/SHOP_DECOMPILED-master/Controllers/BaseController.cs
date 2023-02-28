using Lubes.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentals_mtaani_3.Controllers
{
    public class BaseController <T>: Controller where T: class
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public List<T> PaginatedResult(List<T> t, int page, int rowsPerPage)
        {
            @ViewBag.TotalRecords = t.Count;
            @ViewBag.CurrentPage = page;

            var skip = (page - 1) * rowsPerPage;

            var paginatedResult = t.Skip(skip).Take(rowsPerPage).ToList();
            return paginatedResult;
        }
    }
}
