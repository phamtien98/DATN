namespace DATNBE.DTOModel
{
    public class UserDTO
    {
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IFormFile Cert { get; set; } 
        public string Passcertificate { get; set; } = null!;
    }
}
