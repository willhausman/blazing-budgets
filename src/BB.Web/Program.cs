using BB.Web.Components;
using BB.Web.Data;
using BB.Web.Domain;
using BB.Web.Domain.Actuals;
using Marten;
using Marten.Events;
using Marten.Events.Daemon.Resiliency;
using Marten.Events.Projections;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();

builder.Services.AddDbContextFactory<BlazingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BlazingBudgetsDb")));

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("BlazingBudgetsDb")!);
    options.UseSystemTextJsonForSerialization();
    options.Schema.For<Category>().Identity(_ => _.Value);
    options.Projections.Add<LedgerProjection>(ProjectionLifecycle.Inline);
    options.Events.AddEventType<TransactionPosted>();
    options.Events.AddEventType<LedgerCreated>();

    options.Events.StreamIdentity = StreamIdentity.AsString;
    if (builder.Environment.IsDevelopment())
    {
        options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
    }
}).AddAsyncDaemon(DaemonMode.Solo);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
