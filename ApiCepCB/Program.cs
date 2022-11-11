using ApiCepCB.GraphQL.Schemas;
using ApiCepCB.Services;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using RestEase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(
    RestClient.For<IApiViaCepService>("https://viacep.com.br/"));

builder.Services.AddScoped<IDependencyResolver>(s => 
    new FuncDependencyResolver(s.GetRequiredService));

builder.Services.AddScoped<GraphSchema>();
builder.Services.AddGraphQL()
    .AddGraphTypes(ServiceLifetime.Scoped);

var app = builder.Build();

app.UseGraphQL<GraphSchema>();
app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
