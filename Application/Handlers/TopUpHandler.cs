using Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public class TopUpHandler : BaseHandler
{
    public override ResultType Handle(BaseCommand command)
    {
        if (command is TopUpCommand topUpCommand)
        {
            var userRole = new UserRole();
            return userRole.TopUp(topUpCommand.AtmSystem, topUpCommand.User, topUpCommand.Amount);
        }

        return Next?.Handle(command) ?? ResultType.Error("Invalid command.");
    }
}