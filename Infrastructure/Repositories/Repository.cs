using Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;
using Npgsql;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;

public class Repository(NpgsqlConnection connection) : IRepository
{
    public void AddUser(long accountNumber, int pinCode)
    {
        string insertQuery = "INSERT INTO users (account_number, pin_code) VALUES (@account_number, @pin_code);";

        using var cmd = new NpgsqlCommand(insertQuery, connection);
        cmd.Parameters.AddWithValue("account_number", accountNumber);
        cmd.Parameters.AddWithValue("pin_code", pinCode);

        cmd.ExecuteNonQuery();
    }

    public void AddAccount(long accountNumber, int balance = 0)
    {
        string insertQuery =
            "INSERT INTO account_details (account_number, balance) VALUES (@account_number, @balance);";

        using var cmd = new NpgsqlCommand(insertQuery, connection);
        cmd.Parameters.AddWithValue("account_number", accountNumber);
        cmd.Parameters.AddWithValue("balance", balance);

        cmd.ExecuteNonQuery();
    }

    public int GetBalance(long accountNumber)
    {
        string selectQuery = "SELECT balance FROM account_details WHERE account_number = @account_number LIMIT 1;";
        using var cmd = new NpgsqlCommand(selectQuery, connection);
        cmd.Parameters.AddWithValue("account_number", accountNumber);
        object? result = cmd.ExecuteScalar();
        return result != null ? (int)result : 0;
    }

    public void AddOperation(long accountNumber, int amount)
    {
        string insertQuery = "INSERT INTO operations (account_number, amount) VALUES (@account_number, @amount);";

        using var cmd = new NpgsqlCommand(insertQuery, connection);
        cmd.Parameters.AddWithValue("account_number", accountNumber);
        cmd.Parameters.AddWithValue("amount", amount);

        cmd.ExecuteNonQuery();
    }

    public bool UpdateBalance(long accountNumber, int amount)
    {
        int newBalance = GetBalance(accountNumber) + amount;
        if (newBalance < 0) return false;
        string updateQuery =
            "UPDATE account_details SET balance = @new_balance WHERE account_number = @account_number;";

        using var cmd = new NpgsqlCommand(updateQuery, connection);
        cmd.Parameters.AddWithValue("new_balance", newBalance);
        cmd.Parameters.AddWithValue("account_number", accountNumber);
        cmd.ExecuteNonQuery();
        return true;
    }

    public Collection<Tuple<long, int>> GetOperationsHistory(long accountNumber)
    {
        var operations = new Collection<Tuple<long, int>>();
        string selectQuery = "SELECT account_number, amount FROM operations WHERE account_number = @account_number;";
        using var cmd = new NpgsqlCommand(selectQuery, connection);
        cmd.Parameters.AddWithValue("account_number", accountNumber);
        using NpgsqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            operations.Add(new Tuple<long, int>(reader.GetInt64(0), reader.GetInt32(1)));
        }

        return operations;
    }
}