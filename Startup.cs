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
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
            .AddEntityFrameworkStores<UserDbContext>();
            // Configurar os Services
            services.AddScoped<CadastroService, CadastroService>();        
            services.AddScoped<LoginService, LoginService>(); 
            services.AddControllers();

            // Adcionando serviço do AutoMapper
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
