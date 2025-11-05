using Library.Aplication.Services;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interface;
using Library.Persistence.Repositories;
using Library.Persistence.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Library.Persistence.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            services.AddScoped<IMongoDatabase>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DatabaseName);
            });

            // Registre seus repositórios aqui
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IGerenciadorTokenService, GerenciadorTokenService>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();


            // Mapear classes para o MongoDB Colocar em um metodo apartado
            MapearEnum();

            return services;
        }

        private static void MapearEnum()
        {
            BsonClassMap.RegisterClassMap<Usuario>(static cm =>
            {
                cm.AutoMap();
                cm.MapMember(c => c.TipoUsuario)
                    .SetSerializer(new EnumSerializer<TipoUsuario>(BsonType.String));
            });
            BsonClassMap.RegisterClassMap<Emprestimo>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(c => c.Status)
                    .SetSerializer(new EnumSerializer<StatusEmprestimo>(BsonType.String));
            });
            BsonClassMap.RegisterClassMap<Reserva>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(c => c.Status)
                    .SetSerializer(new EnumSerializer<StatusReserva>(BsonType.String));
            });
        }
    }
}