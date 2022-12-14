using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UsuarioAPI.Data;
using UsuarioAPI.Models;
using UsuarioAPI.Services;

namespace UsuarioAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurando seviço de acesso ao banco de dados
            services.AddDbContext<UserDbContext>(options => 
            options.UseMySQL(Configuration.GetConnectionString("UsuarioConnection")));
            // Configurando Identity
            services.AddIdentity<CustomIdentityUser, IdentityRole<int>>(
                opt => opt.SignIn.RequireConfirmedEmail = true // Exige a confirmação do email
            )
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders(); // Defini o token provider
            // Configurar os Services
            services.AddScoped<CadastroService, CadastroService>();        
            services.AddScoped<LoginService, LoginService>(); 
             services.AddScoped<LogoutService, LogoutService>(); 
            services.AddScoped<TokenService, TokenService>(); 
            services.AddScoped<EmailService, EmailService>();
            services.AddControllers();

            // Adicionando serviço do AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Configurao padrão de senha do Identity
            // services.Configure<IdentityOptions>(options =>
            // {
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireUppercase = false;
            //     options.Password.RequiredLength = 8;
            // });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UsuarioAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuarioAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
