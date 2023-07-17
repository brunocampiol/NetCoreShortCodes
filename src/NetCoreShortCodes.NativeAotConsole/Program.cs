using System.Diagnostics;

// Native AOT deployment example

// Limitations of native AOT deployment
// https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=net7#limitations-of-native-aot-deployment

var sw = Stopwatch.StartNew();
var targetNumber = (args == null || args.Length == 0) ? 499999 : int.Parse(args[0]);
var primeCount = PrintPrimeAndCount(targetNumber);

Console.WriteLine($"There are '{primeCount}' prime numbers in the range from '0' to '{targetNumber}'");
Console.WriteLine($"Completed in {sw.Elapsed}");
Console.WriteLine("Press any key to exit");
Console.ReadKey();

bool IsPrime(int n)
{
    // Corner case
    if (n <= 1) return false;

    // Check from 2 to n-1
    for (int i = 2; i < n; i++)
        if (n % i == 0)
            return false;

    return true;
}

int PrintPrimeAndCount(int n)
{
    int primeCount = 0;
    for (int i = 2; i <= n; i++)
    {
        if (IsPrime(i))
        {
            Console.WriteLine(i);
            primeCount++;
        }
    }
    return primeCount;            
}