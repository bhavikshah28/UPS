﻿using System.Threading;
using System.Threading.Tasks;
using UPS.Application.Abstractions;
using UPS.Application.Exceptions;
using UPS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UPS.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Country { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }

        public class Handler : IRequestHandler<UpdateCustomerCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Customers
                    .SingleOrDefaultAsync(c => c.CustomerId == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Customer), request.Id);
                }

                entity.Address = request.Address;
                entity.City = request.City;
                entity.CompanyName = request.CompanyName;
                entity.ContactName = request.ContactName;
                entity.ContactTitle = request.ContactTitle;
                entity.Country = request.Country;
                entity.Fax = request.Fax;
                entity.Phone = request.Phone;
                entity.PostalCode = request.PostalCode;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
