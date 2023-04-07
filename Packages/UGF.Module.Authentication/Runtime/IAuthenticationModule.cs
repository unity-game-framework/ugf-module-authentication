using UGF.Application.Runtime;

namespace UGF.Module.Authentication.Runtime
{
    public interface IAuthenticationModule : IApplicationModule
    {
        bool IsSigned { get; }

        void SignOut();
        string GetUserId();
    }
}
