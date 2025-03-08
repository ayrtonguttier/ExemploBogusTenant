using Domain.DataTransferObjects;

namespace MainServices.ClienteServices;

public interface IClienteService
{
    IEnumerable<Cliente> GetClientes();
}