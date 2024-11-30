using FakeBookData.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();
    builder.Services.RegisterApplication();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.MapControllers();
}

app.Run();