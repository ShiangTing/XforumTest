using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using XforumTest.Context;
using XforumTest.DataTable;
using XforumTest.DTO;
using XforumTest.Helpers;
using XforumTest.Interface;
using XforumTest.Repository;
using XforumTest.Services;

namespace XforumTest
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
            services.AddControllersWithViews();
            services.AddCors(options =>
            {

                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:8080")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            services.AddControllers();
            //  services.AddControllers().AddNewtonsoftJson();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            //Connecting String
            services.AddDbContext<MyDBContext>(opt => opt.UseSqlServer(Configuration["MyDBContext"]));

            services.AddTransient<IRepository<ForumMembers>, GeneralRepository<ForumMembers>>();
            services.AddTransient<IRepository<Posts>, GeneralRepository<Posts>>();
            services.AddTransient<IRepository<ForumRoles>, GeneralRepository<ForumRoles>>();
            services.AddTransient<IRepository<Forums>, GeneralRepository<Forums>>();
            services.AddTransient<IRepository<Titles>, GeneralRepository<Titles>>();
            services.AddTransient<IRepository<ReposiveMessages>, GeneralRepository<ReposiveMessages>>();
            services.AddTransient<IRepository<Titles>, GeneralRepository<Titles>>();
            services.AddTransient<IRepository<MemberTitle>,GeneralRepository<MemberTitle>>();


            services.AddTransient<IRepository<MessageLikeDto>, GeneralRepository<MessageLikeDto>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IJwtHelperService, JwtHelperService>();
            services.AddTransient<IMessageService, RMessageService>();
            services.AddTransient<ILikeService<PostLikeDto>, LikeService>();
            services.AddTransient<ILikeService<MessageLikeDto>, LikeService>();
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<IPostService, PostService>();
            services.AddControllers().AddNewtonsoftJson();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetValue<string>("JwtSettings:Issuer"),
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtSettings:SignKey")))
                };
            });

            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Version = "v1",
                //    Title = "ToDo API",
                //    Description = "A simple example ASP.NET Core Web API",
                //    TermsOfService = new Uri("https://example.com/terms"),
                //    Contact = new OpenApiContact
                //    {
                //        Name = "Shayne Boyer",
                //        Email = string.Empty,
                //        Url = new Uri("https://twitter.com/spboyer"),
                //    },
                //    License = new OpenApiLicense
                //    {
                //        Name = "Use under LICX",
                //        Url = new Uri("https://example.com/license"),
                //    }
                //});

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
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
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "HtmlPages")),
                RequestPath = "/HtmlPages"
            });
         //   app.UseExceptionHandler("/api/error");
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
