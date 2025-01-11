using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;

public class WithdrawCommand(AtmSystem atmSystem, User user, int amount) : BaseCommand(atmSystem)
{
    public User User { get; } = user;

    public int Amount { get; } = amount;
}