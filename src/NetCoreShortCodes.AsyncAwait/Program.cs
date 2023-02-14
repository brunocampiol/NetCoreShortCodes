using NetCoreShortCodes.AsyncAwait;

// No difference - throws exception
//await AsyncClass.SkipLinesNonCompliantAsync(null, 0);
//await AsyncClass.SkipLinesCompliantAsync(null, 0);

// Fire and forget, compliant solution ONLY throws exception
//_ = AsyncClass.SkipLinesNonCompliantAsync(null, 0);
//_ = AsyncClass.SkipLinesCompliantAsync(null, 0);

// Throws exception
var tasks = new List<Task>();
tasks.Add(AsyncClass.SkipLinesNonCompliantAsync(null, 0));
tasks.Add(AsyncClass.SkipLinesCompliantAsync(null, 0));
await Task.WhenAll(tasks);