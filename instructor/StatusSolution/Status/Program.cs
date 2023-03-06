using Status;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/status", () =>
{
    // get the data from a database, or whatever..
    var statusMessage = new StatusMessage(Guid.NewGuid(), "Looks Good", DateTimeOffset.Now);
    return Results.Ok(statusMessage);
});

app.Run(); // "Block" 









//var statusMessage = new StatusMessage(Guid.NewGuid(), "Looks Good", DateTimeOffset.Now);

//Console.WriteLine($"The id {statusMessage.Id} status: {statusMessage.Message} at {statusMessage.When}");