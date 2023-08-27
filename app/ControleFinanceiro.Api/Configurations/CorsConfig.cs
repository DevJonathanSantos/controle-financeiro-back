namespace ControleFinanceiro.Api.Configurations;

public static class CorsConfig
{
    public static IServiceCollection AddCORS(this IServiceCollection services, IConfiguration configuration)
    {
        var corsURLs = configuration.GetSection("CORSAllowedURLs").Get<string[]>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                if (corsURLs.Any()) builder.WithOrigins(corsURLs);
                builder.AllowCredentials();
            });
        });

        return services;
    }
}
