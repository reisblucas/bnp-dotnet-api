namespace backend_challenge.Modules.refactor;

public class Calculator
{
    private int x;
    private int y;
    private int z;
    private int result;

    private bool xIsGreaterThanY;
    private bool yIsGreaterThanZ;

    public enum Available
    {
        X = 'X',
        Y = 'Y'
    }

    private void DefaultConditionalExpressions()
    {
        if (xIsGreaterThanY)
            x += 10;
        else if (yIsGreaterThanZ)
            y -= 5;
        else
            z += 15;
    }

    private void DefineGreater(Available str, bool greater)
    {
        if (str == Available.X)
            xIsGreaterThanY = greater ? x > y : x < y;
        if (str == Available.Y)
            yIsGreaterThanZ = greater ? y > z : y < z;
    }

    private void Multiply()
    {
        if (xIsGreaterThanY)
        {
            x *= 2;
            result += x;
        }
        else if (yIsGreaterThanZ)
        {
            y *= 3;
            result += y;
        }
        else
        {
            z *= 4;
            result += z;
        }
    }

    public int Calc(int px, int py, int pz)
    {
        x = px;
        y = py;
        z = pz;
        result = 0;

        for (int i = 0; i < 100; i++)
        {
            DefineGreater(Available.X, true);
            DefaultConditionalExpressions();

            switch (i)
            {
                case 0:
                    Multiply();
                    break;
                case 1:
                    DefineGreater(Available.X, false);
                    DefineGreater(Available.Y, false);
                    Multiply();
                    break;
            }
        }

        DefineGreater(Available.X, true);
        for (int j = 0; j < 50; j++)
        {
            DefaultConditionalExpressions();
        }

        return result;
    }
}