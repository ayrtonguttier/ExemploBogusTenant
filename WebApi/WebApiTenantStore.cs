using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Abstractions;

namespace WebApi;

public class WebApiTenantStore : IMultiTenantStore<TenantInfo>
{
    private Dictionary<string, TenantInfo?> _tenants = new()
    {
        {
            "default", new TenantInfo()
            {
                Id = "default",
                Identifier = "default",
                Name = "Default"
            }
        },
        {
            "a", new TenantInfo()
            {
                Id = "a",
                Identifier = "a",
                Name = "Tenant a"
            }
        },
        {
            "b", new TenantInfo()
            {
                Id = "b",
                Identifier = "b",
                Name = "Tenant b"
            }
        },
        {
            "c", new TenantInfo()
            {
                Id = "c",
                Identifier = "c",
                Name = "Tenant c"
            }
        }
    };

    public Task<bool> TryAddAsync(TenantInfo tenantInfo)
    {
        if (tenantInfo.Id is null)
        {
            return Task.FromResult(false);
        }

        _tenants[tenantInfo.Id] = tenantInfo;
        return Task.FromResult(true);
    }

    public Task<bool> TryUpdateAsync(TenantInfo tenantInfo)
    {
        if (tenantInfo.Id is null)
        {
            return Task.FromResult(false);
        }

        _tenants[tenantInfo.Id] = tenantInfo;
        return Task.FromResult(true);
    }

    public Task<bool> TryRemoveAsync(string identifier)
    {
        var item = _tenants
            .FirstOrDefault(x => identifier.Equals(x.Value?.Identifier));
        _tenants.Remove(item.Key);
        return Task.FromResult(true);
    }

    public Task<TenantInfo?> TryGetByIdentifierAsync(string identifier)
    {
        var item = _tenants
            .FirstOrDefault(x => identifier.Equals(x.Value?.Identifier));

        return Task.FromResult(item.Value);
    }

    public Task<TenantInfo?> TryGetAsync(string id)
    {
        return Task.FromResult(_tenants[id]);
    }

    public Task<IEnumerable<TenantInfo>> GetAllAsync()
    {
        var todos = _tenants.Where(x => x.Value is not null).Select(x => x.Value!);
        return Task.FromResult(todos);
    }
}