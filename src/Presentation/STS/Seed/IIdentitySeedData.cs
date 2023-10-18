using System;

namespace UPS.STS.Seed
{
    public interface IIdentitySeedData
    {
        void Seed(IServiceProvider serviceProvider);
    }
}