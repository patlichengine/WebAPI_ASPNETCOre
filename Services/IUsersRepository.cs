using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentTracking.API.Models;
using DocumentTracking.API.ResourceParameters;
using Microsoft.AspNetCore.JsonPatch;

namespace DocumentTracking.API.Services
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<UsersDto>> GetUsers();

        public Task<IEnumerable<UsersDto>> GetUsers(IEnumerable<Guid> userIds);

        public Task<IEnumerable<UsersDto>> GetUsers(UsersResourceParameters usersResourceParameters);

        public Task<UsersDto> GetUser(Guid userId);

        public Task<bool> UserExists(Guid userId);
        public Task<UsersDto> CreateUser(UsersCreateDto user);

        public Task<IEnumerable<UsersDto>> CreateUsers(IEnumerable<UsersCreateDto> userCollection);

        public Task<bool> Save();
        public Task<UsersDto> UpdateUser(Guid userId, UsersUpdateDto usersUpdateDto);
        public Task<UsersDto> PatchUser(Guid userId, JsonPatchDocument<UsersUpdateDto> patchDocument);
        public Task<UsersDto> DeleteUser(Guid userId);
    }
}
