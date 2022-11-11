using ApiCepCB.Facade;
using ApiCepCB.Facade.Interfaces;
using ApiCepCB.Services;
using RestEase;

using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

using ApiCepCB.GraphQL;
using Microsoft.AspNetCore.Server.Kestrel.Core;

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

builder.Services.AddScoped<ICepFacade, CepFacade>();

/*builder.Services.AddSingleton(
    RestClient.For<IApiCepService>(Environment.GetEnvironmentVariable("API_CEP_URI")));*/

builder.Services.AddSingleton(
    RestClient.For<IApiViaCepService>("https://viacep.com.br/"));

builder.Services.AddScoped<IDependencyResolver>
    (s => new FuncDependencyResolver(s.GetRequiredService));

builder.Services.AddScoped<IDependencyResolver>
    (s => new FuncDependencyResolver(s.GetRequiredService));

builder.Services.AddScoped<GraphSchema>();
builder.Services.AddGraphQL().AddGraphTypes(ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();

}

app.UseGraphQL<GraphSchema>();
app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
