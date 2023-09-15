using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Infrascructure.Cart;
using RepositoryLayer.Infrascructure.Categories;
using RepositoryLayer.Infrascructure.Company;
using RepositoryLayer.Infrascructure.Login;
using RepositoryLayer.Infrascructure.Products;
using RepositoryLayer.Infrascructure.Registration;
using RepositoryLayer.Infrascructure.User;
using RepositoryLayer;
using ServiceLayer.Property.CartService;
using ServiceLayer.Property.Category;
using ServiceLayer.Property.CompanyService;
using ServiceLayer.Property.LoginService;
using ServiceLayer.Property.ProductServce;
using ServiceLayer.Property.RegisterService;
using ServiceLayer.Property.UserProfileService;
using ServiceLayer.Property.UserService;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using TestOnion.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                  options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
              });

builder.Services.AddScoped(typeof(IUserLogic<>), typeof(UserLogic<>));
builder.Services.AddScoped(typeof(IRegistration<>), typeof(RegistrationLogic<>));
builder.Services.AddScoped(typeof(ILogin<>), typeof(LoginLogic<>));
builder.Services.AddScoped(typeof(ICompany<>), typeof(CompanyLogic<>));
builder.Services.AddScoped(typeof(IProducts<>), typeof(ProductLogic<>));
builder.Services.AddScoped(typeof(ICart<>), typeof(CartLogic<>));
builder.Services.AddScoped(typeof(ICategories<>), typeof(CategoriesLogic<>));
builder.Services.AddTransient<IUserProfileService, UserProfileService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
