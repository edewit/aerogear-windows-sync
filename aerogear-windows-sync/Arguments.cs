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
using System;

namespace Aerogear.Sync
{
    public sealed class Arguments
    {

        private Arguments()
        {
        }

        /// <summary>
        /// Checks that the given argument is not null. If it is, throws <seealso cref="ArgumentNullException"/>.
        /// Otherwise, returns the argument.
        /// </summary>
        /// <param name="arg"> the argument to check. </param>
        /// <param name="text"> the text to display if the {@code arg} was null </param>
        public static T checkNotNull<T>(T arg, string text)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(text);
            }
            return arg;
        }
    }
}
