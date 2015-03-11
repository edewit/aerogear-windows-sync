/// <summary>
/// JBoss, Home of Professional Open Source
/// Copyright Red Hat, Inc., and individual contributors.
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
/// 	http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// </summary>
namespace Aerogear.Sync.Client
{
	/// <summary>
	/// A client side <seealso cref="DataStore"/> implementation is responsible for storing and serving data for a
	/// Differential Synchronization implementation.
	/// </summary>
	/// @param <T> The type of the Document that this data store can handle. </param>
	/// @param <S> The type of <seealso cref="Edit"/>s that this synchronizer can handle </param>
	public interface ClientDataStore<T, S> : DataStore<T, S> where S : Edit<Diff>
	{

		/// <summary>
		/// Saves a client document.
		/// </summary>
		/// <param name="document"> the <seealso cref="ClientDocument"/> to save. </param>
		void SaveClientDocument(ClientDocument<T> document);

		/// <summary>
		/// Retrieves the <seealso cref="Document"/> matching the passed-in document documentId.
		/// </summary>
		/// <param name="documentId"> the document identifier of the document. </param>
		/// <param name="clientId"> the client identifier for which to fetch the document. </param>
		/// <returns> <seealso cref="ClientDocument"/> the document matching the documentId. </returns>
		ClientDocument<T> GetClientDocument(string documentId, string clientId);

	}
}