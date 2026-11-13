using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
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
        public DonViTinh? DonViTinh_CT(byte MaDVT)
        {
            var p = new[]
            {
                new SqlParameter("@MaDVT", MaDVT)
            };
            return DonViTinhs.FromSqlRaw("EXEC DonViTinh_CT @MaDVT", p).ToList().FirstOrDefault();
        }
        public int DonViTinh_Them(DonViTinh dvt)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "DonViTinh_Them";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TenDVT", dvt.TenDVT));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }
        public int DonViTinh_Sua(DonViTinh dvt)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "DonViTinh_Sua";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("MaDVT", dvt.MaDVT));
            cmd.Parameters.Add(new SqlParameter("TenDVT", dvt.TenDVT));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }
        public int DonViTinh_Xoa(byte MaDVT)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "DonViTinh_Xoa";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaDVT", MaDVT));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }


        //2. Lập trình các hàm thao tác trên bảng NhomSP
        public DbSet<NhomSP> NhomSPs {  get; set; }
        public List<NhomSP> NhomSP_DS()
        {
            return NhomSPs.FromSqlRaw("EXEC NhomSP_DS").ToList();
        }
        public NhomSP? NhomSP_CT(byte MaNSP)
        {
            var p = new[]
            {
                new SqlParameter("@MaNSP", MaNSP)
            };
            return NhomSPs.FromSqlRaw("EXEC NhomSP_CT @MaNSP", p).ToList().FirstOrDefault();
        }
        public int NhomSP_Them(NhomSP nsp)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NhomSP_Them";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TenNSP", nsp.TenNSP));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }
        public int NhomSP_Sua(NhomSP nsp)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NhomSP_Sua";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("MaNSP", nsp.MaNSP));
            cmd.Parameters.Add(new SqlParameter("TenNSP", nsp.TenNSP));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }
        public int NhomSP_Xoa(byte MaNSP)
        {
            var cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "NhomSP_Xoa";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MaNSP", MaNSP));
            Database.OpenConnection();
            var kq = cmd.ExecuteNonQuery();
            Database.CloseConnection();
            return kq;
        }
    }
}
