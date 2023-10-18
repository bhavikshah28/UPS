using MediatR;

namespace UPS.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailVm>
    {
        public string Id { get; set; }
    }
}
