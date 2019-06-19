using System;
using System.Collections.Generic;
using System.Text;

namespace Balan.EventSourcing.Abstractions.Serialization
{
    public interface IObjectSerializer<T>
    {
        string Serialize(T obj);
        T Deserialize(string serialized);
    }
}
