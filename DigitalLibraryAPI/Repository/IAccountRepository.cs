using DigitalLibraryAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalLibraryAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignupModel signupModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
