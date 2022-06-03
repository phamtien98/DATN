
using System.Web.Http;
namespace DATNBE.Services
{
    public interface IServices
    {
        string Sign(IFormFile formFile1, IFormFile formFile2, IFormFile formFile3);
        string Encrypt(IFormFile formFile1, IFormFile formFile2, IFormFile formFile3);
        string VerifySignature(IFormFile formFile1);
        void SavePDFFile(IFormFile formFile);
        void SaveCertFile(IFormFile formFile);
        void SaveHandWritting(IFormFile formFile);
    }
}
