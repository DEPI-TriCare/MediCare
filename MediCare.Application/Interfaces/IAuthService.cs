using MediCare.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.Interfaces
{
    public interface AuthService
    {
        public abstract Task<AuthResponseDto> Login(LoginDto dto);

        // using IdentityResult here in the interface is bad but we'll do this for now
        public abstract Task<IdentityResult> Register(RegisterDto dto);

        public abstract Task<AuthResponseDto> Refresh(string RefreshToken);

        public abstract Task Logout(string RefreshToken);
    }
}
