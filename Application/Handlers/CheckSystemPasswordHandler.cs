using Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public class CheckSystemPasswordHandler : BaseHandler
{
    public override ResultType Handle(BaseCommand command)
    {
        if (command is CheckSystemPasswordCommand checkSystemPasswordCommand)
        {
            var administratorRole = new AdministratorRole();
            return administratorRole.CheckSystemPassword(checkSystemPasswordCommand.AtmSystem, checkSystemPasswordCommand.Password);
        }

        return Next?.Handle(command) ?? ResultType.Error("Invalid command.");
    }
}