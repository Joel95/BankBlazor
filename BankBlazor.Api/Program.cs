
using BankBlazor.Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BankContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<Services.CustomerService>();
            builder.Services.AddScoped<Services.AccountService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowClient",policy =>
                {
                    policy.WithOrigins("https://localhost:7249" , "https://localhost:5279") // React app URL
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowClient");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
