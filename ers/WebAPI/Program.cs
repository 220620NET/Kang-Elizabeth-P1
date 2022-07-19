
using Services;
using CustomExceptions;
using DataAccess;
using Models;
using WebAPI.Controller;

/// look at fetchAPI for HTML 

// List<Ticket> tixs = new TicketServices().GetReimbursementByUserID(2);

// for(int i = 0; i < tixs.Count; i++)
// {
//     Console.WriteLine(tixs[i]);
// }

var builder = WebApplication.CreateBuilder(args);

//dependency injection handled by ASP.NET Core
//Different ways to add your dependencies: Singleton, Scoped, Transient
//Singleton instances are shared throughtout the entire lifetime of the application
//Scoped instances are shared during the req/res lifecycle
//Transient instances are generated everytime it needs an instance of it

//User STACK
builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("elizabethDB")));
builder.Services.AddScoped<IUserDAO, UserRepository>();
builder.Services.AddTransient<AuthServices>();
builder.Services.AddTransient<AuthController>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<UserController>();

//Ticket STACK
builder.Services.AddScoped<ITicketDAO, TicketRepository>();
builder.Services.AddTransient<TicketServices>();
builder.Services.AddTransient<TicketRepository>();
builder.Services.AddTransient<TicketController>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


//Testing all Ticket Repository Methods :)

app.Run();