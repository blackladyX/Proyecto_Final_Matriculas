
using Matriculas.Web.Data;
using Matriculas.Web.Data.Entities;
using Matriculas.Web.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Startup
{
    public Startup(IConfiguration configuration )
    {
        Configuration = configuration;

    }

    public IConfiguration Configuration { get;  }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        services.AddIdentity<User, IdentityRole>(cfg =>
    {
        cfg.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
        cfg.SignIn.RequireConfirmedEmail = true;
        cfg.User.RequireUniqueEmail = true;
        cfg.Password.RequireDigit = false;
        cfg.Password.RequiredUniqueChars = 0;
        cfg.Password.RequireLowercase = false;
        cfg.Password.RequireNonAlphanumeric = false;
        cfg.Password.RequireUppercase = false;
    })
     .AddDefaultTokenProviders()
     .AddEntityFrameworkStores<ApplicationDbContext>();
     services.AddAuthentication()
     .AddCookie()
     .AddJwtBearer(cfg =>
    {
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = Configuration["Tokens:Issuer"],
            ValidAudience = Configuration["Tokens:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
        };
    });



        services.AddDbContext<ApplicationDbContext>(cfg =>
        {
            cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        });
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/NotAuthorized";
            options.AccessDeniedPath = "/Account/NotAuthorized";
        });

        
        services.AddTransient<SeedDb>();
        services.AddScoped<IBlobHelper, BlobHelper>();
        services.AddScoped<IConverterHelper, ConverterHelper>();
        services.AddScoped<ICombosHelper, CombosHelper>();
        services.AddScoped<IUserHelper, UserHelper>();
        services.AddScoped<IMailHelper, MailHelper>();
        services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseStatusCodePagesWithReExecute("/error/{0}");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCookiePolicy();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

    });
    }
}

