using BenchmarkDotNet.Attributes;
using NetCoreShortCodes.ClassAndStruct.Models;
using System.Text.Json;

namespace NetCoreShortCodes.ClassAndStruct
{
    public sealed class ClassIteration : AbstractIteration
    {
        private readonly List<MyClass> _classList = new List<MyClass>();

        public ClassIteration()
        {
            for (int i = 0; i < _itemsSize; i++)
            {
                var myClass = new MyClass("my class")
                {
                    Name = _random.Next().ToString()
                };

                _classList.Add(myClass);
            }
        }

        [Benchmark]
        public List<MyClass> SerializeDeserialize()
        {
            var _modifiedList = new List<MyClass>();

            for (int i = 0; i < _itemsSize; i++)
            {
                var newItem = _classList[i];
                newItem.Name += _random.Next().ToString();

                var serialized = JsonSerializer.Serialize(newItem);
                var deSerialized = JsonSerializer.Deserialize<MyClass>(serialized);

                _modifiedList.Add(deSerialized);
            }

            return _modifiedList;
        }
    }
}