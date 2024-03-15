using Hr_System.Models;

namespace Hr_System.Sevices
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenReqModel model);


    }
}
