﻿using System;
using UPS.Application.Abstractions;
using Microsoft.Extensions.Localization;

namespace UPS.Infrastructure.Localization.EFLocalizer
{
    public class EFStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ILocalizationDbContext _context;

        public EFStringLocalizerFactory(ILocalizationDbContext context)
        {
            _context = context;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new EFStringLocalizer(_context);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new EFStringLocalizer(_context);
        }
    }
}
