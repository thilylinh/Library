using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers.Admin
{
    public class ThongBaoTinTuc : Controller
    {
        private readonly DataContext _dataContext;
        public ThongBaoTinTuc(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var tb = _dataContext.ThongBaos.ToList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var s = await _dataContext.ThongBaos.FirstOrDefaultAsync(s => s.ID == id);
            return View(s);
        }
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNew(ThongBao tb)
        {
            tb.NhanVienMa = 1;
            tb.NgayThongBao = DateTime.Now;
            if (ModelState.IsValid)
            {
                _dataContext.ThongBaos.Add(tb);
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
            var s = await _dataContext.ThongBaos.FirstOrDefaultAsync(s => s.ID == id);
            return View(s);
        }
        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edits(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sToUpdate = await _dataContext.ThongBaos.FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<ThongBao>(
        sToUpdate,
        "",
        s => s.NoiDung))
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
            var tg = await _dataContext.ThongBaos.FindAsync(id);
            if (tg == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _dataContext.ThongBaos.Remove(tg);
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
