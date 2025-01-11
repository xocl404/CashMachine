using Itmo.ObjectOrientedProgramming.Lab5.Application.Creators;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class Test
{
    [Fact]
    public void TopUpTest()
    {
        // Arrange
        var mock = new Mock<IRepository>();
        var atmSystem = new AtmSystem("1234", mock.Object);
        var commandBus = new CommandBus();
        var commandCreator = new CommandsCreator();

        // Act
        commandBus.Execute(commandCreator.CreateTopUpCommand(atmSystem, 1, 4567, 45));

        // Assert
        mock.Verify(repo => repo.UpdateBalance(1, 45), Times.Once);
    }

    [Fact]
    public void WithdrawTest()
    {
        // Arrange
        var mock = new Mock<IRepository>();
        var atmSystem = new AtmSystem("1234", mock.Object);
        var commandBus = new CommandBus();
        var commandCreator = new CommandsCreator();

        // Act
        commandBus.Execute(commandCreator.CreateTopUpCommand(atmSystem, 1, 4567, -45));

        // Assert
        mock.Verify(repo => repo.UpdateBalance(1, -45), Times.Once);
    }
}