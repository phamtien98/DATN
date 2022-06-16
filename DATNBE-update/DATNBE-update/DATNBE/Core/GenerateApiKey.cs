using System.Security.Cryptography;

namespace DATNBE.Core
{
    public class GenerateApiKey
    {
        public static string genApiKey()
        {
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            return  Convert.ToBase64String(key);
        }
    }
}
