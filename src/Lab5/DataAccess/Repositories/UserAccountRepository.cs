using Npgsql;

namespace Application.DomainModels;

public class UserAccountRepository
{
    private readonly string connectionString;

    public UserAccountRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Insert(int number, int pin)
    {
        const string insertCommand = "INSERT INTO UserAccounts (number, pin, balance, history) VALUES (@number, @pin, @balance, @history)";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand(insertCommand, connection))
            {
                cmd.Parameters.AddWithValue("@number", number);
                cmd.Parameters.AddWithValue("@pin", pin);
                cmd.Parameters.AddWithValue("@balance", 0);
                cmd.Parameters.AddWithValue("@history", "[]");

                cmd.ExecuteNonQuery();
            }
        }
    }
}