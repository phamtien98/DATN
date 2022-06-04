
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
        public IActionResult Add( IFormFile formFile1, IFormFile formFile2, IFormFile formFile3, string reason, string location)
        {
            _services.SavePDFFile(formFile1);
            _services.SaveCertFile(formFile2);
            _services.SaveHandWritting(formFile3);
            string filePath = _services.Sign( formFile1,  formFile2,  formFile3,reason,location);
            string fileName = Path.GetFileName(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/force-download", fileName);

            
        }

        [HttpPost("/api/VerifySignature")]
        public void VerifySignature (IFormFile formFile)
        {
            _services.SavePDFFile (formFile);
            _services.VerifySignature(formFile);
        }

        [HttpPost("/api/encrypt")]
        public IActionResult Encrypt(IFormFile formFile1, IFormFile formFile2, IFormFile formFile3)
        {
            _services.SavePDFFile(formFile1);
            _services.SaveCertFile(formFile2);
            _services.SaveCertFile(formFile3);
            _services.Encrypt(formFile1,formFile2,formFile3 );
            string filePath = _services.Encrypt(formFile1, formFile2,formFile3);
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
