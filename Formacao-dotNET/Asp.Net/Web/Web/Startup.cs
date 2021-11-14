using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Web
{
    public class Startup
    {
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ICatalogo, Catalogo>(); //Add Transient gera sempre uma nova instancia ao chamar o GetService com uma instancia temporaria do serviço solicitado
            //services.AddTransient<IRelatorio, Relatorio>();

            //services.AddScoped<ICatalogo, Catalogo>(); //Add Scoped - Vai sempre obter umä única instancia do serviço para cada requisição
            //services.AddScoped<IRelatorio, Relatorio>();

            var catalogo = new Catalogo();
            services.AddSingleton<ICatalogo>(catalogo); //Add Singleton gera uma instacia única ao longo da aplicação, não importa em qual requisição esteja, sempre trabalha com a mesma instncia
            services.AddSingleton<IRelatorio>(new Relatorio(catalogo));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();

            app.Run(async (context) =>
            {
                await relatorio.ImprimeRelatorio(context);
            });
        }
    }
}
