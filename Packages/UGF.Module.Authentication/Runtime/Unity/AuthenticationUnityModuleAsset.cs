using System;
using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Authentication.Runtime.Unity
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Authentication/Authentication Unity Module", order = 2000)]
    public class AuthenticationUnityModuleAsset : ApplicationModuleAsset<AuthenticationUnityModule, AuthenticationUnityModuleDescription>
    {
        [SerializeField] private bool m_signAnonymouslyOnInitializeAsync;
        [SerializeField] private AuthenticationUnitySignAnonymousData m_signAnonymousSettings;
        [SerializeField] private bool m_clearCredentialsOnSignOut;
        [SerializeField] private string m_profile;

        public bool SignAnonymouslyOnInitializeAsync { get { return m_signAnonymouslyOnInitializeAsync; } set { m_signAnonymouslyOnInitializeAsync = value; } }
        public AuthenticationUnitySignAnonymousData SignAnonymousSettings { get { return m_signAnonymousSettings; } set { m_signAnonymousSettings = value; } }
        public bool ClearCredentialsOnSignOut { get { return m_clearCredentialsOnSignOut; } set { m_clearCredentialsOnSignOut = value; } }
        public string Profile { get { return m_profile; } set { m_profile = value; } }

        [Serializable]
        public struct AuthenticationUnitySignAnonymousData
        {
            [SerializeField] private bool m_createAccount;

            public bool CreateAccount { get { return m_createAccount; } set { m_createAccount = value; } }

            public AuthenticationUnitySignAnonymousDescription GetDescription()
            {
                return new AuthenticationUnitySignAnonymousDescription(m_createAccount);
            }
        }

        protected override AuthenticationUnityModuleDescription OnBuildDescription()
        {
            return new AuthenticationUnityModuleDescription(
                m_signAnonymouslyOnInitializeAsync,
                m_signAnonymousSettings.GetDescription(),
                m_clearCredentialsOnSignOut,
                m_profile
            );
        }

        protected override AuthenticationUnityModule OnBuild(AuthenticationUnityModuleDescription description, IApplication application)
        {
            return new AuthenticationUnityModule(description, application);
        }
    }
}
