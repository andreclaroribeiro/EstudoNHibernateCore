using EstudoNHibernateCore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EstudoNHibernateCore.Infra.Extension;

namespace EstudoNHibernateCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.ConfigureSessionDataBase(Configuration);

            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}