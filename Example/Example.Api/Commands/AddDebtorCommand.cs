using MediatR;
using System;

namespace Example.Api.Commands
{
    public class AddDebtorCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
