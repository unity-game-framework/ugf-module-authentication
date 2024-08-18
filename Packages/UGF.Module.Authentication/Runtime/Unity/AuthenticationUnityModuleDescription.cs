using System;
using UGF.Application.Runtime;

namespace UGF.Module.Authentication.Runtime.Unity
{
    public class AuthenticationUnityModuleDescription : ApplicationModuleDescription
    {
        public bool SignAnonymouslyOnInitializeAsync { get; }
        public AuthenticationUnitySignAnonymousDescription SignAnonymousDescription { get; }
        public bool ClearCredentialsOnSignOut { get; }
        public string Profile { get { return HasProfile ? m_profile : throw new ArgumentException("Value not specified."); } }
        public bool HasProfile { get { return !string.IsNullOrEmpty(m_profile); } }

        private readonly string m_profile;

        public AuthenticationUnityModuleDescription(
            bool signAnonymouslyOnInitializeAsync,
            AuthenticationUnitySignAnonymousDescription signAnonymousDescription,
            bool clearCredentialsOnSignOut,
            string profile)
        {
            SignAnonymouslyOnInitializeAsync = signAnonymouslyOnInitializeAsync;
            SignAnonymousDescription = signAnonymousDescription ?? throw new ArgumentNullException(nameof(signAnonymousDescription));
            ClearCredentialsOnSignOut = clearCredentialsOnSignOut;
            m_profile = profile;
        }
    }
}
