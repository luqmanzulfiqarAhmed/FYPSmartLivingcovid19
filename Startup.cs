using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using smartLiving;

using smartLiving.Repostries;

namespace TestProjectProperty
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<PropertyRepositry>();
            services.AddScoped<SocietyRepositry>();
            services.AddScoped<AdminRepositry>();
            services.AddScoped<VehicleRepositry>();
            services.AddScoped<AnnouncementRepositry>();
            services.AddScoped<ComplainRepositry>();
            services.AddScoped<EmergencyTaskResponseRepositry>();
            services.AddScoped<EmployeeRepositry>();
            services.AddScoped<GoodsOrderingRepositry>();
            services.AddScoped<GraveBookingRepositry>();
            services.AddScoped<MaintainanceTaskResponseRepositry>();
            services.AddScoped<MarriageHallReservationRepositry>();
            services.AddScoped<ResidentRepositry>();
            services.AddScoped<Notification>();
            services.AddScoped<TransportRepositry>();
            services.AddScoped<ManageBillRepositry>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
