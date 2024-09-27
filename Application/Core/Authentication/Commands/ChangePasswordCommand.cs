using MediatR;

namespace UltStore.Application.Core.Authentication.Commands
{
    public class ChangePasswordCommand: IRequest<bool>
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePasswordCommand(string email, string oldPassword, string newPassword)
        {
            Email = email;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}