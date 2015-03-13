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
using System.Collections.Generic;

namespace Aerogear.Sync.Client
{

	/// <summary>
	/// An instance of this class will be able to handle tasks needed to implement
	/// Differential Synchronization for a specific type of documents.
	/// </summary>
	/// @param <T> The type of documents that this synchronizer can handle </param>
	/// @param <S> The type of <seealso cref="Edit"/>s that this synchronizer can handle </param>
	public interface ClientSynchronizer<T, S>
	{

		/// <summary>
		/// Called when the shadow should be patched. Is called when an update is recieved.
		/// </summary>
		/// <param name="edit"> the <seealso cref="Edit"/> containing the diffs/patches </param>
		/// <param name="shadowDocument"> the <seealso cref="ShadowDocument"/> to be patched </param>
		/// <returns> <seealso cref="ShadowDocument"/> a new patched shadow document </returns>
		ShadowDocument<T> PatchShadow(S edit, ShadowDocument<T> shadowDocument);

		/// <summary>
		/// Called when the document should be patched.
		/// </summary>
		/// <param name="edit"> the <seealso cref="Edit"/> containing the diffs/patches </param>
		/// <param name="document"> the <seealso cref="ClientDocument"/> to be patched </param>
		/// <returns> <seealso cref="ClientDocument"/> a new patched document. </returns>
		ClientDocument<T> PatchDocument(S edit, ClientDocument<T> document);

		/// <summary>
		/// Produces a <seealso cref="Edit"/> containing the changes between the updated <seealso cref="ClientDocument"/>
		/// and the <seealso cref="ShadowDocument"/>.
		/// <para>
		/// Calling the method is the first step in when starting a client side synchronization. We need to
		/// gather the changes between the updates made by the client and the shadow document.
		/// The produced {@code Edit} can then be passed to the server side.
		/// 
		/// </para>
		/// </summary>
		/// <param name="document"> the <seealso cref="ClientDocument"/> containing updates made by the client </param>
		/// <param name="shadowDocument"> the <seealso cref="ShadowDocument"/> for the {@code ClientDocument} </param>
		/// <returns> <seealso cref="Edit"/> the edit representing the diff between the client document and it's shadow document. </returns>
		S ServerDiff(ClientDocument<T> document, ShadowDocument<T> shadowDocument);

		/// <summary>
		/// Produces a <seealso cref="Edit"/> containing the changes between updated <seealso cref="ShadowDocument"/>
		/// and the <seealso cref="ClientDocument"/>.
		/// This method would be called when the client receives an update from the server and need
		/// to produce an {@code Edit} to be able to patch the {@code ClientDocument}.
		/// </summary>
		/// <param name="shadowDocument"> the <seealso cref="ShadowDocument"/> patched with updates from the server </param>
		/// <param name="document"> the <seealso cref="ClientDocument"/> </param>
		/// <returns> <seealso cref="Edit"/> the edit representing the diff between the shadow document and the client document. </returns>
		S ClientDiff(ShadowDocument<T> shadowDocument, ClientDocument<T> document);

		/// <summary>
		/// Creates a new <seealso cref="PatchMessage"/> with the with the type of <seealso cref="Edit"/> that this
		/// synchronizer can handle.
		/// </summary>
		/// <param name="documentId"> the document identifier for the {@code PatchMessage} </param>
		/// <param name="clientId"> the client identifier for the {@code PatchMessage} </param>
		/// <param name="edits"> the <seealso cref="Edit"/>s for the {@code PatchMessage} </param>
		/// <returns> <seealso cref="PatchMessage"/> the created {code PatchMessage} </returns>
		PatchMessage<S> CreatePatchMessage(string documentId, string clientId, LinkedList<S> edits);

		/// <summary>
		/// Creates a {link PatchMessage} by parsing the passed-in json.
		/// </summary>
		/// <param name="json"> the json representation of a {@code PatchMessage} </param>
		/// <returns> <seealso cref="PatchMessage"/> the created {code PatchMessage} </returns>
		PatchMessage<S> PatchMessageFromJson(string json);

		/// <summary>
		/// Adds the content of the passed in {@code content} to the <seealso cref="ObjectNode"/>.
		/// <para>
		/// When a client initially adds a document to the engine it will also be sent across the
		/// wire to the server. Before sending, the content of the document has to be added to the
		/// JSON message payload. Different implementation will require different content types that
		/// the engine can handle and this give them control over how the content is added to the JSON
		/// {@code ObjectNode}.
		/// For example, a ClientEngine that stores simple text will just add the contents as a String,
		/// but one that stores JsonNode object will want to add its content as an object.
		/// 
		/// </para>
		/// </summary>
		/// <param name="content"> the content to be added </param>
		/// <param name="objectNode"> the <seealso cref="ObjectNode"/> to add the content to </param>
		/// <param name="fieldName"> the name of the field </param>
		void AddContent(T content, object objectNode, string fieldName);

	}
}