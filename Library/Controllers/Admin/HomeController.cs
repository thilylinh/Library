using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            //count books được mượn trong tháng

            //count số lượt mượn sách trong tháng
            ViewBag.SoLuotMuon = _dataContext.MuonTras.Where(m => m.NgayMuon.Month == DateTime.Now.Month).Count();
            //count 
            return View();
        }
    }
}
