using Domain.DataTransferObjects;
using MainServices.ClienteServices;

namespace ClienteBhServices;

public class ClienteBhService : IClienteService
{
    public IEnumerable<Cliente> GetClientes()
    {
        var faker = new ClienteFaker(nameof(ClienteBhService));
        faker.UseSeed(300);
        return faker.GenerateForever();
    }
}