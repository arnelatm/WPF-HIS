using System;
using AATM.Contracts.Interfaces.Services;
using AATM.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace AATM.Core.Localization
{
    public static class LocalizationServiceRegistration
    {
        public static IServiceCollection AddLocalizationServiceFactory(this IServiceCollection services)
        {
            services.AddSingleton<Func<string, string, ILocalizationService>>(sp =>
                (language, module) =>
                {
                    var repo = sp.GetRequiredService<ITranslationRepository>();
                    return new LocalizationService(language, module, repo);
                });
            return services;
        }

        public static IServiceCollection AddDefaultLocalizationService(this IServiceCollection services, string language, string module)
        {
            services.AddSingleton<ILocalizationService>(sp =>
            {
                var factory = sp.GetRequiredService<Func<string, string, ILocalizationService>>();
                return factory(language, module);
            });
            return services;
        }
    }
}