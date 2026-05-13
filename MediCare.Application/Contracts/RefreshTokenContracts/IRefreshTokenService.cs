using BL.DTOs;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface IRefreshTokenService : IBaseService<RefreshToken, RefreshTokenDTO>
    {
        public Task<bool> Refresh(RefreshTokenDTO refreshTokenDTO);
    }
}
