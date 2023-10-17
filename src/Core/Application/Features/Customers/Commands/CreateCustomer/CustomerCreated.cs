using System.Threading;
using System.Threading.Tasks;
using UPS.Application.Abstractions;
using UPS.Application.Features.Notifications.Models;
using MediatR;

namespace UPS.Application.Features.Customers.Commands.CreateCustomer
{
    public class CustomerCreated : INotification
    {
        public string CustomerId { get; set; }

        public class CustomerCreatedHandler : INotificationHandler<CustomerCreated>
        {
            private readonly IEmailService _email;

            public CustomerCreatedHandler(IEmailService email)
            {
                _email = email;
            }

            public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
            {
                await _email.SendCustomerCreatedEmail(new EmailMessage());
            }
        }
}
}
