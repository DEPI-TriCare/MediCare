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
    public class RefreshTokenRetriver : BaseService<RefreshToken, RefreshTokenDTO>, IRefreshTokenRetriver
    {
        private readonly IGenericRepository<RefreshToken> _repo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RefreshTokenRetriver(IGenericRepository<RefreshToken> repo, IMapper mapper, IUserService userService) 
            : base(repo, mapper, userService)
        {
            _repo = repo;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<RefreshTokenDTO> GetByToken(string token)
        {
            var data = await _repo.GetFirstOrDefault(a => a.Token == token && a.CurrentState == 1);

            if (data == null)
            {
                return null;
            }

            return _mapper.Map<RefreshToken,RefreshTokenDTO>(data);
        }
    }
}
