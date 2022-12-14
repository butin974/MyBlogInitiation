global using MyBlogInitiation.ViewModels;
using Microsoft.EntityFrameworkCore;
using MyBlogInitiation.Repository.Context;
using MyBlogInitiation.Repository.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//ADD entyty Framwork
builder.Services.AddDbContext<DbBlogContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDbContext")));
// "BlogDbContext = chaine de connection dans appsetting.json

//---------------------------------------------
//Exemple UseInMemoryDatabas
//builder.Services.AddDbContext<DbBlogContext>(options =>
//      options.UseInMemoryDatabase("TestMemoryDatabase"));
//---------------------------------------------


builder.Services.AddTransient<ArticlesPublicDAL>();



var mvcBuilder = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}   

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DbBlogContext>();
    //context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}




app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
