﻿using NinjaOCP;
using NinjaShared;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", async (HttpContext context) =>
{
    // Create actors
    var theBluePhantom = new Ninja("The Blue Phantom", new Sword(), new Shuriken());
    var theUnseenMirage = new Ninja("The Unseen Mirage", new Sword(), new Pistol());

    // Execute the sequence of actions
    await Logic.ExecuteSequenceAsync(theBluePhantom, theUnseenMirage, writeAsync: s => context.Response.WriteAsync(s));
});
app.MapGet("/old", async (HttpContext context) =>
{
    // Create actors
    var theBluePhantom = new Ninja("The Blue Phantom", new Sword(), new Shuriken());
    var theUnseenMirage = new Ninja("The Unseen Mirage", new Sword(), new Shuriken());

    // Execute the sequence of actions
    await Logic.ExecuteSequenceAsync(theBluePhantom, theUnseenMirage, writeAsync: s => context.Response.WriteAsync(s));
});
app.Run();
