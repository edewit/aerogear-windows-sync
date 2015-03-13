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
using System.Collections.Generic;

namespace Aerogear.Sync
{

	/// <summary>
	/// A DataStore implementation is responsible for storing and serving data for a
	/// Differential Synchronization implementation.
	/// </summary>
	/// @param <T> The type of the Document that this data store can store. </param>
	/// @param <S> The type of <seealso cref="Edit"/>s that this data store can store </param>
	public interface DataStore<T, S>
	{

		/// <summary>
		/// Saves a shadow document.
		/// </summary>
		/// <param name="shadowDocument"> the <seealso cref="ShadowDocument"/> to save. </param>
		void SaveShadowDocument(ShadowDocument<T> shadowDocument);

		/// <summary>
		/// Retrieves the <seealso cref="ShadowDocument"/> matching the passed-in document documentId.
		/// </summary>
		/// <param name="documentId"> the document id of the shadow document. </param>
		/// <param name="clientId"> the client for which to retrieve the shadow document. </param>
		/// <returns> <seealso cref="ShadowDocument"/> the shadow document matching the documentId. </returns>
		ShadowDocument<T> GetShadowDocument(string documentId, string clientId);

		/// <summary>
		/// Saves a backup shadow document
		/// </summary>
		/// <param name="backupShadow"> the <seealso cref="BackupShadowDocument"/> to save. </param>
		void SaveBackupShadowDocument(BackupShadowDocument<T> backupShadow);

		/// <summary>
		/// Retrieves the <seealso cref="BackupShadowDocument"/> matching the passed-in document documentId.
		/// </summary>
		/// <param name="documentId"> the document identifier of the backup shadow document. </param>
		/// <param name="clientId"> the client identifier for which to fetch the document. </param>
		/// <returns> <seealso cref="BackupShadowDocument"/> the backup shadow document matching the documentId. </returns>
		BackupShadowDocument<T> GetBackupShadowDocument(string documentId, string clientId);

		/// <summary>
		/// Saves an <seealso cref="Edit"/> to the data store.
		/// </summary>
		/// <param name="edit"> the edit to be saved. </param>
		/// <param name="documentId"> the document identifier for the edit </param>
		/// <param name="clientId"> the client identifier for the edit </param>
		void SaveEdits(S edit, string documentId, string clientId);

		/// <summary>
		/// Retreives the queue of <seealso cref="Edit"/>s for the specified document documentId.
		/// </summary>
		/// <param name="documentId"> the document identifier of the edit. </param>
		/// <param name="clientId"> the client identifier for which to fetch the document. </param>
		/// <returns> {@code Queue<S>} the edits for the document. </returns>
		LinkedList<S> GetEdits(string documentId, string clientId);

		/// <summary>
		/// Removes the edit from the store.
		/// </summary>
		/// <param name="edit"> the edit to be removed. </param>
		/// <param name="documentId"> the document identifier for the edit </param>
		/// <param name="clientId"> the client identifier for the edit </param>
		void RemoveEdit(S edit, string documentId, string clientId);

		/// <summary>
		/// Removes all edits for the specific client and document pair.
		/// </summary>
		/// <param name="documentId"> the document identifier of the edit. </param>
		/// <param name="clientId"> the client identifier. </param>
		void RemoveEdits(string documentId, string clientId);

	}
}