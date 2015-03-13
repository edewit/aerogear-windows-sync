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
	/// Represents a stack of changes made on the server of client side.
	/// <para>
	/// A PatchMessage is what is passed between the client and the server. It contains a Queue of
	/// <seealso cref="Edit"/>s that represent updates to be performed on the opposing sides document.
	/// 
	/// </para>
	/// </summary>
	/// @param <T> The type of the <seealso cref="Edit"/> that this PatchMessage holds </param>
	public interface PatchMessage<T> : Payload<PatchMessage<T>>
	{

		/// <summary>
		/// Identifies the client that this edit instance belongs to.
		/// </summary>
		/// <returns> {@code String} the client identifier. </returns>
		string clientId();

		/// <summary>
		/// Identifies the document that this edit is related to
		/// </summary>
		/// <returns> {@code String} the document documentId. </returns>
		string documentId();

		/// <summary>
		/// The individual <seealso cref="Edit"/>s.
		/// </summary>
		/// <returns> {@code Queue<Edit>} the individual edits. </returns>
		LinkedList<T> edits();

	}
}