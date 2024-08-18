using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Services.Runtime.Unity;
using Unity.Services.Authentication;
using Unity.Services.Core;

namespace UGF.Module.Authentication.Runtime.Unity
{
    public class AuthenticationUnityModule : AuthenticationModule<AuthenticationUnityModuleDescription>
    {
        public IAuthenticationService Service { get { return AuthenticationService.Instance; } }

        protected ServicesUnityModule ServicesUnityModule { get; }

        public AuthenticationUnityModule(AuthenticationUnityModuleDescription description, IApplication application) : base(description, application)
        {
            ServicesUnityModule = Application.GetModule<ServicesUnityModule>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            ServicesUnityModule.ConfiguringOptions += OnConfiguringOptions;
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();

            if (Description.SignAnonymouslyOnInitializeAsync)
            {
                var options = new SignInOptions
                {
                    CreateAccount = Description.SignAnonymousDescription.CreateAccount
                };

                Logger.Debug("Signing anonymously.");

                await Service.SignInAnonymouslyAsync(options);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            ServicesUnityModule.ConfiguringOptions -= OnConfiguringOptions;
        }

        protected override bool OnIsSigned()
        {
            return Service.IsSignedIn;
        }

        protected override void OnSignOut()
        {
            Service.SignOut(Description.ClearCredentialsOnSignOut);

            Logger.Debug("Signed out", new
            {
                Description.ClearCredentialsOnSignOut
            });
        }

        protected override string OnGetUserId()
        {
            string id = Service.PlayerId;

            return !string.IsNullOrEmpty(id) ? id : throw new InvalidOperationException("Authentication has no signed user.");
        }

        private void OnConfiguringOptions(InitializationOptions options)
        {
            if (Description.HasProfile)
            {
                options.SetProfile(Description.Profile);

                Logger.Debug("Setup profile", new
                {
                    Description.Profile
                });
            }
        }
    }
}
