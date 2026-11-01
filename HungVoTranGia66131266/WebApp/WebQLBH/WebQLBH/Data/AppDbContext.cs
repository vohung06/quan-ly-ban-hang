using Microsoft.EntityFrameworkCore;
using WebQLBH.Models;

namespace WebQLBH.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>opts): base(opts) { }

        //1. Lập trình các hàm thao tác trên bảng DonViTinh
        public DbSet<DonViTinh> DonViTinhs { get; set; }
        public List<DonViTinh> DonViTinh_DS()
        {
            return DonViTinhs.FromSqlRaw("EXEC DonViTinh_DS").ToList();
        }
    }
}
