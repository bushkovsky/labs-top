using Npgsql;

namespace DataAccess.Repositories;

public class AdminAccountRepository
{
    private readonly string connectionString;

    public AdminAccountRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Insert(int number, int pin)
    {
        const string insertCommand = "INSERT INTO AdminAccounts (systemPassword) VALUES (@number)";
        CheckPin(pin);
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var cmd = new NpgsqlCommand(insertCommand, connection))
            {
                cmd.Parameters.AddWithValue("@systemPassword", number);

                cmd.ExecuteNonQuery();
            }
        }
    }

    private static bool CheckPin(int pin)
    {
        return pin == 8;
    }
}