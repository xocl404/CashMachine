using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface IUserRole
{
    ResultType AddNewUser(AtmSystem atmSystem, User user);

    ResultType CheckBalance(AtmSystem atmSystem, User user);

    ResultType CheckOperationsHistory(AtmSystem atmSystem, User user);

    ResultType TopUp(AtmSystem atmSystem, User user, int amount);

    ResultType Withdraw(AtmSystem atmSystem, User user, int amount);
}