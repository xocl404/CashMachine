using Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public class CheckOperationsHistoryHandler : BaseHandler
{
    public override ResultType Handle(BaseCommand command)
    {
        if (command is CheckOperationsHistoryCommand checkOperationsHistoryCommand)
        {
            var userRole = new UserRole();
            return userRole.CheckOperationsHistory(checkOperationsHistoryCommand.AtmSystem, checkOperationsHistoryCommand.User);
        }

        return Next?.Handle(command) ?? ResultType.Error("Invalid command.");
    }
}