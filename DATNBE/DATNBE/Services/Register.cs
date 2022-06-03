using DATNBE.DTOModel;
using DATNBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DATNBE.Services
{
    public class Register : IRegister
    {
        private readonly DATNContext _dbContext;
        public Register (DATNContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RegisterAccount(UserDTO user, IFormFile cert)
        {
            var checkUser = _dbContext.TaiKhoans.Where(m => m.Username == user.Username);
            if (checkUser.Any())
            {
                _dbContext.TaiKhoans.Add(new TaiKhoan
                {
                    Username = user.Username,
                    FullName = user.FullName,
                    Password = user.Password,
                    Certificate = cert.FileName,
                    Passcertificate = user.Passcertificate,
                    Apikey = genApiKey()
                });
                SaveCertFile(cert);
                _dbContext.SaveChanges();
            }
        }
        public static string genApiKey()
        {
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            return Convert.ToBase64String(key);
        }
        public void SaveCertFile(IFormFile formFile)
        {
            if (formFile != null)
            {
                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "CertFile", formFile.FileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
        }
    }
}
