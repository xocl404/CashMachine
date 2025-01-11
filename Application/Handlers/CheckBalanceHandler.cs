using Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public class CheckBalanceHandler : BaseHandler
{
    public override ResultType Handle(BaseCommand command)
    {
        if (command is CheckBalanceCommand checkBalanceCommand)
        {
            var userRole = new UserRole();
            return userRole.CheckBalance(checkBalanceCommand.AtmSystem, checkBalanceCommand.User);
        }

        return Next?.Handle(command) ?? ResultType.Error("Invalid command.");
    }
}