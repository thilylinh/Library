using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class QuanLyNhaXuatBan : Controller
    {
        private readonly DataContext _dataContext;
        public QuanLyNhaXuatBan(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var nxb = await _dataContext.NhaXuatBans.ToListAsync();
            return View(nxb);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew(NhaXuatBan nxb)
        {
            var tg = _dataContext.NhaXuatBans.Where(m => m.Ten.Contains(nxb.Ten) == true);

            if (tg.Count() > 0)
            {
                ModelState.AddModelError("", "Đã tồn tại nhà xuất bản " + nxb.Ten + " trong hệ thống!");
                return View();
            }

            if (ModelState.IsValid)
            {
                _dataContext.Add(nxb);
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
            var nxb = await _dataContext.NhaXuatBans.FirstOrDefaultAsync(s => s.Ma == id);
            return View(nxb);
        }
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Editnxb(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nxbToUpdate = await _dataContext.NhaXuatBans.FirstOrDefaultAsync(s => s.Ma == id);

            if (await TryUpdateModelAsync<NhaXuatBan>(
        nxbToUpdate,
        "",
        s => s.Ten, s => s.DiaChi,s=>s.Email))
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
            return View(nxbToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            var tg = await _dataContext.NhaXuatBans.FindAsync(id);
            if (tg == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _dataContext.NhaXuatBans.Remove(tg);
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
