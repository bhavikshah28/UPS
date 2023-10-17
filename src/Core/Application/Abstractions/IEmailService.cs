using System.Threading.Tasks;
using UPS.Application.Features.Notifications.Models;

namespace UPS.Application.Abstractions
{
    public interface IEmailService
    {
        Task RegistrationConfirmationEmail(string to, string link);
        Task ForgottentPasswordEmail(string to, string link);
        Task SendCustomerCreatedEmail(EmailMessage emailMessage);
    }
}
