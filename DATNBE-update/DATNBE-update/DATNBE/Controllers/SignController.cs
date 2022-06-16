
using BitMiracle.Docotic.Pdf;
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
        private readonly ISignAndVerify _signAndVerify;

        public ServicesController(IServices services , ISignAndVerify signAndVerify)
        {
            _services = services;
            _signAndVerify = signAndVerify;
        }
        [HttpPost("/api/sign")]
        public ActionResult Add(IFormFile pdfFile, IFormFile certFile, string password, IFormFile handwrittingFile, string name, string reason, string location)
        {
            _services.SavePDFFile(pdfFile);
            _services.SaveCertFile(certFile);
            _services.SaveHandWritting(handwrittingFile);
            string filePath = _signAndVerify.Sign( pdfFile,  certFile,password,  handwrittingFile,name,reason,location);
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
            var res = _signAndVerify.VerifySignature(formFile);

            return Ok(new
            {
                message = res
            });
        }

        [HttpPost("/api/encrypt")]
        public IActionResult Encrypt([FromForm] EncryptRequest request)
        {
            var permission = new Permission
            {
                IsOwner = request.IsOwner,
                AllowEverything = request.AllowEverything,
                PrintDocument = request.PrintDocument,
                ModifyContents = request.ModifyContents,
                CopyContents = request.CopyContents,
                ModifyAnnotations = request.ModifyAnnotations,
                FillFormFields = request.FillFormFields,
                ExtractContents = request.ExtractContents,
                AssembleDocument = request.AssembleDocument,
                PrintFaithfulCopy = request.PrintFaithfulCopy,

            };
            _services.SavePDFFile(request.PdfFile);
            _services.SaveCertFile(request.CertOwner);
            _services.SaveCertFile(request.CertUser);
            string filePath = _services.Encrypt(request.PdfFile, request.CertOwner, request.PassOwner, request.CertUser, request.Number, permission);

            return Ok(new
            {
                url = filePath.Substring(7)
            });
        }


        [HttpPost("/api/decrypt")]
        public ActionResult Decrypt(IFormFile pdfFile, IFormFile certFile, string password)
        {
            _services.SavePDFFile (pdfFile);
            _services.SaveCertFile (certFile);
            var filePath = _services.Decrypt(pdfFile, certFile, password);

            return Ok(new
            {
                url = filePath.Substring(7)
            });
        }
    }  
}
