using Maui.BlazorAppTest.Models;

namespace Maui.BlazorAppTest.Services
{
    public interface IAppService
    {
        public Task<string> AuthenticateUser(LoginModel loginModel);
        Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registerUser);
    }
}
