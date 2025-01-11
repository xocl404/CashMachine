using Itmo.ObjectOrientedProgramming.Lab5.Application.Creators;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;

public class CommandBus : ICommandBus
{
    public ResultType Execute(BaseCommand command)
    {
        return HandlersCreator.Create().Handle(command);
    }
}