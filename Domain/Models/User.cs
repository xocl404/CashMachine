namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

public class User
{
    private static long _currentAccountNumber;

    public long AccountNumber { get; }

    public int PinCode { get; }

    public User(int pinCode)
    {
        AccountNumber = ++_currentAccountNumber;
        PinCode = pinCode;
    }

    public User(long accountNumber, int pinCode)
    {
        AccountNumber = accountNumber;
        PinCode = pinCode;
    }
}