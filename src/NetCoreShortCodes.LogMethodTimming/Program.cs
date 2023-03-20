using NetCoreShortCodes.LogMethodTimming.Service;

// CASE 1 - simple log to Visual Studio output
var myservice = new MyServiceSimple();
var loopCount = 10;

for (int i = 0; i < loopCount; i++)
{
    var response = await myservice.GetHttpStatusCode();
    Console.WriteLine(response);
}