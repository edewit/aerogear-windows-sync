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
    /// Represents a single edit.
    /// </summary>
    public interface Edit<T> where T: Diff
    {
        string ClientId { get; }
        string DocumentId { get; }

        /// <summary>
        /// The client version that edit is related to.
        /// </summary>
        /// <returns> {@code long} the client version that this edit is based on. </returns>
        long ClientVersion { get; }

        /// <summary>
        /// The server version that edit is related to.
        /// </summary>
        /// <returns> {@code long} the server version that this edit is based on. </returns>
        long ServerVersion { get; }

        /// <summary>
        /// A checksum of the opposing sides shadow document.
        /// The shadow document must patch strictly and this checksum is used to verify that the other sides
        /// shadow document is in fact the same. This can then be used by when before patching to make sure that
        /// the shadow documents on both sides are in fact identical.
        /// </summary>
        /// <returns> {@code String} the opposing side's checksum of the shadow document </returns>
        string Checksum { get; }

        /// <summary>
        /// The <seealso cref="Diff"/> for this edit.
        /// </summary>
        /// <returns> {@code T} the diff that represents the changes for this edit </returns>
        T GetDiff { get; }

    }
}