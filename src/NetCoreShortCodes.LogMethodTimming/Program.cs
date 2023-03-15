using NetCoreShortCodes.LogMethodTimming.Service;

var myservice = new MyService();
var response = await myservice.GetHttpStatusCode();

Console.WriteLine(response);