
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLBH.Models;
using WebQLBH.Data;

public class DonViTinhsController : Controller
{
    private readonly AppDbContext _context;

    public DonViTinhsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: DONVITINHS
    public async Task<IActionResult> Index()    
    {
        return View(_context.DonViTinh_DS());
    }

    // GET: DONVITINHS/Details/5
    public async Task<IActionResult> Details(byte? madvt)
    {
        return View(_context.DonViTinh_DS());
    }

    // GET: DONVITINHS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DONVITINHS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaDVT,TenDVT")] DonViTinh donvitinh)
    {
        if (ModelState.IsValid)
        {
            _context.Add(donvitinh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(donvitinh);
    }

    // GET: DONVITINHS/Edit/5
    public async Task<IActionResult> Edit(byte? madvt)
    {
        if (madvt == null)
        {
            return NotFound();
        }

        var donvitinh = await _context.DonViTinhs.FindAsync(madvt);
        if (donvitinh == null)
        {
            return NotFound();
        }
        return View(donvitinh);
    }

    // POST: DONVITINHS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(byte? madvt, [Bind("MaDVT,TenDVT")] DonViTinh donvitinh)
    {
        if (madvt != donvitinh.MaDVT)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(donvitinh);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonViTinhExists(donvitinh.MaDVT))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(donvitinh);
    }

    // GET: DONVITINHS/Delete/5
    public async Task<IActionResult> Delete(byte? madvt)
    {
        if (madvt == null)
        {
            return NotFound();
        }

        var donvitinh = await _context.DonViTinhs
            .FirstOrDefaultAsync(m => m.MaDVT == madvt);
        if (donvitinh == null)
        {
            return NotFound();
        }

        return View(donvitinh);
    }

    // POST: DONVITINHS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(byte? madvt)
    {
        var donvitinh = await _context.DonViTinhs.FindAsync(madvt);
        if (donvitinh != null)
        {
            _context.DonViTinhs.Remove(donvitinh);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DonViTinhExists(byte? madvt)
    {
        return _context.DonViTinhs.Any(e => e.MaDVT == madvt);
    }
}
