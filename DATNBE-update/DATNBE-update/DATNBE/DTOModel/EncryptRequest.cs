namespace DATNBE.DTOModel
{
    public class EncryptRequest
    {
        public bool IsOwner { get; } = false;

        public bool AllowEverything { get; set; } = false;

        public bool PrintDocument { get; set; } = false;

        public bool ModifyContents { get; set; } = false;

        public bool CopyContents { get; set; } = false;

        public bool ModifyAnnotations { get; set; } = false;

        public bool FillFormFields { get; set; } = false;

        public bool ExtractContents { get; set; } = false;

        public bool AssembleDocument { get; set; } = false;

        public bool PrintFaithfulCopy { get; set; } = false;

        public IFormFile PdfFile { get; set; }
        public IFormFile CertOwner { get; set; }
        public IFormFile CertUser { get; set; }
        public string PassOwner { get; set; }
        public int Number { get; set; }
    }
}
