using Example.Api.Commands;
using Example.Api.DataModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Api.CommandHandlers
{
    public class AddDebtorCommandHandlers : IRequestHandler<AddDebtorCommand, Guid>
    {
        private readonly DebtDbContext _dbContext;

        public AddDebtorCommandHandlers(DebtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Guid> Handle(AddDebtorCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            if( string.IsNullOrEmpty(request.FirstName) )
            {
                throw new ArgumentException("First Name cannot be null or empty.", nameof(AddDebtorCommand.FirstName));
            }
            if (string.IsNullOrEmpty(request.LastName))
            {
                throw new ArgumentException("Last Name cannot be null or empty.", nameof(AddDebtorCommand.LastName));
            }
            if (request.DateOfBirth.AddYears(18) > DateTime.Now)
            {
                throw new ArgumentException("Minimum debtoe age is 18.", nameof(AddDebtorCommand.DateOfBirth));
            }
            _dbContext.Debtors.Add(new Debtor()
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName
            });
            _dbContext.SaveChanges();
            return Task.FromResult(id);
        }
    }
}
