using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace Library.Controllers.Client
{
    public class Sach : Controller
    {
        private readonly DataContext _dataContext;
        public Sach(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            var listSach = _dataContext.Saches.AsNoTracking().OrderBy(p => p.TenSach);
            var model = await PagingList.CreateAsync(listSach, 10, page);
            return View(model);
        }
    }
}
