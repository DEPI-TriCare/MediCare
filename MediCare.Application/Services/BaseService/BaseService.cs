using AutoMapper;
using BL.Contracts;
using DAL.Contracts;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BaseService<T, DTO> : IBaseService<T, DTO> where T : BaseTable
    {
        private readonly IGenericRepository<T> _repo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;

        public BaseService(IGenericRepository<T> repo, IMapper mapper ,IUserService userService)
        {
            _repo = repo;
            _mapper = mapper;
            _userService = userService;
        }

        public BaseService(IUnitOfWork uow, IMapper mapper, IUserService userService)
        {
            _uow = uow;
            _repo = uow.Repository<T>();
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<List<DTO>> GetAll()
        {
            var data = await _repo.GetAll();
            return _mapper.Map<List<T>, List<DTO>>(data);
        }

        public async Task<DTO> GetById(Guid Id)
        {
            var data = await _repo.GetById(Id);
            return _mapper.Map<T, DTO>(data);
        }

        public async Task<(bool, Guid)> Add(DTO entity)
        {
            var data = _mapper.Map<DTO, T>(entity);
            data.CreatedBy = _userService.GetLoggedInUser();
            return await _repo.Add(data);
        }

        public async Task<bool> Update(DTO entity)
        {
            var data = _mapper.Map<DTO, T>(entity);
            data.UpdatedBy = _userService.GetLoggedInUser();
            return await _repo.Update(data);
        }

        public async Task<bool> ChangeStatus(Guid Id, int status = 0)
        {
            return await _repo.ChangeStatus(Id, _userService.GetLoggedInUser(), status);
        }
    }
}
