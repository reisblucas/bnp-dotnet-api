namespace backend_challenge.Modules.refactor;

public class Calculator
{
    private int x;
    private int y;
    private int z;
    private int result;

    private void Multiply(bool greaterSign = false)
    {
        var firstCondition = greaterSign ? x > y : x < y;
        var secondCondition = greaterSign ? y > z : y < z;
        
        if (firstCondition)
        {
            x *= 2;
            result += x;
        }
        else if (secondCondition)
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
            if (x > y)
            {
                x += 10;
            }
            else if (y > z)
            {
                y -= 5;
            }
            else
            {
                z += 15;
            }

            switch (i)
            {
                case 0:
                    Multiply(true);
                    break;
                case 1:
                    Multiply();
                    break;
            }
        }

        for (int j = 0; j < 50; j++)
        {
            if (x > y)
            {
                x += 10;
            }
            else if (y > z)
            {
                y -= 5;
            }
            else
            {
                z += 15;
            }
        }

        return result;
    }
}