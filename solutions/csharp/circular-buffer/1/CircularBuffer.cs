public class CircularBuffer<T>
{
    private T[] _data;
    private int _readIdx;
    private int _writeIdx;

    public CircularBuffer(int capacity)
    {
        _data = new T[capacity + 1];
        _readIdx = _writeIdx = 0;
    }

    public T Read()
    {
        if (_readIdx == _writeIdx)
            throw new InvalidOperationException("Buffer is empty!");

        var idx = _readIdx;
        _readIdx = nextIndex(_readIdx);
        return _data[idx];
    }

    public void Write(T value)
    {
        if (nextIndex(_writeIdx) == _readIdx)
            throw new InvalidOperationException("Buffer is full");

        _data[_writeIdx] = value;
        _writeIdx = nextIndex(_writeIdx);
    }

    public void Overwrite(T value)
    {
        if (nextIndex(_writeIdx) != _readIdx)
        {
            Write(value);
            return;
        }

        _readIdx = nextIndex(_readIdx);
        Write(value);
    }

    public void Clear()
    {
        _readIdx = _writeIdx = 0;
    }

    private int nextIndex(int index) => (index + 1) % _data.Length;
    private int prevIndex(int index) => (index - 1 + _data.Length) % _data.Length;
}