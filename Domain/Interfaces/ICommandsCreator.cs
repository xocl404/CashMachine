using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface ICommandsCreator
{
    public CheckSystemPasswordCommand CreateCheckSystemPasswordCommand(AtmSystem atmSysytem, string password);

    public CreateNewUserCommand CreateCreateNewUserCommand(AtmSystem atmSystem, int pinCode);

    public CheckBalanceCommand CreateCheckBalanceCommand(AtmSystem atmSystem, long accountNumber, int pinCode);

    public CheckOperationsHistoryCommand CreateCheckOperationsHistoryCommand(AtmSystem atmSystem, long accountNumber, int pinCode);

    public TopUpCommand CreateTopUpCommand(AtmSystem atmSystem, long accountNumber, int pinCode, int amount);

    public WithdrawCommand CreateWithdrawCommand(AtmSystem atmSystem, long accountNumber, int pinCode, int amount);
}