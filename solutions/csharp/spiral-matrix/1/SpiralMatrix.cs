public class SpiralMatrix
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

    public struct State
    {
        public int YIdx { get; set; } = 0;
        public int XIdx { get; set; } = 0;
        public int Iteration { get; set; } = 0;
        public int Size { get; set; } = 0;
        public Direction CurrentDirection { get; set; } = Direction.Right;

        public State() { }
    }

    public static int[,] GetMatrix(int size)
    {
        var result = new int[size, size];
        if (size == 0)
            return result;

        var state = new State { XIdx = 0, YIdx = 0, Iteration = 0, CurrentDirection = Direction.Right, Size = size};

        for (int i = 1; i <= size * size; i++)
        {
            result[state.YIdx, state.XIdx] = i;
            progressState(ref state);
        }

        return result;
    }

    private static void progressState(ref State state)
    {
        switch (state)
        {
            case { CurrentDirection: Direction.Right }: moveRight(ref state); break;
            case { CurrentDirection: Direction.Down }: moveDown(ref state); break;
            case { CurrentDirection: Direction.Left }: moveLeft(ref state); break;
            case { CurrentDirection: Direction.Up }: moveUp(ref state); break;
            default: break;
        }
    }

    private static void moveRight(ref State state)
    {
        state.XIdx++;
        if (state.XIdx == state.Size - 1 - state.Iteration)
            state.CurrentDirection = Direction.Down;
    }

    private static void moveDown(ref State state)
    {
        state.YIdx++;
        if (state.YIdx == state.Size - 1 - state.Iteration)
            state.CurrentDirection = Direction.Left;
    }

    private static void moveLeft(ref State state)
    {
        state.XIdx--;
        if (state.XIdx == 0 + state.Iteration)
        {
            state.CurrentDirection = Direction.Up;
            state.Iteration++;
        }
    }

    private static void moveUp(ref State state)
    {
        state.YIdx--;
        if (state.YIdx == 0 + state.Iteration)
        {
            state.CurrentDirection = Direction.Right;
        }
    }
}
