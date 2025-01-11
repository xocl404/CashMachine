using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface IAdministratorRole
{
    ResultType CheckSystemPassword(AtmSystem atmSystem, string password);
}