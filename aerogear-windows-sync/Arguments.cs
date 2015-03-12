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
