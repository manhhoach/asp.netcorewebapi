﻿using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Service.Contracts.IService
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
