using DoNotWaste;

var builder = WebApplication.CreateBuilder(args);

//Update configuration
builder.UpdateConfiguration();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add repository for dependency injection
builder.RegisterRepositories();

//Add service for dependency injection
builder.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();