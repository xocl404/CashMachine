using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;

public interface IRepository
{
    void AddUser(long accountNumber, int pinCode);

    void AddAccount(long accountNumber, int balance = 0);

    int GetBalance(long accountNumber);

    void AddOperation(long accountNumber, int amount);

    bool UpdateBalance(long accountNumber, int amount);

    Collection<Tuple<long, int>> GetOperationsHistory(long accountNumber);
}