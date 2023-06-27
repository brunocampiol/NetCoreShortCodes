﻿using NetCoreShortCodes.API.Models.Entity;

namespace NetCoreShortCodes.API.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(User user);

        Task<User?> GetAsync(string username);

        Task<IEnumerable<User>> GetAllAsync();

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(string username);
    }
}