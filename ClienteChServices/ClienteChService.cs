using Domain.DataTransferObjects;
using MainServices.ClienteServices;

namespace ClienteChServices;

public class ClienteChService(MainClienteService mainClienteService) : IClienteService
{
    public IEnumerable<Cliente> GetClientes()
    {
        return mainClienteService.GetClientes();
    }
}