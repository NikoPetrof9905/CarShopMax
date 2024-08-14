using CarShopMax.Model;
using CarShopMax.Model.MappingProfiles;
using CarShopMax.Model.Open.Validation;
using CarShopMax.Services;
using CarShopMax.Services.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/login");
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.AccessDeniedPath = "/Error/AccessDenied";
    });

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOfferRepository, OfferRepository>();

builder.Services.AddAutoMapper(bld =>
{
    bld.AddProfile(new CarShopMaxInternalProfile());
});

builder.Services.AddDbContext<CarShopMaxContext>();
using var cont = new CarShopMaxContext();
cont.Database.EnsureCreated();

builder.Services.AddValidatorsFromAssemblyContaining<CredentialsValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CarShopMax.Model.Validation.UserValidator>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
