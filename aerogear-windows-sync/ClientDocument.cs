﻿/*
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
    /// A client document is used on both the server and client side and
    /// associates a client identifier with a <seealso cref="Document"/>.
    /// </summary>
    /// @param <T> the type of this documents content. </param>
    public class ClientDocument<T> : Document<T>
    {

        /// <summary>
        /// Identifies a client or session to which this Document belongs.
        /// </summary>
        /// <returns> {@code String} the client identifier. </returns>
        public string ClientId { get; protected set; }

        public ClientDocument(string id, string clientId, T content)
            : base(id, content)
        {
            ClientId = clientId;
        }
    }
}