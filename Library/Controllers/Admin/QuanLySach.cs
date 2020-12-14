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
            var list = _dataContext.Saches.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew(Sach sach)
        {
            var tg = _dataContext.Saches.Where(m => m.MaSach.Contains(sach.MaSach) == true);
            if (tg.Count() > 0)
            {
                ModelState.AddModelError("", "Đã tồn tại mã sách( " + sach.MaSach + " ) trong hệ thống!");
                return View();
            }
            sach.NgayNhapKho = DateTime.Now;
            if (ModelState.IsValid)
            {
                _dataContext.Saches.Add(sach);
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
        s => s.TenSach, s => s.TacGia, s => s.TheLoai, s => s.NhaXuatBan, s => s.NamXuatBan,s=>s.SoLuong))
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
