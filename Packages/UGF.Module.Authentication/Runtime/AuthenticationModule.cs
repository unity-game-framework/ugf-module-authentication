using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.Logs.Runtime;

namespace UGF.Module.Authentication.Runtime
{
    public abstract class AuthenticationModule<TDescription> : ApplicationModuleAsync<TDescription>, IAuthenticationModule where TDescription : class, IDescription
    {
        public bool IsSigned { get { return OnIsSigned(); } }

        protected ILog Logger { get; }

        protected AuthenticationModule(TDescription description, IApplication application) : base(description, application)
        {
            Logger = Log.CreateWithLabel(GetType().Name);
        }

        public void SignOut()
        {
            Logger.Debug("Signing out.");

            OnSignOut();
        }

        public string GetUserId()
        {
            return OnGetUserId();
        }

        protected abstract bool OnIsSigned();
        protected abstract void OnSignOut();
        protected abstract string OnGetUserId();
    }
}
