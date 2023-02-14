using BenchmarkDotNet.Attributes;

namespace NetCoreShortCodes.Benchmark
{
    public class LoopIteration
    {
        private const int N = 10000;
        private readonly List<string> stringList;

        public LoopIteration()
        {
            stringList = new List<string>();
            var random = new Random(420);
            for (int i = 0; i < N; i++)
            {
                var randomInteger = random.Next();
                stringList.Add(randomInteger.ToString());
            }
        }

        [Benchmark]
        public void ForIteration()
        {
            for (int i = 0; i < stringList.Count; i++)
            {

            }
        }

        [Benchmark]
        public void ForIterationWithCountMethod()
        {
            for (int i = 0; i < stringList.Count(); i++)
            {

            }
        }

        [Benchmark]
        public void ForEach()
        {
            foreach (var item in stringList)
            {

            }
        }

        [Benchmark]
        public void ForEachLinq()
        {
            stringList.ForEach(x => { });
        }
    }
}