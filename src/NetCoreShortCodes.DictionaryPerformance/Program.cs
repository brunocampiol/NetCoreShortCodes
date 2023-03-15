using NetCoreShortCodes.DictionaryPerformance.Models;
using System.Runtime.InteropServices;

var classA = new MyClass();
var classB = new MyClass();

Console.WriteLine($"class A ID '{classA.Id}'");
Console.WriteLine($"class A name '{classA.Name}'");
//Console.WriteLine($"class B ID '{classB.Id}'");
//Console.WriteLine($"class B name '{classA.Name}'");

var structA = new MyStruct();
var structB = new MyStruct();

Console.WriteLine($"struct A ID '{classA.Id}'");
Console.WriteLine($"struct A name '{classA.Name}'");
//Console.WriteLine($"struct B ID '{classB.Id}'");
//Console.WriteLine($"struct B name '{classA.Name}'");

var structDictionary = new Dictionary<Guid, MyStruct>()
{
    { structA.Id, structA }
};

var classDictionary = new Dictionary<Guid, MyClass>()
{
    { classA.Id, classA }
};

// CASE 1 - Does twice lookup - old way
if (!classDictionary.ContainsKey(classB.Id))
{
    classDictionary[classB.Id] = classB;
    //classDictionary.Add(classB.Id, classB);
}

// CASE 1 - old way alternative
// As class is reference, no problem changing current value as reflexs in dictionary
if (classDictionary.TryGetValue(classA.Id, out var classValue))
{
    classValue.Name = "Bruno Class";
}
Console.WriteLine($"class A name in dictionary '{classDictionary.First().Value.Name}'");

// CASE 1 - old way alternative
// As struct is ref by value, changes wont reflect into dictionary
if (structDictionary.TryGetValue(structA.Id, out var structValue))
{
    structValue.Name = "Bruno Struct";
}
Console.WriteLine($"struct A name in dictionary '{structDictionary.First().Value.Name}'");

// CASE 1 - New way
// WARNING: Unsafe operations - NO ADDS or REMOVES while checking values here
ref var valOrNew = ref CollectionsMarshal.GetValueRefOrAddDefault(classDictionary, classB.Id, out var existed);

if (!existed)
{
    valOrNew = classB;
}













