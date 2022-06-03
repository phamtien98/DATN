using System;
using System.Collections.Generic;

namespace DATNBE.Models
{
    public partial class TaiKhoan
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Certificate { get; set; } = null!;
        public string Passcertificate { get; set; } = null!;
        public string Apikey { get; set; } = null!;
    }
}
