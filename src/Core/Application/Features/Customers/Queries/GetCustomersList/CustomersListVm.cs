using System.Collections.Generic;

namespace UPS.Application.Features.Customers.Queries.GetCustomersList
{
    public class CustomersListVm
    {
        public IList<CustomerLookupDto> Customers { get; set; }
    }
}
