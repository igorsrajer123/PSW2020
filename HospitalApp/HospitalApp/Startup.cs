using Grpc.Core;
using HospitalApp.Contracts;
using HospitalApp.Handlers;
using HospitalApp.Models;
using HospitalApp.Protos;
using HospitalApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HospitalApp
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
            services.AddGrpc();
            services.AddControllers();

            services.AddDbContext<MyDbContext>(options =>
                     options.UseSqlServer(ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString")).UseLazyLoadingProxies());

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAdministratorService, AdministratorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReferralService, ReferralService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
       
            services.AddRazorPages().WithRazorPagesRoot("/Views");

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddHostedService<ClientScheduledService>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        private Server server;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapGrpcService<ClientScheduledService>();
            });

            app.UseCors("MyPolicy");

            server = new Server
            {
                Services = { NetGrpcService.BindService(new NetGrpcServiceImpl()) },
                Ports = { new ServerPort("localhost", 4111, ServerCredentials.Insecure) }
            };
            server.Start();

            applicationLifetime.ApplicationStopping.Register(OnShutdown);
        }

        private void OnShutdown()
        {
            if (server != null)
                server.ShutdownAsync().Wait();
        }
    }
}
