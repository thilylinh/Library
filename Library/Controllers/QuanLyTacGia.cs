﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class QuanLyTacGia : Controller
    {
        private readonly DataContext _dataContext;
        public QuanLyTacGia(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var tascGia = await _dataContext.TacGias.ToListAsync();
            return View(tascGia);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew(TacGia tacGia)
        {
            var tg = _dataContext.TacGias.Where(m => m.Ten.Contains(tacGia.Ten) == true);

            if (tg.Count() > 0)
            {
                ModelState.AddModelError("", "Đã tồn tại tác giả " + tacGia.Ten + " trong hệ thống!");
                return View();
            }

            if (ModelState.IsValid)
            {
                _dataContext.Add(tacGia);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tacgia = await _dataContext.TacGias.FirstOrDefaultAsync(s => s.Ma == id);
            return View(tacgia);
        }
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditTacGia(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tacgiaToUpdate = await _dataContext.TacGias.FirstOrDefaultAsync(s => s.Ma == id);

            if (await TryUpdateModelAsync<TacGia>(
        tacgiaToUpdate,
        "",
        s => s.Ten, s => s.GhiChu))
            {
                try
                {
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Không thể thay đổi. " +
                        "Làm ơn thử lại! ");
                }
            }
            return View(tacgiaToUpdate);
        }

        public async Task<IActionResult> Delete(int? id , bool? saveChangesError = false)
        {
            var tg = await _dataContext.TacGias.FindAsync(id);
            if (tg == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _dataContext.TacGias.Remove(tg);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
