using ClientAhServices;
using ClienteBhServices;
using ClienteChServices;
using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Abstractions;
using MainServices.ClienteServices;
using WebApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMultiTenant<TenantInfo>()
    .WithBasePathStrategy(opt => { opt.RebaseAspNetCorePathBase = true; })
    .WithStore<WebApiTenantStore>(ServiceLifetime.Singleton);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MainClienteService>();
builder.Services.AddScoped<ClienteAhService>();
builder.Services.AddScoped<ClienteBhService>();
builder.Services.AddScoped<ClienteChService>();
builder.Services.AddScoped<IClienteService>(sp =>
{
    var info = sp.GetRequiredService<IMultiTenantContextAccessor>();
    var tenant = info.MultiTenantContext.TenantInfo;
    return tenant?.Identifier switch
    {
        "a" => sp.GetRequiredService<ClienteAhService>(),
        "b" => sp.GetRequiredService<ClienteBhService>(),
        "c" => sp.GetRequiredService<ClienteChService>(),
        "default" => sp.GetRequiredService<MainClienteService>(),
        _ => throw new Exception("Tenant inválido")
    };
});


var app = builder.Build();

app.MapControllers();

app.UseRouting();
app.UseMultiTenant();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();