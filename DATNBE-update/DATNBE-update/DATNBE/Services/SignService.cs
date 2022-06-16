using BitMiracle.Docotic.Pdf;
using DATNBE.DTOModel;

using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace DATNBE.Services
{
    public class SignService : IServices
    {

        //public string Sign(IFormFile pdfFile, IFormFile certFile, string password, IFormFile handwrittingFile, string name, string reason, string location)
        //{
        // //   BitMiracle.Docotic.LicenseManager.AddLicenseData("52Y92-XZ9EM-JKYA5-CJJBY-DX6LV");
        //    var path1 = Path.Combine("wwwroot/PDFFile", pdfFile.FileName);
        //    var path2 = Path.Combine("wwwroot/CertFile", certFile.FileName);
        //    var path3 = Path.Combine("wwwroot/HandWritting", handwrittingFile.FileName);
        //    //using (PdfDocument pdf = new PdfDocument(path1))
        //    //{
        //    //    // IMPORTANT:
        //    //    // Replace "keystore.p12" and "password" with your own .p12 or .pfx path and password.
        //    //    // Without the change the sample will not work.

        //    //    PdfSignatureField field = pdf.Pages[0].AddSignatureField(20, 20, 100, 50);
        //    //    //   field.BackgroundColor = new PdfGrayColor(80);
        //    //    PdfSigningOptions options = new PdfSigningOptions(path2, password)
        //    //    {
        //    //        DigestAlgorithm = PdfDigestAlgorithm.Sha256,
        //    //        Format = PdfSignatureFormat.Pkcs7Detached,
        //    //        Field = field,
        //    //        Reason = reason,
        //    //        Location = location,
        //    //        ContactInfo = "support@actvn.edu.vn",
        //    //    };

        //    //    PdfSignatureAppearanceOptions appearance = options.Appearance;
        //    //    appearance.IncludeDate = false;
        //    //    appearance.IncludeDistinguishedName = false;

        //    //    appearance.Image = pdf.AddImage(path3);
        //    //    appearance.Font = pdf.AddFont(PdfBuiltInFont.Courier);
        //    //    appearance.FontSize = 0; // calculate font size automatically
        //    //    appearance.FontColor = new PdfRgbColor(0, 0, 255);
        //    //    appearance.TextAlignment = PdfSignatureTextAlignment.Left;

        //    //    appearance.NameLabel = "Signed by:";
        //    //    appearance.ReasonLabel = "Reason:";
        //    //    appearance.LocationLabel = "Local:";
        //    //    appearance.IncludeDate = true;
        //    //    var filePath = Path.Combine("wwwroot/SaveFile", pdfFile.FileName.Substring(0, pdfFile.FileName.LastIndexOf(".")) + ".signed.pdf");
        //    //    pdf.SignAndSave(options, filePath);
        //    //    return filePath.Substring(7);

        //    PdfDocument doc = new PdfDocument();
        //    //    var path1 = Path.Combine("PDFFile", formFile1.FileName+ DateTime.Now.ToString("yyyyMMddss"));
        //    //    var path2 = Path.Combine("CertFile", formFile2.FileName+ DateTime.Now.ToString("yyyyMMddss"));
        //    //    var path3 = Path.Combine("HandWritting", formFile3.FileName+ DateTime.Now.ToString("yyyyMMddss"));
        //        //Load a sample PDF file
        //        doc.LoadFromFile(path1);

        //        //Load the certificate 
        //        PdfCertificate cert = new PdfCertificate(path2, password);

        //    //Create a PdfSignature object and specify its position and size 
        //    Spire.Pdf.Security.PdfSignature signature = new PdfSignature(doc, doc.Pages[doc.Pages.Count - 1], cert, "MySignature");
        //        RectangleF rectangleF = new RectangleF(doc.Pages[0].ActualSize.Width - 340, 150, 290, 100);
        //        signature.Bounds = rectangleF;
        //        signature.Certificated = true;

        //        //Set the graphics mode to image and sign detail
        //        signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

        //        //Set the signature content 
        //        signature.NameLabel = "Signer:";
        //        signature.Name = name;
        //        signature.DateLabel = "Date:";
        //        signature.Date = DateTime.Now;
        //        signature.LocationInfoLabel = "Location:";
        //        signature.LocationInfo = location;
        //        signature.ReasonLabel = "Reason:";
        //        signature.Reason = reason;


        //        //Set the signature image source
        //        signature.SignImageSource = PdfImage.FromFile(path3);
        //        //set the size of image
        //        Bitmap bitmap = new Bitmap((int)signature.Bounds.Width / 2, (int)signature.Bounds.Height);
        //        Image img = Image.FromFile(path3);
        //        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
        //        {
        //            g.Clear(Color.White);
        //            g.DrawImage(img, new Rectangle(0, 0, (int)signature.Bounds.Width / 2, (int)signature.Bounds.Height), new RectangleF(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
        //        }
        //        signature.SignImageSource = image;
        //        signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
        //        signature.SignImageLayout = SignImageLayout.None;

        //        //Set the signature font 
        //            signature.SignDetailsFont = new PdfTrueTypeFont(new Font("Arial Unicode MS", 12f, FontStyle.Regular));

        //        signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges | PdfCertificationFlags.AllowFormFill;

        //    //    //Save to file 
        //        var filePath = Path.Combine("SaveFile", pdfFile.FileName.Substring(0, pdfFile.FileName.LastIndexOf(".")) + ".signed.pdf");
        //        doc.SaveToFile(filePath); 
        //        doc.Close();
        //    return filePath.Substring(7);

        //       Spire.License.LicenseProvider.SetLicenseKey("CtOzJs2BlzPokWgBAKMfmNxjRwLa3eqzrAvKtn54UDB / dWjIyGokcs + UQuYuvMY03wX56Ox75KV + U1r5H0PR++c1zc6i8e0QIOVuhMp9Qbg5A9bJJA7e7KvC4KMINTr4jnJy / yTGFwT1aEusw144kml / 6oAttwEUoXBkDPLWGOsvNgH1iTYkTGWMXEV8Or4p4t4doNsl0Z7V5qWDKwB6sD / ZiH7l / Jum27FWevOlKIa2VG1rEKjtURYukbWXeSH54IKtmn7nmr0wKwnRgdu3q60aC / PdkxC0zX75EnbU5M6fa3pplU40f3LGOWcgZ2f + 8oI7qpPXJ8 / s7LrsxBqpQ2YGKfKuqx5ex9ALrXgjnwjcslmXPYun7flHGIkbvBsCjCpo4Ed + M658sZTGATak6gLmftEqhJ1ZZJJKFgXE5qa / TyCY7wIq1ll + z1VNhnSBZUc1RA4TwSBcFKvrZEHlj9o1WFZ1 + QqNAcnzh / n + tG48B0wHLCl6D4hroCfWMoaw / 23DRxx1WuWqfkazuz2H8ga1RC2XPs83nB7CHPFNs0sT5lsKbfA3P9jgtza5CEhfjAN / 3TiwEP / tvnTZY + VABK97veB77h4LEiVMfQXzKfhm9cNW4ft / ofVU2OfqZ8GjtntoZdPxp1bIwTvI98SnQi / H81w19aHwUqNECTeJBjqqHMxdVKVSBAKJL0TM7RyzoOPKS19OfURAxlEgRUqJF / BM8eU0R + UicIM2h36sTuBKO4g3H6woDMlnx0QG0nqthauTB7oK6QFTwk44UQ1kTAu8LeOJwM2xNu5MLsPmoWwDvmIaTuZIW6VUX8C285c9KkrYAf79YKA3e3yxx6SSQdN / jLbtR7MaeGpxRzX0iEbqL9sG1m5USuYVByvVKQ4ntvfCMlLmUN9UCvJ / m63K27Z2dm6fTXIe / g0smYmnvEQ3JQVnldWOi1TKOMK8RbuU5un5mQZ96pLq0Q7g0NLQZh50UMT + OjAzXHPxmXfV6 / deHeE8Gbb3ZYJSg7UXW2sty86uXwkj89x5yJTaMNtm6Kh2QQugn / Vd9n8C8QReNewYxjF827FBpMp9yf + vLf2FSyA50wiA9o9luoXYgRmGuUh + g9 + KMWgMK5fxQ2h3cHqADzPcwsDhVfG6HuAgt81vH / M5hFLdQztXdvRKVuYOyyTOnQz9K93LZ2EvbeWz0YByRkGxnve + K8UNo3pyNgaPGRQWr5RbeURNJ4PhmM3dB2oMkwE//+s39ccgADdEJS8s35cjRrVEGs8JicRu6mDNqJfdHUNfLmiySMjG/ePwhYkiB2WhJ9AqpY9N7eQ3TBsAMkr34olS6eSNpaE1BjgJsljB27GDnmMAXNZeifyIYpBcqu6H9SLN5pGBF9WHcPVivjdNpMUrKQ==");


        //}

        public void SaveCertFile(IFormFile formFile)
        {
            if (formFile != null)
            {
                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CertFile", formFile.FileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
        }

        public void SavePDFFile(IFormFile formFile)
        {
            if (formFile != null)
            {

                //Set Key Name
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFFile", formFile.FileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
        }
        public void SaveHandWritting(IFormFile formFile)
        {
            if (formFile != null)
            {

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/HandWritting", formFile.FileName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
        }

        public string Encrypt(IFormFile pdfFile, IFormFile CertOwner, string passOwner, IFormFile CertUser, int number, Permission inPermisson)
        {
            BitMiracle.Docotic.LicenseManager.AddLicenseData("52Y92-XZ9EM-JKYA5-CJJBY-DX6LV");

            var path1 = Path.Combine("wwwroot/PDFFile", pdfFile.FileName);

            using (PdfDocument pdf = new PdfDocument(path1))
            {

                PdfPublicKeyEncryptionHandler handler = createEncryptionHandler(CertOwner,passOwner, CertUser, inPermisson);
                switch (number)
                {
                    case 1:
                        handler.Algorithm = PdfEncryptionAlgorithm.Aes256Bit;
                        break;
                    case 2:
                        handler.Algorithm = PdfEncryptionAlgorithm.Aes128Bit;
                        break;
                    case 3:
                        handler.Algorithm = PdfEncryptionAlgorithm.Standard128Bit;
                        break;
                    case 4:
                        handler.Algorithm = PdfEncryptionAlgorithm.Standard40Bit;
                        break;
                    default:
                        break;
                }

                var saveOptions = new PdfSaveOptions { EncryptionHandler = handler };
                var pathToFile = Path.Combine("wwwroot/SaveFile", pdfFile.FileName.Substring(0, pdfFile.FileName.LastIndexOf(".")) + ".encrypted.pdf");
                pdf.Save(pathToFile, saveOptions);
                return pathToFile;
            }
        }

        private PdfPublicKeyEncryptionHandler createEncryptionHandler(IFormFile CertOwner, string passOwner, IFormFile CertUser, Permission inPermisson)
        {

            string keyStoreOwner = Path.Combine("wwwroot/CertFile", CertOwner.FileName);
            string passwordOwner = passOwner;
            string keyStoreUser = Path.Combine("wwwroot/CertFile", CertUser.FileName);
      //      string passwordUser = passUser;

            PdfPublicKeyEncryptionHandler handler = new PdfPublicKeyEncryptionHandler(keyStoreOwner, passwordOwner);


            PdfPermissions permissions = new PdfPermissions
            {
                AllowEverything = inPermisson.AllowEverything,

                /// đoạn này đây
                AssembleDocument = inPermisson.AssembleDocument,
                CopyContents = inPermisson.CopyContents,
                ExtractContents = inPermisson.ExtractContents,
                ModifyContents = inPermisson.ModifyContents,
                PrintDocument = inPermisson.PrintDocument,
                PrintFaithfulCopy = inPermisson.PrintFaithfulCopy
            };

            X509Certificate2 cer = new X509Certificate2(keyStoreUser);
       //     X509Certificate2 cer = new X509Certificate2(keyStoreUser);
            handler.AddRecipient(cer, permissions);

            return handler;
        }

        //public string VerifySignature(IFormFile formFile1)
        //{
        //    var path = Path.Combine("wwwroot/PDFFile", formFile1.FileName);
        //    StringBuilder sb = new StringBuilder();
        //    using (PdfDocument pdf = new PdfDocument(path))
        //    {
        //        PdfControl field = pdf.GetControls().FirstOrDefault(c => c.Type == PdfWidgetType.Signature);
        //        if (field == null)
        //        {
        //            return "Document does not contain signature fields";

        //        }

        //        PdfSignature signature = ((PdfSignatureField)field).Signature;
        //        PdfSignatureContents contents = signature.Contents;
        //        sb.AppendFormat("Signed part is intact: {0}\n", contents.VerifyDigest() + "\n");

        //        DateTime signingTime = signature.SigningTime ?? DateTime.MinValue;
        //        sb.AppendFormat("Signed on: {0}\n", signingTime.ToShortDateString());

        //        var timestampToken = contents.GetTimestampToken();
        //        if (timestampToken != null)
        //        {
        //            sb.AppendFormat("Embedded timestamp: {0}\n", timestampToken.GenerationTime);
        //            if (timestampToken.TimestampAuthority != null)
        //                sb.AppendFormat("Timestamp authority: {0}\n", timestampToken.TimestampAuthority.Name);
        //            sb.AppendFormat("Timestamp is intact: {0}\n\n", contents.VerifyTimestamp());
        //        }
        //        else
        //        {
        //            sb.AppendLine();
        //        }

        //        if (contents.CheckHasEmbeddedOcsp())
        //        {
        //            sb.AppendLine("Signature has OCSP embedded.");
        //            checkRevocation(signature, sb, PdfCertificateRevocationCheckMode.EmbeddedOcsp);
        //        }

        //        if (contents.CheckHasEmbeddedCrl())
        //        {
        //            sb.AppendLine("Signature has CRL embedded.");
        //            checkRevocation(signature, sb, PdfCertificateRevocationCheckMode.EmbeddedCrl);
        //        }

        //        checkRevocation(signature, sb, PdfCertificateRevocationCheckMode.OnlineOcsp);
        //        checkRevocation(signature, sb, PdfCertificateRevocationCheckMode.OnlineCrl);

        //        PdfControl control = pdf.GetControls().FirstOrDefault(c => c.Type == PdfWidgetType.Signature);
        //        if (control == null)
        //        {
        //            return "Document does not contain signature fields";

        //        }

        //        PdfSignatureField field1 = (PdfSignatureField)control;
        //        sb.AppendFormat("Signature field is invisible: {0}\n", isInvisible(field1));

        //        PdfSignature signatur1e = field1.Signature;
        //        sb.AppendFormat("Signed by: {0}\n", signature.Name);
        //        sb.AppendFormat("Signing time: {0}\n", signature.SigningTime);
        //        sb.AppendFormat("Signed at: {0}\n", signature.Location);
        //        sb.AppendFormat("Reason for signing: {0}\n", signature.Reason);
        //        sb.AppendFormat("Signer's contact: {0}\n", signature.ContactInfo);

        //        PdfSignatureContents contents1 = signature.Contents;
        //        sb.AppendFormat("Has OCSP embedded: {0}\n", contents.CheckHasEmbeddedOcsp());
        //        sb.AppendFormat("Has CRL embedded: {0}\n", contents.CheckHasEmbeddedCrl());

        //        PdfSignatureCertificate certificate = contents.GetSigningCertificate();
        //        sb.AppendLine();
        //        sb.AppendLine("== Signing certificate:");
        //        sb.AppendFormat("Name: {0}\n", certificate.Name);
        //        sb.AppendFormat("Algorithm: {0}\n", certificate.AlgorithmName);
        //        sb.AppendFormat("Subject DN: {0}\n", certificate.Subject.Name);
        //        sb.AppendFormat("Issuer DN: {0}\n", certificate.Issuer.Name);
        //        sb.AppendFormat("Serial number: {0}\n", certificate.SerialNumber);
        //        sb.AppendFormat("Valid from {0} up to {1}\n", certificate.ValidFrom, certificate.ValidUpto);
        //        sb.AppendFormat("Timestamp Authority URL: {0}\n", certificate.GetTimestampAuthorityUrl());

        //        PdfSignatureCertificate issuer = contents.GetIssuerCertificateFor(certificate);
        //        sb.AppendLine();
        //        sb.AppendLine("== Issuer certificate:");
        //        sb.AppendFormat("Subject DN: {0}\n", issuer.Subject.Name);
        //        sb.AppendFormat("Issuer DN: {0}\n", issuer.Issuer.Name);
        //        sb.AppendFormat("Serial number: {0}\n", issuer.SerialNumber);

        //    }
        //    return sb.ToString();
        //}
        private static bool isInvisible(PdfSignatureField field)
        {
            return (field.Width == 0 && field.Height == 0) ||
                    field.Flags.HasFlag(PdfWidgetFlags.Hidden) ||
                    field.Flags.HasFlag(PdfWidgetFlags.NoView);
        }
        private static string checkRevocation(PdfSignature signature, StringBuilder sb, PdfCertificateRevocationCheckMode mode)
        {
            PdfSignatureContents contents = signature.Contents;
            DateTime signingTime = signature.SigningTime ?? DateTime.MinValue;

            foreach (DateTime time in new DateTime[] { signingTime, DateTime.UtcNow })
            {
                bool revoked = contents.CheckIfRevoked(mode, time);
                string status = revoked ? "Revoked" : "Valid";
                string date = time.ToShortDateString();
                sb.AppendFormat("Checking using {0} mode: {1} on {2}\n", mode, status, date);
            }

            sb.AppendLine();
            return sb.ToString();
        }

        public string Decrypt(IFormFile pdfFile, IFormFile certFile, string password)
        {
            try
            {
                var keyStore =  Path.Combine("wwwroot/CertFile", certFile.FileName);
                var encryptedFile = Path.Combine("wwwroot/PDFFile", pdfFile.FileName);
                PdfPublicKeyDecryptionHandler handler = new PdfPublicKeyDecryptionHandler(keyStore, password);
                using (PdfDocument pdf = new PdfDocument(encryptedFile, handler))
                {
                    var filePath = Path.Combine("wwwroot/SaveFile", pdfFile.FileName.Substring(0, pdfFile.FileName.LastIndexOf(".")) + ".decrypt.pdf");
                    pdf.Save(filePath);
                    return filePath;
                }
            }
            catch (PdfException ex)
            {
                return ex.ToString();
            }
        }
    }
        
    }
