using PasswordManager_API.DTOs.Authantication;

namespace PasswordManager_API.Interfaces
{
    public interface IUserAuthanticationInterface
    {
        Task<string> SignUp(SignUpInputDTO input);
        Task<string> SignIn(SignInInputDTO input);
        Task<string> Verification(VerificationInputDTO input);
        Task<bool> SendOTP(string email);
        Task<bool> ResetPersonPassword(ResetPersonPasswordInputDTO input);
        Task<bool> SignOut(int useriD);
    }
}
