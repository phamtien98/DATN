using BitMiracle.Docotic.Pdf;

namespace DATNBE.Core
{
    public class EncryptionHandler
    {
        public static PdfPublicKeyEncryptionHandler createEncryptionHandler(IFormFile formFile, IFormFile formFile1)
        {


            string keyStoreOwner = Path.Combine("wwwroot/CertFile" + formFile.FileName);
            string passwordOwner = "1";
            string keyStoreUser = Path.Combine("wwwroot/CertFile" + formFile1.FileName);
            string passwordUser = "1";

            PdfPublicKeyEncryptionHandler handler = new PdfPublicKeyEncryptionHandler(keyStoreOwner, passwordOwner);


            PdfPermissions permissions = new PdfPermissions();
            permissions.Flags = PdfPermissionFlags.FillFormFields | PdfPermissionFlags.PrintDocument | PdfPermissionFlags.ExtractContents;
            handler.AddRecipient(keyStoreUser, passwordUser, permissions);

            return handler;
        }
    }
}
