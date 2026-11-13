
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
    public async Task<IActionResult> Details(DonViTinh dvt)
    {
        return View(_context.DonViTinh_CT(dvt.MaDVT));
    }

    // GET: DONVITINHS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DONVITINHS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("MaDVT,TenDVT")] DonViTinh dvt)
    {
        _context.DonViTinh_Them(dvt);
        return RedirectToAction(nameof(Index));
    }

    // GET: DONVITINHS/Edit/5
    public async Task<IActionResult> Edit(DonViTinh dvt)
    {
        return View(_context.DonViTinh_CT(dvt.MaDVT));
    }

    // POST: DONVITINHS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("MaDVT,TenDVT")] DonViTinh dvt)
    {
        _context.DonViTinh_Sua(dvt);
        return RedirectToAction(nameof(Index));
    }

    // GET: DONVITINHS/Delete/5
    public async Task<IActionResult> Delete(DonViTinh dvt)
    {
        return View(_context.DonViTinh_CT(dvt.MaDVT));
    }

    // POST: DONVITINHS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(DonViTinh dvt)
    {
        _context.DonViTinh_Xoa(dvt.MaDVT);
        return RedirectToAction(nameof(Index));
    }

    private bool DonViTinhExists(byte? madvt)
    {
        return _context.DonViTinhs.Any(e => e.MaDVT == madvt);
    }
}
