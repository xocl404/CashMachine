using Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public class WithdrawHandler : BaseHandler
{
    public override ResultType Handle(BaseCommand command)
    {
        if (command is WithdrawCommand withdrawCommand)
        {
            var userRole = new UserRole();
            return userRole.Withdraw(withdrawCommand.AtmSystem, withdrawCommand.User, withdrawCommand.Amount);
        }

        return Next?.Handle(command) ?? ResultType.Error("Invalid command.");
    }
}