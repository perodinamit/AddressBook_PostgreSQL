using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook_PostgreSQL.Controllers;
using ContactBook_PostgreSQL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContactBook_PostgreSQL
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
            services.AddMvc();
            // Loading PosgreSQL
            services.AddEntityFrameworkNpgsql().AddDbContext<MyWebApiContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConection")));

            //  you will deploy this API somewhere and use it with some other application, 
            // then it will throw some CORS (cross-origin resurce sharing) related exceptions. 
            services.AddCors(option => option.AddPolicy("CORSPolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CORSPolicy");
            app.UseMvc();
        }
    }
}
