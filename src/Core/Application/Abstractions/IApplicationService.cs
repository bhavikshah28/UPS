using UPS.Application.Models;

namespace UPS.Application.Abstractions
{
    public interface IApplicationService
    {
        ApplicationDataViewModel GetApplicationData();
    }
}