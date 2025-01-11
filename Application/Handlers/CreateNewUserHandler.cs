using Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public class CreateNewUserHandler : BaseHandler
{
    public override ResultType Handle(BaseCommand command)
    {
        if (command is CreateNewUserCommand createNewUserCommand)
        {
            var userRole = new UserRole();
            return userRole.AddNewUser(createNewUserCommand.AtmSystem, createNewUserCommand.User);
        }

        return Next?.Handle(command) ?? ResultType.Error("Invalid command.");
    }
}