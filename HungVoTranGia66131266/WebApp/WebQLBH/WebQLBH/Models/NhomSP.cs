using System.ComponentModel.DataAnnotations;

namespace WebQLBH.Models
{
    public class NhomSP
    {
        [Key]
        public byte MaNSP { get; set; }
        public string TenNSP { get; set; }
    }
}
