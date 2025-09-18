public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var groups = new Stack<uint>();
        foreach (var number in numbers.Reverse())
        {
            if (number == 0)
            {
                groups.Push(0);
                continue;
            }
            bool first = true;

            var _number = number;
            do
            {
                uint n = _number & 0x7F;
                groups.Push(first ? n : n + 128);
                first = false;
            } while ((_number >>= 7) > 0);
        }

        return groups.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        var _bytes = new Stack<uint>(bytes.Reverse());
        var numbers = new Stack<uint>();
        uint number = 0;
        int count = 0;
        while (_bytes.Count > 0)
        {
            if (count > 5)
                throw new InvalidOperationException("Invalid VQL sequence to long");

            uint b = _bytes.Pop();
            number = (number << 7) | (b & 0x7F);
            count++;
            if ((b & 0x80) == 0)
            {
                numbers.Push(number);
                number = 0;
                count = 0;
            }
        }

        if (count != 0)
            throw new InvalidOperationException("Incomplete VQL sequence");
        
        return numbers.Reverse().ToArray();
    }
}