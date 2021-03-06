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
    /// A shadow document for each client will exist on the client side and also on the server side.
    /// <para>
    /// A shadow document is updated after a successful patch has been performed.
    /// 
    /// </para>
    /// </summary>
    /// @param <T> The type of the Document that this instance shadows. </param>
    public class ShadowDocument<T>
    {

        /// <summary>
        /// Represents the latest server version that the this shadow document was based on.
        /// </summary>
        /// <returns> {@code long} the server version. </returns>
        public long ServerVersion {get; protected set;}

        /// <summary>
        /// Represents the latest client version that this shadow document was based on.
        /// </summary>
        /// <returns> {@code long} the client version. </returns>
        public long ClientVersion { get; protected set; }

        /// <summary>
        /// The document itself.
        /// </summary>
        /// <returns> T the document. </returns>
        public ClientDocument<T> Document { get; protected set; }

        public ShadowDocument(long serverVersion, long clientVersion, ClientDocument<T> document)
        {
            this.ServerVersion = serverVersion;
            this.ClientVersion = clientVersion;
            this.Document = document;
        }

    }
}