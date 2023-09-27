namespace backend_challenge.Modules.refactor;

public class Calculator
{
    private int _x;
    private int _y;
    private int _z;
    private int _result;

    private bool _xIsGreaterThanY;
    private bool _yIsGreaterThanZ;

    public enum Available
    {
        X = 'X',
        Y = 'Y'
    }

    private void DefaultConditionalExpressions()
    {
        if (_xIsGreaterThanY)
            _x += 10;
        else if (_yIsGreaterThanZ)
            _y -= 5;
        else
            _z += 15;
    }

    private void DefineGreater(Available str, bool greater)
    {
        if (str == Available.X)
            _xIsGreaterThanY = greater ? _x > _y : _x < _y;
        if (str == Available.Y)
            _yIsGreaterThanZ = greater ? _y > _z : _y < _z;
    }

    private void Multiply()
    {
        if (_xIsGreaterThanY)
        {
            _x *= 2;
            _result += _x;
        }
        else if (_yIsGreaterThanZ)
        {
            _y *= 3;
            _result += _y;
        }
        else
        {
            _z *= 4;
            _result += _z;
        }
    }
    
    public int Calc(int px, int py, int pz)
    {
        _x = px;
        _y = py;
        _z = pz;
        _result = 0;

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

        return _result;
    }
}