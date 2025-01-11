using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;

public class UserRole : IUserRole
{
    public ResultType AddNewUser(AtmSystem atmSystem, User user)
    {
        if (user.PinCode is < 1000 or > 9999) return ResultType.Error("The Pin-code must consist of 4 digits.");
        atmSystem.Repository.AddUser(user.AccountNumber, user.PinCode);
        atmSystem.Repository.AddAccount(user.AccountNumber);
        return ResultType.Success($"The account has been successfully added. Your account number is {user.AccountNumber}");
    }

    public ResultType CheckBalance(AtmSystem atmSystem, User user)
    {
        return ResultType.Success($"The balance is {atmSystem.Repository.GetBalance(user.AccountNumber)}.");
    }

    public ResultType CheckOperationsHistory(AtmSystem atmSystem, User user)
    {
        return ResultType.Success($"{atmSystem.Repository.GetOperationsHistory(user.AccountNumber)}");
    }

    public ResultType TopUp(AtmSystem atmSystem, User user, int amount)
    {
        atmSystem.Repository.AddOperation(user.AccountNumber, amount);
        atmSystem.Repository.UpdateBalance(user.AccountNumber, atmSystem.Repository.GetBalance(user.AccountNumber) + amount);
        return ResultType.Success("The transaction was successful.");
    }

    public ResultType Withdraw(AtmSystem atmSystem, User user, int amount)
    {
        if (!atmSystem.Repository.UpdateBalance(user.AccountNumber, 0 - amount)) return ResultType.Error("The balance is too low.");
        atmSystem.Repository.AddOperation(user.AccountNumber, 0 - amount);
        return ResultType.Success("The transaction was successful.");
    }
}