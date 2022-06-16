using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;
using Spire.Pdf.Widget;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DATNBE.Services
{
    public class SignAndVerify : ISignAndVerify
    {
        public string Sign(IFormFile pdfFile, IFormFile certFile, string password, IFormFile handwrittingFile, string name, string reason, string location)
        {
            var path1 = Path.Combine("wwwroot/PDFFile", pdfFile.FileName);
            var path2 = Path.Combine("wwwroot/CertFile", certFile.FileName);
            var path3 = Path.Combine("wwwroot/HandWritting", handwrittingFile.FileName);
            //using (PdfDocument pdf = new PdfDocument(path1))
            //{
            //    // IMPORTANT:
            //    // Replace "keystore.p12" and "password" with your own .p12 or .pfx path and password.
            //    // Without the change the sample will not work.

            //    PdfSignatureField field = pdf.Pages[0].AddSignatureField(20, 20, 100, 50);
            //    //   field.BackgroundColor = new PdfGrayColor(80);
            //    PdfSigningOptions options = new PdfSigningOptions(path2, password)
            //    {
            //        DigestAlgorithm = PdfDigestAlgorithm.Sha256,
            //        Format = PdfSignatureFormat.Pkcs7Detached,
            //        Field = field,
            //        Reason = reason,
            //        Location = location,
            //        ContactInfo = "support@actvn.edu.vn",
            //    };

            //    PdfSignatureAppearanceOptions appearance = options.Appearance;
            //    appearance.IncludeDate = false;
            //    appearance.IncludeDistinguishedName = false;

            //    appearance.Image = pdf.AddImage(path3);
            //    appearance.Font = pdf.AddFont(PdfBuiltInFont.Courier);
            //    appearance.FontSize = 0; // calculate font size automatically
            //    appearance.FontColor = new PdfRgbColor(0, 0, 255);
            //    appearance.TextAlignment = PdfSignatureTextAlignment.Left;

            //    appearance.NameLabel = "Signed by:";
            //    appearance.ReasonLabel = "Reason:";
            //    appearance.LocationLabel = "Local:";
            //    appearance.IncludeDate = true;
            //    var filePath = Path.Combine("wwwroot/SaveFile", pdfFile.FileName.Substring(0, pdfFile.FileName.LastIndexOf(".")) + ".signed.pdf");
            //    pdf.SignAndSave(options, filePath);
            //    return filePath.Substring(7);

            PdfDocument doc = new PdfDocument();
            //Load a sample PDF file
            doc.LoadFromFile(path1);

            //Load the certificate 
            PdfCertificate cert = new PdfCertificate(path2, password);

            //Create a PdfSignature object and specify its position and size 
            Spire.Pdf.Security.PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "MySignature");
            RectangleF rectangleF = new RectangleF(doc.Pages[0].ActualSize.Width - 340, 0, 290, 100);

            signature.Bounds = rectangleF;
            signature.Certificated = true;

            //Set the graphics mode to image and sign detail
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

            //Set the signature content 
            signature.NameLabel = "Signer:";
            signature.Name = name;
            signature.DateLabel = "Date:";
            signature.Date = DateTime.Now;
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = location;
            signature.ReasonLabel = "Reason:";
            signature.Reason = reason;


            //Set the signature image source
            signature.SignImageSource = PdfImage.FromFile(path3);
            //set the size of image
            Bitmap bitmap = new Bitmap((int)signature.Bounds.Width / 2, (int)signature.Bounds.Height);
            Image img = Image.FromFile(path3);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                g.DrawImage(img, new Rectangle(0, 0, (int)signature.Bounds.Width / 2, (int)signature.Bounds.Height), new RectangleF(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            }
            PdfImage image = PdfImage.FromImage(bitmap);
            signature.SignImageSource = image;
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
            signature.SignImageLayout = SignImageLayout.None;

            //Set the signature font 
            signature.SignDetailsFont = new PdfTrueTypeFont(new Font("Arial Unicode MS", 12f, FontStyle.Regular));
            signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges | PdfCertificationFlags.AllowFormFill;

            //    //Save to file 
            var filePath = Path.Combine("wwwroot/SaveFile", pdfFile.FileName.Substring(0, pdfFile.FileName.LastIndexOf(".")) + ".signed.pdf");
            doc.SaveToFile(filePath);
            doc.Close();
            return filePath.Substring(7);
        }

        public string VerifySignature(IFormFile pdfFile)
        {
            var path1 = Path.Combine("wwwroot/PDFFile", pdfFile.FileName);

            StringBuilder sb = new StringBuilder();
            ///
            List<PdfSignature> signatures = new List<PdfSignature>();

            PdfDocument doc = new PdfDocument(path1);

            PdfFormWidget form = (PdfFormWidget)doc.Form; 
            if (form == null)
            {
                    sb.AppendLine("The document does not have signatures");
            }
            else
            {
            for (int i = 0; i < form.FieldsWidget.Count; ++i)
            {
                PdfSignatureFieldWidget field = form.FieldsWidget[i] as PdfSignatureFieldWidget;

                if (field != null && field.Signature != null)
                {
                    PdfSignature signature = field.Signature;
                    signatures.Add(signature);
                }
            }
            ///

            sb.AppendLine("Has" + signatures.Count + " signatures");
            //     PdfSignature signatureOne = signatures[0];
            for (int i = 0; i < signatures.Count; i++)
            {
                PdfSignature signatureOne = signatures[i];

                try
                {
                    bool bSignature = signatureOne.VerifySignature();
                    //bool checkModified = signatureOne.VerifyDocModified();

                    //if (checkModified)
                    //{
                    //    Console.WriteLine("Change");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Not change");
                    //}
                    if (bSignature)
                    {
                        X509Certificate2 certificate = signatureOne.Certificate as X509Certificate2;

                        DateTime date = signatureOne.Date;
                        string subject = certificate.GetIssuerName();

                        sb.AppendLine("The signature " + (i + 1) + " is visiable");
                        sb.AppendLine("Signature info:");
                        sb.AppendLine("signed by:" + signatureOne.Certificate.GetNameInfo(X509NameType.SimpleName, true));
                        sb.AppendLine("Reason:" + signatureOne.Reason);
                        sb.AppendLine("Location:" + signatureOne.LocationInfo);
                        sb.AppendLine("Time signing:" + date);
                        sb.AppendLine("Certificate Details");
                        sb.AppendLine(certificate.ToString());
                    }
                    else
                    {
                        sb.AppendLine("The signature"+ (i+1)+"is invisible");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
            }
            return sb.ToString();
        }       
    }
}
