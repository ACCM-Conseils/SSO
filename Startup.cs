using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SO53654020.Infrastructure;

namespace SO53654020
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddAuthentication(o =>
                {
                    o.DefaultScheme = Constants.ApplicationScheme;
                    o.DefaultSignInScheme = Constants.SignInScheme;
                })
                .AddCookie(Constants.ApplicationScheme)
                .AddCookie(Constants.SignInScheme)
                .AddGoogle(o =>
                {
                    o.ClientId = "714516999404-hjs0u93mudrkm3ftb0n9n41kke7005mr.apps.googleusercontent.com";
                    o.ClientSecret = "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";
                });

            serviceCollection.AddMvc()
                .AddRazorPagesOptions(o => o.Conventions.AuthorizePage("/Index"));
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseDeveloperExceptionPage();
            applicationBuilder.UseHttpsRedirection();

            applicationBuilder.UseRouting();

            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpointRouteBuilder =>
            {
                endpointRouteBuilder.MapDefaultControllerRoute();
                endpointRouteBuilder.MapRazorPages();
            });
        }
    }
}
