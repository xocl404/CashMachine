using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;

public class AdministratorRole : IAdministratorRole
{
    public ResultType CheckSystemPassword(AtmSystem atmSystem, string password)
    {
        return atmSystem.CheckPassword(password);
    }
}