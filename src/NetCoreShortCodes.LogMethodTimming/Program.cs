using NetCoreShortCodes.LogMethodTimming.Service;

// CASE 1 - simple log to Visual Studio output
var myservice = new MyServiceSimple();
var loopCount = 10;

for (int i = 0; i < loopCount; i++)
{
    var response = await myservice.GetHttpStatusCode();
    Console.WriteLine(response);
}

// CASE 2 - prints parameters to log
for (int i = 0; i < loopCount; i++)
{
    var nextInt = Random.Shared.Next(3, 40);
    var response = await myservice.GetHttpStatusCode(nextInt);
    Console.WriteLine(response);
}