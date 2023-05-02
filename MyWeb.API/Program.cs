using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
{

    //her fomaine izin verilir
    //opts.AddDefaultPolicy(builder =>
    //{
    //    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    //});

    //girilen domainin tüm metotlarýna izin veilir
    //opts.AddPolicy("AllowSites", builder =>
    //{
    //    builder.WithOrigins("https://localhost:7165").AllowAnyHeader().AllowAnyMethod();
    //});

    //girilen domainin headerýnda örnek cümle olanlara izin verilir. benzeri metot için yapýlabilir
    //opts.AddPolicy("AllowSites2", builder =>
    //{
    //    builder.WithOrigins("https://mysite.com").WithHeaders(HeaderNames.ContentType, "x-custom-header");
    //});

    // örnek websitesindeki subdomainlerin hepsi
    opts.AddPolicy("AllowSites", builder =>
    {
        builder.WithOrigins("https://*.example.com").SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyHeader().AllowAnyMethod();
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseCors("AllowSites2");

app.UseAuthorization();

app.MapControllers();

app.Run();
