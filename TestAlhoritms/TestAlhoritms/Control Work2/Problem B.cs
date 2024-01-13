internal class Program
{
    static long CountInversionsAndSort(List<uint> array, int left, int right)
    {
        if (left >= right) return 0;

        int middle = left + (right - left) / 2;
        long inversionCount = CountInversionsAndSort(array, left, middle) + CountInversionsAndSort(array, middle + 1, right);

        int i = left, j = middle + 1;
        List<uint> res = new List<uint>();
        while (i <= middle && j <= right)
        {
            if (array[i] <= array[j])
            {
                res.Add(array[i++]);
            }
            else
            {
                res.Add(array[j++]);
                inversionCount += middle - i + 1;
            }
        }

        while (i <= middle) res.Add(array[i++]);
        while (j <= right) res.Add(array[j++]);

        for (i = left; i <= right; i++) array[i] = res[i - left];

        return inversionCount;
    }

    static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        int arraySize = int.Parse(input[0]);
        uint moduloValue = uint.Parse(input[1]);

        var input2 = Console.ReadLine().Split(' ');
        uint multiplier = uint.Parse(input2[0]);
        uint increment = uint.Parse(input2[1]);
        uint cur = 0;

        uint NextRand24()
        {
            cur = cur * multiplier + increment;
            return (cur >> 8);
        }

        List<uint> array = new List<uint>(arraySize);
        for (int i = 0; i < arraySize; i++)
        {
            array.Add((NextRand24() % moduloValue));
        }

        Console.WriteLine(CountInversionsAndSort(array, 0, arraySize - 1));
    }
}