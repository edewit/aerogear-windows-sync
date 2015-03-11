using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerogear.Sync
{
    /// <summary>
    /// Represents something that can be exchanged in JSON format.
    /// </summary>
    /// <typeparam name="T">the type of the payload</typeparam>
    public interface Payload<T>
    {
        /// <summary>
        /// Transforms this payload to a JSON String representation.
        /// </summary>
        /// <returns>the payload as a JSON String representation</returns>
        string AsJson();

        /// <summary>
        /// Transforms the passed in string JSON representation into this payloads type.
        /// </summary>
        /// <param name="json">a string representation of this payloads type</param>
        /// <returns>an instance of this payloads type</returns>
        T FromJson(string json);
    }
}
