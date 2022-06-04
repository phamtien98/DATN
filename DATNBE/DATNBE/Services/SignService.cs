using BitMiracle.Docotic.Pdf;

namespace DATNBE.Services
{
    public class SignService : IServices
    {

        public string Sign(IFormFile formFile1, IFormFile formFile2, IFormFile formFile3, string reason, string location)
        {
            BitMiracle.Docotic.LicenseManager.AddLicenseData("52Y92-XZ9EM-JKYA5-CJJBY-DX6LV");
            var path1 = Path.Combine("PDFFile", formFile1.FileName);
            var path2 = Path.Combine("CertFile", formFile2.FileName);
            var path3 = Path.Combine("HandWritting", formFile3.FileName);
            using (PdfDocument pdf = new PdfDocument(path1))
            {
                // IMPORTANT:
                // Replace "keystore.p12" and "password" with your own .p12 or .pfx path and password.
                // Without the change the sample will not work.

                PdfSignatureField field = pdf.Pages[0].AddSignatureField(20, 20, 100, 50);
             //   field.BackgroundColor = new PdfGrayColor(80);
                PdfSigningOptions options = new PdfSigningOptions(path2, "1")
                {
                    DigestAlgorithm = PdfDigestAlgorithm.Sha256,
                    Format = PdfSignatureFormat.Pkcs7Detached,
                    Field = field,
                    Reason = reason,
                    Location = location,
                    ContactInfo = "support@example.com",
                };

                PdfSignatureAppearanceOptions appearance = options.Appearance;
                appearance.IncludeDate = false;
                appearance.IncludeDistinguishedName = false;

                appearance.Image = pdf.AddImage(path3);
                appearance.Font = pdf.AddFont(PdfBuiltInFont.Courier);
                appearance.FontSize = 0; // calculate font size automatically
                appearance.FontColor = new PdfRgbColor(0, 0, 255);
                appearance.TextAlignment = PdfSignatureTextAlignment.Left;

                appearance.NameLabel = "Signed by:";
                appearance.ReasonLabel = "Reason:";
                appearance.LocationLabel = "Local:";
                appearance.IncludeDate = true;
                var filePath = Path.Combine("SaveFile", formFile1.FileName.Substring(0, formFile1.FileName.LastIndexOf(".")) + ".signed.pdf");
                pdf.SignAndSave(options, filePath);
                return filePath;
            }
            //    PdfDocument doc = new PdfDocument();
            //    var path1 = Path.Combine("PDFFile", formFile1.FileName+ DateTime.Now.ToString("yyyyMMddss"));
            //    var path2 = Path.Combine("CertFile", formFile2.FileName+ DateTime.Now.ToString("yyyyMMddss"));
            //    var path3 = Path.Combine("HandWritting", formFile3.FileName+ DateTime.Now.ToString("yyyyMMddss"));
            //    //Load a sample PDF file
            //    doc.LoadFromFile(path1);

            //    //Load the certificate 
            //    PdfCertificate cert = new PdfCertificate(path2, "1");

            //    //Create a PdfSignature object and specify its position and size 
            //    PdfSignature signature = new PdfSignature(doc, doc.Pages[doc.Pages.Count - 1], cert, "MySignature");
            //    RectangleF rectangleF = new RectangleF(doc.Pages[0].ActualSize.Width - 340, 150, 290, 100);
            //    signature.Bounds = rectangleF;
            //    signature.Certificated = true;

            //    //Set the graphics mode to image and sign detail
            //    signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

            //    //Set the signature content 
            //    signature.NameLabel = "Signer:";
            //    signature.Name = "Tien";
            //    signature.DateLabel = "Date:";
            //    signature.Date = DateTime.Now;
            //    signature.LocationInfoLabel = "Location:";
            //    signature.LocationInfo = "USA";
            //    signature.ReasonLabel = "Reason:";
            //    signature.Reason = "I am the author";
            //    signature.DistinguishedNameLabel = "DN:";
            //    signature.DistinguishedName = signature.Certificate.IssuerName.Name;

            //    //Set the signature image source
            //   // signature.SignImageSource = PdfImage.FromFile(path3);
            //    //set the size of image
            //    Bitmap bitmap = new Bitmap((int)signature.Bounds.Width / 2, (int)signature.Bounds.Height);
            //    Image img = Image.FromFile(path3);
            //    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
            //    {
            //        g.Clear(Color.White);
            //        g.DrawImage(img, new Rectangle(0, 0, (int)signature.Bounds.Width / 2, (int)signature.Bounds.Height), new RectangleF(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            //    }
            //    PdfImage image = PdfImage.FromImage(bitmap);
            //    signature.SignImageSource = image;
            //    signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
            //    signature.SignImageLayout = SignImageLayout.None;

            //    //Set the signature font 
            //    //    signature.SignDetailsFont = new PdfTrueTypeFont(new Font("Arial Unicode MS", 12f, FontStyle.Regular));

            //    //Set the document permission to forbid changes but allow form fill
            //    signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges | PdfCertificationFlags.AllowFormFill;

            //    //Save to file 
            //    var filePath = Path.Combine("SaveFile", formFile1.FileName.Substring(0, formFile1.FileName.LastIndexOf("."))+ DateTime.Now.ToString("yyyyMMddss") + ".signed.pdf");
            //    doc.SaveToFile(filePath); 
            //    doc.Close();
            //   Spire.License.LicenseProvider.SetLicenseKey("CtOzJs2BlzPokWgBAKMfmNxjRwLa3eqzrAvKtn54UDB / dWjIyGokcs + UQuYuvMY03wX56Ox75KV + U1r5H0PR++c1zc6i8e0QIOVuhMp9Qbg5A9bJJA7e7KvC4KMINTr4jnJy / yTGFwT1aEusw144kml / 6oAttwEUoXBkDPLWGOsvNgH1iTYkTGWMXEV8Or4p4t4doNsl0Z7V5qWDKwB6sD / ZiH7l / Jum27FWevOlKIa2VG1rEKjtURYukbWXeSH54IKtmn7nmr0wKwnRgdu3q60aC / PdkxC0zX75EnbU5M6fa3pplU40f3LGOWcgZ2f + 8oI7qpPXJ8 / s7LrsxBqpQ2YGKfKuqx5ex9ALrXgjnwjcslmXPYun7flHGIkbvBsCjCpo4Ed + M658sZTGATak6gLmftEqhJ1ZZJJKFgXE5qa / TyCY7wIq1ll + z1VNhnSBZUc1RA4TwSBcFKvrZEHlj9o1WFZ1 + QqNAcnzh / n + tG48B0wHLCl6D4hroCfWMoaw / 23DRxx1WuWqfkazuz2H8ga1RC2XPs83nB7CHPFNs0sT5lsKbfA3P9jgtza5CEhfjAN / 3TiwEP / tvnTZY + VABK97veB77h4LEiVMfQXzKfhm9cNW4ft / ofVU2OfqZ8GjtntoZdPxp1bIwTvI98SnQi / H81w19aHwUqNECTeJBjqqHMxdVKVSBAKJL0TM7RyzoOPKS19OfURAxlEgRUqJF / BM8eU0R + UicIM2h36sTuBKO4g3H6woDMlnx0QG0nqthauTB7oK6QFTwk44UQ1kTAu8LeOJwM2xNu5MLsPmoWwDvmIaTuZIW6VUX8C285c9KkrYAf79YKA3e3yxx6SSQdN / jLbtR7MaeGpxRzX0iEbqL9sG1m5USuYVByvVKQ4ntvfCMlLmUN9UCvJ / m63K27Z2dm6fTXIe / g0smYmnvEQ3JQVnldWOi1TKOMK8RbuU5un5mQZ96pLq0Q7g0NLQZh50UMT + OjAzXHPxmXfV6 / deHeE8Gbb3ZYJSg7UXW2sty86uXwkj89x5yJTaMNtm6Kh2QQugn / Vd9n8C8QReNewYxjF827FBpMp9yf + vLf2FSyA50wiA9o9luoXYgRmGuUh + g9 + KMWgMK5fxQ2h3cHqADzPcwsDhVfG6HuAgt81vH / M5hFLdQztXdvRKVuYOyyTOnQz9K93LZ2EvbeWz0YByRkGxnve + K8UNo3pyNgaPGRQWr5RbeURNJ4PhmM3dB2oMkwE//+s39ccgADdEJS8s35cjRrVEGs8JicRu6mDNqJfdHUNfLmiySMjG/ePwhYkiB2WhJ9AqpY9N7eQ3TBsAMkr34olS6eSNpaE1BjgJsljB27GDnmMAXNZeifyIYpBcqu6H9SLN5pGBF9WHcPVivjdNpMUrKQ==");


        }

