using Itmo.ObjectOrientedProgramming.Lab5.Application.Creators;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Executors;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation;

public static class Runner
{
    public static ResultType Run(AtmSystem atmSystem)
    {
        while (true)
        {
            Console.WriteLine("Select the role: administrator or user.");
            string role = Console.ReadLine() ?? string.Empty;
            switch (role)
            {
                case "administrator":
                {
                    ResultType result = Administrator(atmSystem);
                    Console.WriteLine(result.Message);
                    if (result.IsError) return result;
                    break;
                }

                case "user":
                {
                    ResultType result = User(atmSystem);
                    Console.WriteLine(result.Message);
                    break;
                }

                default:
                    return ResultType.Error($"Unknown role: {role}");
            }

            if (Console.ReadLine() is "end") break;
        }

        return ResultType.Success("The program is completed.");
    }

    private static ResultType Administrator(AtmSystem atmSystem)
    {
        var commandCreator = new CommandsCreator();
        var commandBus = new CommandBus();
        Console.WriteLine("Enter the system password:");
        string password = Console.ReadLine() ?? string.Empty;
        return commandBus.Execute(commandCreator.CreateCheckSystemPasswordCommand(atmSystem, password));
    }

    private static ResultType User(AtmSystem atmSystem)
    {
        var commandCreator = new CommandsCreator();
        var commandBus = new CommandBus();
        Console.WriteLine("If you want to log in, write 'log in', if you want to register, write 'register'");
        string context = Console.ReadLine() ?? string.Empty;
        switch (context)
        {
            case "register":
                Console.WriteLine("Enter the pin-code:");
                int pinCode = int.Parse(Console.ReadLine() ?? string.Empty);
                return commandBus.Execute(commandCreator.CreateCreateNewUserCommand(atmSystem, pinCode));
            case "log in":
                Console.WriteLine("Enter the account number:");
                long accountNumber = long.Parse(Console.ReadLine() ?? string.Empty);
                Console.WriteLine("Enter the pin-code:");
                pinCode = int.Parse(Console.ReadLine() ?? string.Empty);
                Console.WriteLine("If you want to check the account balance, write 'balance', " +
                                  "if you want to top up your account, write '+', " +
                                  "if you want to withdraw money from the account, write '-', " +
                                  "if you want to check the history of operations, write 'history'");
                string command = Console.ReadLine() ?? string.Empty;
                switch (command)
                {
                    case "balance":
                        return commandBus.Execute(commandCreator.CreateCheckBalanceCommand(atmSystem, accountNumber, pinCode));
                    case "+":
                        Console.WriteLine("Enter the amount:");
                        int amount = int.Parse(Console.ReadLine() ?? string.Empty);
                        return commandBus.Execute(commandCreator.CreateTopUpCommand(atmSystem, accountNumber, pinCode, amount));
                    case "-":
                        Console.WriteLine("Enter the amount:");
                        amount = int.Parse(Console.ReadLine() ?? string.Empty);
                        return commandBus.Execute(
                            commandCreator.CreateWithdrawCommand(atmSystem, accountNumber, pinCode, amount));
                    case "history":
                        return commandBus.Execute(commandCreator.CreateCheckOperationsHistoryCommand(atmSystem, accountNumber, pinCode));
                    default:
                        return ResultType.Error($"Invalid input: {command}");
                }

            default:
                return ResultType.Error($"Invalid input: {context}");
        }
    }
}