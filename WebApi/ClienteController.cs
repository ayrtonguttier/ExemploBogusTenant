using Finbuckle.MultiTenant;
using MainServices.ClienteServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("{__tenant__}/[controller]")]
public class ClienteController : ControllerBase
{
    [HttpGet()]
    public IActionResult GetCliente([FromServices] IClienteService service)
    {
        var clientes = service.GetClientes().Take(10);
        var tenant = HttpContext.GetTenantInfo<TenantInfo>();
        return Ok(new
        {
            tenant,
            clientes
        });
    }
}