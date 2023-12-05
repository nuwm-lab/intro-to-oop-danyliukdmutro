using System;

class Matrix
{
    protected int[,] matrix2D;
    protected int[,,] matrix3D;

    public Matrix(int rows, int columns)
    {
        matrix2D = new int[rows, columns];
    }

    public Matrix(int rows, int columns, int depth)
    {
        matrix3D = new int[rows, columns, depth];
    }

    public virtual void InputMatrix()
    {
        Console.WriteLine("Enter matrix elements:");
        for (int i = 0; i < matrix2D.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2D.GetLength(1); j++)
            {
                Console.Write("matrix2D[{i},{j}] = ");
                matrix2D[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }

    public virtual void InputMatrix3D()
    {
        Console.WriteLine("Enter elements for the three-dimensional matrix:");
        for (int i = 0; i < matrix3D.GetLength(0); i++)
        {
            for (int j = 0; j < matrix3D.GetLength(1); j++)
            {
                for (int k = 0; k < matrix3D.GetLength(2); k++)
                {
                    Console.Write($"matrix3D[{i},{j},{k}] = ");
                    matrix3D[i, j, k] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }

    public virtual void RandomizeMatrix()
    {
        Random random = new Random();
        for (int i = 0; i < matrix2D.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2D.GetLength(1); j++)
            {
                matrix2D[i, j] = random.Next(1, 100);
            }
        }

        for (int i = 0; i < matrix3D.GetLength(0); i++)
        {
            for (int j = 0; j < matrix3D.GetLength(1); j++)
            {
                for (int k = 0; k < matrix3D.GetLength(2); k++)
                {
                    matrix3D[i, j, k] = random.Next(1, 100);
                }
            }
        }
    }

    public int FindMinElement()
    {
        int min = matrix2D[0, 0];
        for (int i = 0; i < matrix2D.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2D.GetLength(1); j++)
            {
                if (matrix2D[i, j] < min)
                {
                    min = matrix2D[i, j];
                }
            }
        }
        return min;
    }

    public int FindMinElement3D()
    {
        int min = matrix3D[0, 0, 0];
        for (int i = 0; i < matrix3D.GetLength(0); i++)
        {
            for (int j = 0; j < matrix3D.GetLength(1); j++)
            {
                for (int k = 0; k < matrix3D.GetLength(2); k++)
                {
                    if (matrix3D[i, j, k] < min)
                    {
                        min = matrix3D[i, j, k];
                    }
                }
            }
        }
        return min;
    }
}

class TwoDimensionalMatrix : Matrix
{
    public TwoDimensionalMatrix() : base(3, 3)
    {
    }

    public override void InputMatrix()
    {
        Console.WriteLine("Enter elements for the two-dimensional matrix:");
        base.InputMatrix();
    }

    public override void RandomizeMatrix()
    {
        base.RandomizeMatrix();
    }
}

class ThreeDimensionalMatrix : Matrix
{
    public ThreeDimensionalMatrix() : base(3, 3, 3)
    {
    }

    public override void InputMatrix()
    {
        Console.WriteLine("Enter elements for the three-dimensional matrix:");
        base.InputMatrix3D();
    }

    public override void RandomizeMatrix()
    {
        base.RandomizeMatrix();
    }
}

class Program
{
    static void Main()
    {
        TwoDimensionalMatrix twoDMatrix = new TwoDimensionalMatrix();
        twoDMatrix.InputMatrix();

        int min2D = twoDMatrix.FindMinElement();
        Console.WriteLine("Minimum element in the two-dimensional matrix: " + min2D);

        ThreeDimensionalMatrix threeDMatrix = new ThreeDimensionalMatrix();
        threeDMatrix.InputMatrix();

        int min3D = threeDMatrix.FindMinElement3D();
        Console.WriteLine("Minimum element in the three-dimensional matrix: " + min3D);
    }
}
