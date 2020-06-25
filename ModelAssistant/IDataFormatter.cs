using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAssistant {

    public interface IDataFormatter<T> {

        T Deserialize(Stream serializationStream);
        T Deserialize(string stringToDeserialize);

        void Serialize(Stream serializationStream, T objectToSerialize);
        string Serialize(T objectToSerialize);
    }
}
