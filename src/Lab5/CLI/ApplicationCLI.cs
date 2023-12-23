using AdminAdapter;
using Application.DomainModels;
using Application.Ports;
using DataAccess.Repositories;
using UserAdapter;

namespace CLI;

public class ApplicationCLI
{
    private UserAccountRepository _accountRepository;
    private AdminAccountRepository _adminAccountRepository;
    private IAdminPort _adminPort;
    private IUserPort _userPort;
    private string _connectionSring;

    public ApplicationCLI(UserAccountRepository accountRepository, AdminAccountRepository adminAccountRepository, IAdminPort adminPort, IUserPort userPort, string connectionSring)
    {
        _accountRepository = accountRepository;
        _adminAccountRepository = adminAccountRepository;
        _adminPort = adminPort;
        _userPort = userPort;
        _connectionSring = connectionSring;
    }

    public void ApplicationStart()
    {
        Console.WriteLine("Hi, insert command ");

        string? request = string.Empty;
        string? mode;
        while (request != "fin")
        {
            mode = Console.ReadLine();
            request = Console.ReadLine();
            if (mode == "admin" && request is not null)
            {
                int number;
                int pin;
                int systemPassword;
                if (!int.TryParse(request.Split(" ")[1], out number) &&
                    !int.TryParse(request.Split(" ")[2], out pin) &&
                    !int.TryParse(request.Split(" ")[0], out systemPassword))
                {
                    var admin = new Admin(
                        _adminAccountRepository,
                        new AdminAccount(systemPassword, new UserAccount(number, pin)));

                    string req = request.Split(" ")[3];
                    switch (req)
                    {
                        case "make":
                            admin.MakeNewAccount(number, pin);
                            break;
                        case "check balance":
                            admin.CheckAccountBalance();
                            break;
                        case "dec":
                            string? dec = Console.ReadLine();
                            int numDec;
                            if (!int.TryParse(dec, out numDec))
                            {
                                admin.DecreaseAccountBalance(numDec);
                            }

                            break;
                        case "inc":
                            string? inc = Console.ReadLine();
                            int numInc;
                            if (!int.TryParse(inc, out numInc))
                            {
                                admin.IncreaseAccountBalance(numInc);
                            }

                            break;
                        case "history":
                            admin.CheckHistory();
                            break;
                    }
                }
            }
            else if (mode == "user" && request is not null)
            {
                int number;
                int pin;
                int systemPassword;
                if (!int.TryParse(request.Split(" ")[1], out number) &&
                    !int.TryParse(request.Split(" ")[2], out pin) &&
                    !int.TryParse(request.Split(" ")[0], out systemPassword))
                {
                    var user = new User(
                        _accountRepository,
                        new AdminAccount(systemPassword, new UserAccount(number, pin)));

                    string req = request.Split(" ")[3];
                    switch (req)
                    {
                        case "check balance":
                            user.CheckAccountBalance();
                            break;
                        case "dec":
                            string? dec = Console.ReadLine();
                            int numDec;
                            if (!int.TryParse(dec, out numDec))
                            {
                                user.DecreaseAccountBalance(numDec);
                            }

                            break;
                        case "inc":
                            string? inc = Console.ReadLine();
                            int numInc;
                            if (!int.TryParse(inc, out numInc))
                            {
                                user.IncreaseAccountBalance(numInc);
                            }

                            break;
                        case "history":
                            user.CheckHistory();
                            break;
                    }
                }
            }
        }
    }
}