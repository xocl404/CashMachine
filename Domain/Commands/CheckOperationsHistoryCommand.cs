using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;

public class CheckOperationsHistoryCommand(AtmSystem atmSystem, User user) : BaseCommand(atmSystem)
{
    public User User { get; } = user;
}