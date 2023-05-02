using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Backend.Services.DBContext;
using Backend.Services.Repositories;
using Backend.Schema.Mutation;
using Backend.Schema.Queries;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("PostgresConnection");

builder.Services.AddDataProtection();

builder.Services.AddAuthorization();

builder.Services.AddPooledDbContextFactory<PostgresContext>(options => options.UseNpgsql(connection));
builder.Services.AddScoped<OrderRepository>();

builder.Services
	.AddGraphQLServer()
	.AddAuthorization()
	.AddQueryType<Query>()
	.AddMutationType<Mutation>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });

app.Run();