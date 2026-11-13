
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLBH.Models;
using WebQLBH.Data;

public class NhomSPsController : Controller
{
    private readonly AppDbContext _context;

    public NhomSPsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: NHOMSPS
    public async Task<IActionResult> Index()    
    {
        return View(_context.NhomSP_DS());
    }

    // GET: NHOMSPS/Details/5
    public async Task<IActionResult> Details(NhomSP nsp)
    {
        return View(_context.NhomSP_CT(nsp.MaNSP));
    }

    // GET: NHOMSPS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NHOMSPS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("MaNSP,TenNSP")] NhomSP nsp)
    {
        _context.NhomSP_Them(nsp);
        return RedirectToAction(nameof(Index));
    }

    // GET: NHOMSPS/Edit/5
    public async Task<IActionResult> Edit(NhomSP nsp)
    {
        return View(_context.NhomSP_CT(nsp.MaNSP));
    }

    // POST: NHOMSPS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("MaNSP,TenNSP")] NhomSP nsp)
    {
        _context.NhomSP_Sua(nsp);
        return RedirectToAction(nameof(Index));
    }

    // GET: NHOMSPS/Delete/5
    public async Task<IActionResult> Delete(NhomSP nsp)
    {
        return View(_context.NhomSP_CT(nsp.MaNSP));
    }

    // POST: NHOMSPS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(NhomSP nsp)
    {
        _context.NhomSP_Xoa(nsp.MaNSP);
        return RedirectToAction(nameof(Index));
    }

    private bool NhomSPExists(byte? mansp)
    {
        return _context.NhomSPs.Any(e => e.MaNSP == mansp);
    }
}
