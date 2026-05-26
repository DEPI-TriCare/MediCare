using AutoMapper;
using BL.Contracts;
using BL.DTOs;
using DAL.Contracts;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class RefreshTokenService : BaseService<RefreshToken, RefreshTokenDTO>, IRefreshTokenService
    {
        private readonly IGenericRepository<RefreshToken> _repo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RefreshTokenService(IGenericRepository<RefreshToken> repo, IMapper mapper, IUserService userService) 
            : base(repo, mapper, userService)
        {
            _repo = repo;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<bool> Refresh(RefreshTokenDTO refreshTokenDTO)
        {
            var dbTokens = await _repo.GetList(a => a.CurrentState == 1 && a.UserId == refreshTokenDTO.UserId);

            foreach (var dbToken in dbTokens)
            {
                await _repo.ChangeStatus(dbToken.Id, _userService.GetLoggedInUser() ,0);
            }

            var newToken = _mapper.Map<RefreshTokenDTO,RefreshToken>(refreshTokenDTO);

            var result = await _repo.Add(newToken);

            return result.Item1;
        }
    }
}
