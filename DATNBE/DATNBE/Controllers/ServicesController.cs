
using DATNBE.DTOModel;
using DATNBE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DATNBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServices _services;

        public ServicesController(IServices services)
        {
            _services = services;
        }
        [HttpPost("/api/sign")]
        public IActionResult Add(IFormFile pdfFile, IFormFile certFile, string password, IFormFile handwrittingFile, string name, string reason, string location)
        {
            _services.SavePDFFile(pdfFile);
            _services.SaveCertFile(certFile);
            _services.SaveHandWritting(handwrittingFile);
            string filePath = _services.Sign( pdfFile,  certFile,password,  handwrittingFile,name,reason,location);
            string fileName = Path.GetFileName(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/force-download", fileName);

            
        }

        [HttpPost("/api/VerifySignature")]
        public string VerifySignature (IFormFile pdfFile)
        {
            _services.SavePDFFile (pdfFile);
            return  _services.VerifySignature(pdfFile);
        }

        [HttpPost("/api/encrypt")]
        public IActionResult Encrypt(IFormFile pdfFile, IFormFile CertOwner, string passOwner, IFormFile CertUser, string passUser, int number)
        {
            _services.SavePDFFile(pdfFile);
            _services.SaveCertFile(CertOwner);
            _services.SaveCertFile(CertUser);
            string filePath =  _services.Encrypt(pdfFile,CertOwner,passOwner,CertUser,passUser, number);
            string fileName = Path.GetFileName(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/force-download", fileName);
        }

        [HttpPost("/api/decrypt")]
        public void Decrypt(UserDTO user, IFormFile cert)
        {

        }
    }  
}
