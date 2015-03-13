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
    /// A backup of the ShadowDocument.
    /// </summary>
    /// @param <T> The type of the Document that this instance backups. </param>
    public interface BackupShadowDocument<T>
    {

        /// <summary>
        /// Represents the version of this backup shadow.
        /// </summary>
        /// <returns> {@code long} the server version. </returns>
        long version();

        /// <summary>
        /// The <seealso cref="ShadowDocument"/> that this instance is backing up.
        /// </summary>
        /// <returns> <seealso cref="ShadowDocument"/> that this instance is backing up. </returns>
        ShadowDocument<T> shadow();

    }
}