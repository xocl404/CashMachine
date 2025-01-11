using Itmo.ObjectOrientedProgramming.Lab5.Domain.Commands;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

public interface IHandler
{
    IHandler AddNext(IHandler handler);

    ResultType Handle(BaseCommand command);
}