using UGF.Description.Runtime;

namespace UGF.Module.Authentication.Runtime.Unity
{
    public class AuthenticationUnitySignAnonymousDescription : DescriptionBase
    {
        public bool CreateAccount { get; }

        public AuthenticationUnitySignAnonymousDescription(bool createAccount)
        {
            CreateAccount = createAccount;
        }
    }
}
