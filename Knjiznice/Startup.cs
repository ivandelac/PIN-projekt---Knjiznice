using KnjizniceData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using KnjizniceServisi;

namespace Knjiznice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }  //

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //pozivamo "Configuration" objekt koji poziva metodu GetConnectionString čime EntityFrameworku osiguravamo kontekst prilikom izgradnje aplikacije
            services.AddDbContext<KnjizniceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KnjizniceKonekcija")));

            services.AddSingleton(Configuration);
            services.AddScoped<IGradjaKnjiznice, GradjaKnjizniceServis>(); // GradjaKnjizniceServis će se injectati u KatalogController svaki put kad 
                                                                           //kontroler zahtjeva metodu preko IGradjaKnjiznice interface (framework dependency injection, injectanje servisa u druge dijelove aplikacije)
            services.AddScoped<IPosudba, PosudbeServis>();
            services.AddScoped<IClan, ClanServis>();
            services.AddScoped<IKnjiznica, KnjiznicaServis>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();  
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
