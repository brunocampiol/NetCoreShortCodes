var integerA = 1;
var integerB = 1;

// What is the expected result?
Console.WriteLine(integerA == integerB);

// What is the expected result and why?
Console.WriteLine(ReferenceEquals(integerA, integerB));

var stringA = "Example";
var stringB = "Example";

// What is the expected result?
Console.WriteLine(stringA == stringB);

// What is the expected result and why?
Console.WriteLine(ReferenceEquals(stringA, stringB));

// Output is:
// TRUE and FALSE for integers
// TRUE and TRUE for strings
// This is an optimiziation from CLR and that is called string interning.
// With this feature, multiple strings with the same content can all reference the same object in memory.