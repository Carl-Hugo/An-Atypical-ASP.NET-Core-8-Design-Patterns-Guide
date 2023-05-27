using NinjaBeforeOCP;
using NinjaShared;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", async (HttpContext context) =>
{
    // Create actors
    var theBluePhantom = new Ninja("The Blue Phantom");
    var theUnseenMirage = new Ninja("The Unseen Mirage");

    // Execute the sequence of actions
    await Logic.ExecuteSequenceAsync(theBluePhantom, theUnseenMirage, writeAsync: s => context.Response.WriteAsync(s));
});
app.Run();
