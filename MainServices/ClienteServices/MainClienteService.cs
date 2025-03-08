using Bogus;
using Bogus.Extensions.Brazil;
using Domain.DataTransferObjects;

namespace MainServices.ClienteServices;

public class MainClienteService : IClienteService
{
    public IEnumerable<Cliente> GetClientes()
    {
        var faker = new ClienteFaker();
        faker.UseSeed(100);
        return faker.GenerateForever();
    }
}

public class ClienteFaker : Faker<Cliente>
{
    public ClienteFaker() : base("pt_BR")
    {
        base.RuleFor(p => p.Id, f => f.Random.Guid());
        base.RuleFor(p => p.NomeRazaoSocial, f => f.Company.CompanyName());
        base.RuleFor(p => p.NomeFantasia, f => f.Company.CompanyName(1));
        base.RuleFor(p => p.Documento, f => f.Company.Cnpj());
        base.RuleFor(o => o.Email, faker => faker.Internet.Email(provider: "MainCliente.com.br"));
    }
}