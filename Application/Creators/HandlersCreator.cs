using Itmo.ObjectOrientedProgramming.Lab5.Application.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Creators;

public static class HandlersCreator
{
    public static IHandler Create()
    {
        IHandler handler = new CheckSystemPasswordHandler()
            .AddNext(new CreateNewUserHandler())
            .AddNext(new CheckBalanceHandler())
            .AddNext(new CheckOperationsHistoryHandler())
            .AddNext(new TopUpHandler())
            .AddNext(new WithdrawHandler());
        return handler;
    }
}