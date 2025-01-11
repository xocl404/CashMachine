using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Creators;

public class CommandsCreator : ICommandsCreator
{
    public CheckSystemPasswordCommand CreateCheckSystemPasswordCommand(AtmSystem atmSysytem, string password)
    {
        return new CheckSystemPasswordCommand(atmSysytem, password);
    }

    public CreateNewUserCommand CreateCreateNewUserCommand(AtmSystem atmSystem, int pinCode)
    {
        return new CreateNewUserCommand(atmSystem, new User(pinCode));
    }

    public CheckBalanceCommand CreateCheckBalanceCommand(AtmSystem atmSystem, long accountNumber, int pinCode)
    {
        return new CheckBalanceCommand(atmSystem, new User(accountNumber, pinCode));
    }

    public CheckOperationsHistoryCommand CreateCheckOperationsHistoryCommand(AtmSystem atmSystem, long accountNumber, int pinCode)
    {
        return new CheckOperationsHistoryCommand(atmSystem, new User(accountNumber, pinCode));
    }

    public TopUpCommand CreateTopUpCommand(AtmSystem atmSystem, long accountNumber, int pinCode, int amount)
    {
        return new TopUpCommand(atmSystem, new User(accountNumber, pinCode), amount);
    }

    public WithdrawCommand CreateWithdrawCommand(AtmSystem atmSystem, long accountNumber, int pinCode, int amount)
    {
        return new WithdrawCommand(atmSystem, new User(accountNumber, pinCode), amount);
    }
}