
using BitMiracle.Docotic.Pdf;
using DATNBE.DTOModel;
using System.Web.Http;
namespace DATNBE.Services
{
    public interface IServices
    {
      //  string Sign(IFormFile pdfFile, IFormFile certFile, string password, IFormFile handwrittingFile, string name, string reason, string location);
        string Encrypt(IFormFile pdfFile, IFormFile CertOwner, string passOwner, IFormFile CertUser, int number, Permission inPermisson);
      //  string VerifySignature(IFormFile pdfFile);
        string Decrypt (IFormFile pdfFile, IFormFile certFile,string password);
        void SavePDFFile(IFormFile formFile);
        void SaveCertFile(IFormFile formFile);
        void SaveHandWritting(IFormFile formFile);
    }
}
