/*
 * JBoss, Home of Professional Open Source.
 * Copyright Red Hat, Inc., and individual contributors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writtrrting, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
