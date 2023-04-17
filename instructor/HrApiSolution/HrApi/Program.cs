var builder = WebApplication.CreateBuilder(args);
// the default web application builder has about 190+ "Services" that do all the work in your API.



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// before the application is built is above here services.
var app = builder.Build();
// after the application is built, how do you want to handle HTTP requests and responses.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Open API - the documentation.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers(); // it is going to create a phone directory.
// route table:
    // if someone does a GET /deparments:
            // create an instance of the DepartmentsController
            // Call the GetDepartments method.

app.Run(); // Starting the web server, and "blocking here"
