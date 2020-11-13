using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class QuanLyTacGia : Controller
    {
        private readonly DataContext _dataContext;
        public QuanLyTacGia(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(TacGia tacGia)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(tacGia);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
