﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
                    o.ClientId = "...";
                    o.ClientSecret = "...";
                });

            serviceCollection.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(o => o.Conventions.AuthorizePage("/Index"));
        }

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            applicationBuilder.UseDeveloperExceptionPage();
            applicationBuilder.UseAuthentication();
            applicationBuilder.UseMvcWithDefaultRoute();
        }
    }
}
