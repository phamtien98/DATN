
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
        public ActionResult Add(IFormFile pdfFile, IFormFile certFile, string password, IFormFile handwrittingFile, string name, string reason, string location)
        {
            _services.SavePDFFile(pdfFile);
            _services.SaveCertFile(certFile);
            _services.SaveHandWritting(handwrittingFile);
            string filePath = _services.Sign( pdfFile,  certFile,password,  handwrittingFile,name,reason,location);
            //string fileName = Path.GetFileName(filePath);
            //byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            //Response.Headers.Add("Content-Disposition", "attachment;filename=a.pdf");

            //return File("~/SaveFile/Eng_CV_2021.signed.pdf", "application/pdf");
            return Ok(new
            {
                url = filePath
            });
        }

        [HttpGet("/api/sign1")]
        public ActionResult Add1()
        {

            Response.Headers.Add("Content-Disposition", "inline;filename=Eng_CV_2021.signed.pdf");

            //return File("~/SaveFile/Eng_CV_2021.signed.pdf", "application/pdf");

            return Ok(new
            {
                url = "https://localhost:7111/SaveFile/Eng_CV_2021.signed.pdf"
            });

        }

        [HttpPost("/api/VerifySignature")]
        public IActionResult VerifySignature (IFormFile formFile)
        {
            _services.SavePDFFile (formFile);
            var res = _services.VerifySignature(formFile);

            return Ok(new
            {
                message = res
            });
        }

        [HttpPost("/api/encrypt")]
        public IActionResult Encrypt(IFormFile pdfFile, IFormFile CertOwner, string passOwner, IFormFile CertUser, string passUser, int number)
        {
            _services.SavePDFFile(pdfFile);
            _services.SaveCertFile(CertOwner);
            _services.SaveCertFile(CertUser);
            string filePath = _services.Encrypt(pdfFile,CertOwner,passOwner,CertUser,passUser,number );
            string fileName = Path.GetFileName(filePath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/force-download", fileName);
        }


        [HttpPost("/api/decrypt")]
        public void Decrypt(IFormFile pdfFile, IFormFile certFile, string password)
        {
            _services.SavePDFFile (pdfFile);
            _services.SaveCertFile (certFile);
            _services.Decrypt(pdfFile, certFile, password);
        }
    }  
}
