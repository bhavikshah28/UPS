using System;
using System.Security.Claims;
using UPS.Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace UPS.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Guid.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);
            UserId = userId;
            IsAuthenticated = UserId != default;
        }

        public Guid UserId { get; }

        public bool IsAuthenticated { get; }
    }

}
