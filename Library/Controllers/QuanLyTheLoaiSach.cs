using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class QuanLyTheLoaiSach : Controller
    {
        private readonly DataContext _dataContext;

        public QuanLyTheLoaiSach(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var tl = await _dataContext.TheLoais.ToListAsync();
            return View(tl);
        }

        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(TheLoai tl)
        {
            var tg = _dataContext.TheLoais.Where(m => m.TenTheLoai.Contains(tl.TenTheLoai) == true);

            if (tg.Count() > 0)
            {
                ModelState.AddModelError("", "Đã tồn tại thể loại " + tl.TenTheLoai + " trong hệ thống!");
                return View();
            }

            if (ModelState.IsValid)
            {
                _dataContext.Add(tl);
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
            var tl = await _dataContext.TheLoais.FirstOrDefaultAsync(s => s.Ma == id);
            return View(tl);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edittl(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tlToUpdate = await _dataContext.TheLoais.FirstOrDefaultAsync(s => s.Ma == id);

            if (await TryUpdateModelAsync<TheLoai>(
        tlToUpdate,
        "",
        s => s.TenTheLoai))
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
            return View(tlToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            var tg = await _dataContext.TheLoais.FindAsync(id);
            if (tg == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _dataContext.TheLoais.Remove(tg);
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