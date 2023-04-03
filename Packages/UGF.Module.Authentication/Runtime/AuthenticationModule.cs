﻿using UGF.Application.Runtime;

namespace UGF.Module.Authentication.Runtime
{
    public abstract class AuthenticationModule<TDescription> : ApplicationModuleAsync<TDescription>, IAuthenticationModule where TDescription : class, IApplicationModuleDescription
    {
        public bool IsSigned { get { return OnIsSigned(); } }

        protected AuthenticationModule(TDescription description, IApplication application) : base(description, application)
        {
        }

        public void SignOut()
        {
            OnSignOut();
        }

        protected abstract bool OnIsSigned();
        protected abstract void OnSignOut();
    }
}