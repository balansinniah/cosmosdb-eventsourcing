using Balan.EventSourcing.Abstractions.Serialization;

namespace Balan.EventSourcing.Serialization.Json
{
    public interface IJsonObjectSerializer<T> : IObjectSerializer<T>
    {
    }
}
