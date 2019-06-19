using Balan.EventSourcing.Abstractions.DependencyInjection;
using Balan.EventSourcing.Abstractions.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Balan.EventSourcing.Serialization.Json
{
    public static class SerializationJsonEventSourcingBuilderExtensions
    {
        public static IEventSourcingBuilder UseJsonEventSerializer(
            this IEventSourcingBuilder builder)
        {
            builder.Services
                .AddScoped(typeof(IObjectSerializer<>), typeof(JsonObjectSerializer<>))
                .AddScoped(typeof(IJsonObjectSerializer<>), typeof(JsonObjectSerializer<>))
                ;
            return builder;
        }
    }
}
