﻿using System;

namespace UPS.Application.Abstractions
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }

        bool IsAuthenticated { get; }
    }
}
