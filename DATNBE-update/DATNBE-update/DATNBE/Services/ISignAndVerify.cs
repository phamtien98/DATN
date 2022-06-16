namespace DATNBE.Services
{
    public interface ISignAndVerify
    {
        string Sign(IFormFile pdfFile, IFormFile certFile, string password, IFormFile handwrittingFile, string name, string reason, string location);
        string VerifySignature(IFormFile pdfFile);

    }
}
