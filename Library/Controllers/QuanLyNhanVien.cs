using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class QuanLyNhanVien : Controller
    {
        private readonly DataContext _dataContext;
        public QuanLyNhanVien(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var nv = await _dataContext.NhanViens.ToListAsync();
            return View(nv);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(nv);
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
            var nv = await _dataContext.NhanViens.FirstOrDefaultAsync(s => s.Ma == id);
            return View(nv);
        }
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Editnv(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nvToUpdate = await _dataContext.NhanViens.FirstOrDefaultAsync(s => s.Ma == id);

            if (await TryUpdateModelAsync<NhanVien>(
        nvToUpdate,
        "",
        s => s.Ten, s => s.NgaySinh, s => s.SoDienThoai,s=>s.TenDangNhap,s=>s.MatKhau))
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
            return View(nvToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            var tg = await _dataContext.NhanViens.FindAsync(id);
            if (tg == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _dataContext.NhanViens.Remove(tg);
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