        public void SaveCertFile(IFormFile formFile)
        {
            if (formFile != null)
            {
                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "CertFile", formFile.FileName + DateTime.Now.ToString("yyyyMMddss"));

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
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "PDFFile", formFile.FileName);

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
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "HandWritting", formFile.FileName + DateTime.Now.ToString("yyyyMMddss"));

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
        }

        public string Encrypt(IFormFile formFile1, IFormFile formFile2, IFormFile formFile3)
        {
            BitMiracle.Docotic.LicenseManager.AddLicenseData("52Y92-XZ9EM-JKYA5-CJJBY-DX6LV");

            var path1 = Path.Combine("PDFFile", formFile1.FileName);

            using (PdfDocument pdf = new PdfDocument(path1))
            {

                PdfPublicKeyEncryptionHandler handler = createEncryptionHandler(formFile2, formFile3);
                handler.Algorithm = PdfEncryptionAlgorithm.Aes256Bit;
                handler.Algorithm = PdfEncryptionAlgorithm.Aes128Bit;
                handler.Algorithm = PdfEncryptionAlgorithm.Standard40Bit;
                handler.Algorithm = PdfEncryptionAlgorithm.Standard128Bit;





                var saveOptions = new PdfSaveOptions { EncryptionHandler = handler };
                var pathToFile = Path.Combine("SaveFile", formFile1.FileName.Substring(0, formFile1.FileName.LastIndexOf(".")) + ".encrypted.pdf");
                pdf.Save(pathToFile, saveOptions);
                return pathToFile;
            }
        }

        private PdfPublicKeyEncryptionHandler createEncryptionHandler(IFormFile formFile, IFormFile formFile1)
        {

            string keyStoreOwner = Path.Combine("CertFile", formFile.FileName);
            string passwordOwner = "1";
            string keyStoreUser = Path.Combine("CertFile", formFile1.FileName);
            string passwordUser = "1";

            PdfPublicKeyEncryptionHandler handler = new PdfPublicKeyEncryptionHandler(keyStoreOwner, passwordOwner);


            PdfPermissions permissions = new PdfPermissions();
            permissions.Flags = PdfPermissionFlags.FillFormFields | PdfPermissionFlags.PrintDocument | PdfPermissionFlags.ExtractContents;
            handler.AddRecipient(keyStoreUser, passwordUser, permissions);

            return handler;
        }

        public string VerifySignature(IFormFile formFile1)
        {
            var path = Path.Combine("PDFFile", formFile1.FileName);
            using (var pdf = new PdfDocument(path))
            {
                PdfControl field = pdf.GetControls().FirstOrDefault(c => c.Type == PdfWidgetType.Signature);
                if (field == null)
                {
                    Console.WriteLine("Document does not contain signature fields", "Verification result");
                    return null;
                }

                PdfSignature signature = ((PdfSignatureField)field).Signature;
                PdfSignatureContents contents = signature.Contents;
                Console.WriteLine("Signed part is intact: {0}", contents.VerifyDigest());

                DateTime signingTime = signature.SigningTime ?? DateTime.MinValue;
                Console.WriteLine("Signed on: {0}\n", signingTime.ToShortDateString());

                if (contents.CheckHasEmbeddedOcsp())
                {
                    Console.WriteLine("Signature has OCSP embedded.");
                    return checkRevocation(signature, PdfCertificateRevocationCheckMode.EmbeddedOcsp);
                }

                if (contents.CheckHasEmbeddedCrl())
                {
                    Console.WriteLine("Signature has CRL embedded.");
                    return checkRevocation(signature, PdfCertificateRevocationCheckMode.EmbeddedCrl);
                }

                checkRevocation(signature, PdfCertificateRevocationCheckMode.OnlineOcsp);
                checkRevocation(signature, PdfCertificateRevocationCheckMode.OnlineCrl);

                if (contents.Timestamp != null)
                {
                    Console.WriteLine("Signature has timestamp embedded.");
                    Console.WriteLine("Timestamp: {0}", contents.Timestamp);
                    Console.WriteLine("Timestamp is intact: {0}", contents.VerifyTimestamp());
                }
            }
            return null;


        }
        private static string checkRevocation(PdfSignature signature, PdfCertificateRevocationCheckMode mode)
        {
            PdfSignatureContents contents = signature.Contents;
            DateTime signingTime = signature.SigningTime ?? DateTime.MinValue;

            var text = "";
            foreach (DateTime time in new DateTime[] { signingTime, DateTime.UtcNow })
            {
                bool revoked = contents.CheckIfRevoked(mode, time);
                string status = revoked ? "Revoked" : "Valid";
                string date = time.ToShortDateString();
                text = "Checking using {0} mode: {1} on {2}" + mode + status + date;
            }
            return text;
        }
    }
}
