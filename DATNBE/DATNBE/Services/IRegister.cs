using DATNBE.DTOModel;

namespace DATNBE.Services
{
    public interface IRegister
    { 
        void RegisterAccount(UserDTO user,IFormFile cert);
    }
}
