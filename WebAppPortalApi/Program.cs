using WebAppPortalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiExtensions();
builder.AddDataExtensions();
builder.AddEventLogExtensions();

var app = builder.Build();

app.UseApiExtensions();
app.UseRequestLogExtensions();
app.UseEventLogExtensions();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
