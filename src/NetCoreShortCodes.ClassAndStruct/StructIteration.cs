using BenchmarkDotNet.Attributes;
using NetCoreShortCodes.ClassAndStruct.Models;
using System.Text.Json;

namespace NetCoreShortCodes.ClassAndStruct
{
    public sealed class StructIteration : AbstractIteration
    {
        private readonly List<MyStruct> _classList = new List<MyStruct>();

        public StructIteration()
        {
            for (int i = 0; i < _itemsSize; i++)
            {
                var myClass = new MyStruct()
                {
                    Name = _random.Next().ToString()
                };

                _classList.Add(myClass);
            }
        }

        [Benchmark]
        public List<MyStruct> SerializeDeserialize()
        {
            var _modifiedList = new List<MyStruct>();

            for (int i = 0; i < _itemsSize; i++)
            {
                var newItem = _classList[i];
                newItem.Name += _random.Next().ToString();

                var serialized = JsonSerializer.Serialize(newItem);
                var deSerialized = JsonSerializer.Deserialize<MyStruct>(serialized);

                _modifiedList.Add(deSerialized);
            }

            return _modifiedList;
        }
    }
}
