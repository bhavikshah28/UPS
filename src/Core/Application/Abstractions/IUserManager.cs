using System;
using System.Threading.Tasks;
using UPS.Application.Common.Models;

namespace UPS.Application.Abstractions
{
    public interface IUserManager
    {
        Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(Guid userId);
    }
}
