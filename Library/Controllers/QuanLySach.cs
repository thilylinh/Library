using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class QuanLySach : Controller
    {
        private readonly DataContext _dataContext;
        public QuanLySach(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var s = _dataContext.Saches.ToList();
            return View(s);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            ViewBag.TacGia = _dataContext.TacGias.ToList();
            ViewBag.NXB = _dataContext.NhaXuatBans.ToList();
            ViewBag.TheLoai = _dataContext.TheLoais.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew(Sach s)
        {
            var tg = _dataContext.Saches.Where(m => m.MaSach.Contains(s.MaSach) == true);

            if (tg.Count() > 0)
            {
                ModelState.AddModelError("", "Đã tồn tại nhà xuất bản " + s.MaSach + " trong hệ thống!");
                return View();
            }

            if (ModelState.IsValid)
            {
                _dataContext.Add(s);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var s = await _dataContext.Saches.FirstOrDefaultAsync(s => s.MaSach == id);
            return View(s);
        }
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edits(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sToUpdate = await _dataContext.Saches.FirstOrDefaultAsync(s => s.MaSach == id);

            if (await TryUpdateModelAsync<Sach>(
        sToUpdate,
        "",
        s => s.MaSach, s => s.TenSach, s => s.MatacGia, s => s.MaTheLoai, s => s.MaNhaXuatBan, s => s.NamXuatBan))
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
            return View(sToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            var tg = await _dataContext.Saches.FindAsync(id);
            if (tg == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _dataContext.Saches.Remove(tg);
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
