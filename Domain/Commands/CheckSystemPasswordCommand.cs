using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;

public class CheckSystemPasswordCommand(AtmSystem atmSystem, string password) : BaseCommand(atmSystem)
{
    public string Password { get; } = password;
}