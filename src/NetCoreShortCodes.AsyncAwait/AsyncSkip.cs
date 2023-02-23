namespace NetCoreShortCodes.AsyncAwait
{
    internal static class AsyncSkip
    {
        // Because of the way async/await methods are rewritten by the compiler,
        // any exceptions thrown during the parameters check will happen only
        // when the task is observed.That could happen far away from the
        // source of the buggy code or never happen for fire-and-forget tasks.

        // Therefore it is recommended to split the method into two: an outer
        // method handling the parameter checks (without being async/await)
        // and an inner method to handle the iterator block with the
        // async/await pattern.

        public static async Task SkipLinesNonCompliantAsync(this TextReader reader, int linesToSkip) 
        {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            if (linesToSkip < 0) { throw new ArgumentOutOfRangeException(nameof(linesToSkip)); }

            for (var i = 0; i < linesToSkip; ++i)
            {
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                if (line == null) { break; }
            }
        }

        public static Task SkipLinesCompliantAsync(this TextReader reader, int linesToSkip)
        {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            if (linesToSkip < 0) { throw new ArgumentOutOfRangeException(nameof(linesToSkip)); }

            return reader.SkipLinesInternalAsync(linesToSkip);
        }

        private static async Task SkipLinesInternalAsync(this TextReader reader, int linesToSkip)
        {
            for (var i = 0; i < linesToSkip; ++i)
            {
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                if (line == null) { break; }
            }
        }
    }
}