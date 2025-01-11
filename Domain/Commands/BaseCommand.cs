using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;

public abstract class BaseCommand(AtmSystem atmSystem)
{
    public AtmSystem AtmSystem { get; } = atmSystem;
}