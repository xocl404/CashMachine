using Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

public class AtmSystem(string systemPassword, IRepository repository)
{
    public IRepository Repository { get; } = repository;

    public ResultType CheckPassword(string password)
    {
        return password == systemPassword ? ResultType.Success("Password is correct") : ResultType.Error("Password is incorrect");
    }
}