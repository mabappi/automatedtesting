using Example.Api.CommandHandlers;
using Example.Api.Commands;
using Example.Api.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using FluentAssertions;

namespace Example.Api.UnitTests
{
    [TestClass]
    public class AddDebtorCommandHandlersTest
    {
        [TestMethod]
        public void Handle_WhenFirstNameIsEmpty_ShouldThrowException()
        {
            var commandHandler = GetCommandHandlers();
            var command = new AddDebtorCommand()
            {
                LastName = "Last Name",
                DateOfBirth = DateTime.Now.AddYears(-18)
            };
            Assert.ThrowsException<ArgumentException>(() => commandHandler.Handle(command, CancellationToken.None))
                .ParamName.Should().Be(nameof(AddDebtorCommand.FirstName));
        }

        [TestMethod]
        public void Handle_WhenLastNameIsEmpty_ShouldThrowException()
        {
            var commandHandler = GetCommandHandlers();
            var command = new AddDebtorCommand()
            {
                FirstName = "First Name",
                DateOfBirth = DateTime.Now.AddYears(-18)
            };
            Assert.ThrowsException<ArgumentException>(() => commandHandler.Handle(command, CancellationToken.None))
                .ParamName.Should().Be(nameof(AddDebtorCommand.LastName));
        }

        [TestMethod]
        public void Handle_WhenAllDataValid_ShouldAddNewDebtor()
        {
            var commandHandler = GetCommandHandlers();
            var command = new AddDebtorCommand()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                DateOfBirth = DateTime.Now.AddYears(-18)
            };
            var id = commandHandler.Handle(command, CancellationToken.None).Result;
            Assert.IsFalse(id == Guid.Empty);
        }

        private AddDebtorCommandHandlers GetCommandHandlers()
        {
            var builder = new DbContextOptionsBuilder<DebtDbContext>();
            builder.UseInMemoryDatabase("DebtDb");
            return new AddDebtorCommandHandlers(new DebtDbContext(builder.Options));
        }
    }
}
