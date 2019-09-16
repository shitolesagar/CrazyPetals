using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Repository;
using CrazyPetals.Repository.Repositories;
using CrazyPetals.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CrazyPetals.WebApi
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IAppThemeRepository, AppThemeRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<ICartDetailsRepository, CartDetailsRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IColorsRepository, ColorsRepository>();
            services.AddScoped<IExternalLoginRepository, ExternalLoginRepository>();
            services.AddScoped<IFilterRepository, FilterRepository>();
            services.AddScoped<IForgotPasswordRepository, ForgotPasswordRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IProductImagesRepository, ProductImagesRepository>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISmtpMailRepository, SmtpMailRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<IVersionControlRepository, VersionControlRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IDelivery_chargeRepository, Delivery_chargeRepository>();
            services.AddScoped<IPaymentStatusRepository, PaymentStatusRepository>();
            services.AddScoped<IFullfillmentStatusRepository, FullfillmentStatusRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("defaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
