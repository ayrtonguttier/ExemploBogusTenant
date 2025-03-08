using Domain.DataTransferObjects;
using MainServices.ClienteServices;
using Bogus;

namespace ClientAhServices;

public class ClienteAhService : IClienteService
{
    public IEnumerable<Cliente> GetClientes()
    {
        var faker = new ClienteFaker(nameof(ClienteAhService));
        faker.UseSeed(200);
        return faker.GenerateForever();
    }
}