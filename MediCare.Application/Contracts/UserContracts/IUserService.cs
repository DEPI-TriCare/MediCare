using BL.DTOs;
using BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface IUserService
    {
        public Guid GetLoggedInUser();
        public Task<UserResultDTO> LoginAsync(LoginDTO loginDto);
        public Task Logout();
        public Task<UserResultDTO> RegisterAsync(UserDTO registerDto);
        public Task<UserDTO> GetUserByIdAsync(string Id);
        public Task<UserDTO> GetUserByEmailAsync(string email);
        public Task<IEnumerable<UserDTO>> GetAllUsers();
    }
}
