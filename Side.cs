using RubiksCube;

class Side
{
    private const int THIKNESS = 6;
    public Cube cube;
    public int side;
    public int length;
    public int[,] cells;

    int relationTop;
    int? relationTopRow = null, relationTopCol = null;
    int relationBottom;
    int? relationBottomRow = null, relationBottomCol = null;
    int relationLeft;
    int? relationLeftRow = null, relationLeftCol = null;
    int relationRight;
    int? relationRightRow = null, relationRightCol = null;
    public Side(int side, int length, Cube cube)
    {
        this.side = side;
        this.length = length;
        this.cube = cube;
        this.cells = new int[length, length];
        Reset();
        // Set the relations:
        Relations();
    }

    public void Print()
    {
        // Print the side:

        Console.Clear();
        // Loop through the rows:
        for (int row = 0; row < length; row++)
        {

            // Print the row:

            // Creates a black line seperating the rows:
            for (int i = 0; i < length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("                 ");
            }
            Console.WriteLine();

            // Print the row times the thickness:
            for (int j = 0; j < THIKNESS; j++)
            {
                // Loop through the columns:
                for (int col = 0; col < length; col++)
                {
                    // Print the column:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    Console.BackgroundColor = (ConsoleColor)cells[row, col];
                    Console.Write("               ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");

                    // Get line down every row:
                    if (col == length - 1)
                        Console.WriteLine();

                }
            }
        }
        // Creates a black line bellow the rows:
        for (int i = 0; i < length; i++)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("                 ");
        }
        Console.WriteLine();
        Console.WriteLine($"The side is {(SideEnum)side}");
        Console.WriteLine("The list of keys available are:");
        Console.WriteLine("R: Rotate the right layer clockwise.");
        Console.WriteLine("R’ (T): Rotate the right layer anti-clockwise.");
        Console.WriteLine("L: Rotate the left layer clockwise.");
        Console.WriteLine("L’ (K): Rotate the left layer anti-clockwise.");
        Console.WriteLine("U: Rotate the top layer clockwise.");
        Console.WriteLine("U’ (I): Rotate the top layer anti-clockwise.");
        Console.WriteLine("F: Rotate the front layer clockwise.");
        Console.WriteLine("F' (G): Rotate the front layer counter-clockwise.");
        Console.WriteLine($"Relationships: top: {(SideEnum)relationTop}, bottom: {(SideEnum)relationBottom}, left: {(SideEnum)relationLeft}, right: {(SideEnum)relationRight}");
        Console.WriteLine("F9: Scramble the cube.");
        Console.WriteLine("F10: Reset the cube.");
        Console.WriteLine("F11: (NOT IMPLEMENTED YET) Shows you how to solve the cube.");
        Console.WriteLine("Z: Rotate the side that you look at clockwise.");
        Console.WriteLine("X: Rotate the side that you look at anti-clockwise.");
    }

    public void Rotate(bool clockwise = true)
    {
        if (clockwise)
        {
            // Rotate the cells on the side clockwise:
            int[,] newCells = new int[length, length];
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    newCells[row, col] = cells[(length - 1) - col, row];
                }
            }
            cells = newCells;


            // Rotate the relations clockwise:
            int[] newTop = new int[length];
            int[] newBottom = new int[length];
            int[] newLeft = new int[length];
            int[] newRight = new int[length];

            // Get the new relations:
            for (int i = 0; i < length; i++)
            {
                newTop[i] = cube.sides[relationTop].cells[(int)(relationTopRow != null ? relationTopRow : i), (int)(relationTopCol != null ? relationTopCol : i)];
                newBottom[i] = cube.sides[relationBottom].cells[(int)(relationBottomRow != null ? relationBottomRow : i), (int)(relationBottomCol != null ? relationBottomCol : i)];
                newLeft[i] = cube.sides[relationLeft].cells[(int)(relationLeftRow != null ? relationLeftRow : i), (int)(relationLeftCol != null ? relationLeftCol : i)];
                newRight[i] = cube.sides[relationRight].cells[(int)(relationRightRow != null ? relationRightRow : i), (int)(relationRightCol != null ? relationRightCol : i)];
            }

            // Set the new relations:
            for (int i = 0; i < length; i++)
            {
                cube.sides[relationTop].cells[(int)(relationTopRow != null ? relationTopRow : i), (int)(relationTopCol != null ? relationTopCol : i)] = newLeft[(length - 1) - i];
                cube.sides[relationBottom].cells[(int)(relationBottomRow != null ? relationBottomRow : i), (int)(relationBottomCol != null ? relationBottomCol : i)] = newRight[(length - 1) - i];
                cube.sides[relationLeft].cells[(int)(relationLeftRow != null ? relationLeftRow : i), (int)(relationLeftCol != null ? relationLeftCol : i)] = newBottom[i];
                cube.sides[relationRight].cells[(int)(relationRightRow != null ? relationRightRow : i), (int)(relationRightCol != null ? relationRightCol : i)] = newTop[i];
            }
        }
        else
        {
            // Rotate the cells on the side anti-clockwise:
            int[,] newCells = new int[length, length];
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    newCells[row, col] = cells[col, (length - 1) - row];
                }
            }
            cells = newCells;

            // Rotate the relations anti-clockwise:
            int[] newTop = new int[length];
            int[] newBottom = new int[length];
            int[] newLeft = new int[length];
            int[] newRight = new int[length];

            // Get the new relations:
            for (int i = 0; i < length; i++)
            {
                newTop[i] = cube.sides[relationTop].cells[(int)(relationTopRow != null ? relationTopRow : i), (int)(relationTopCol != null ? relationTopCol : i)];
                newBottom[i] = cube.sides[relationBottom].cells[(int)(relationBottomRow != null ? relationBottomRow : i), (int)(relationBottomCol != null ? relationBottomCol : i)];
                newLeft[i] = cube.sides[relationLeft].cells[(int)(relationLeftRow != null ? relationLeftRow : i), (int)(relationLeftCol != null ? relationLeftCol : i)];
                newRight[i] = cube.sides[relationRight].cells[(int)(relationRightRow != null ? relationRightRow : i), (int)(relationRightCol != null ? relationRightCol : i)];
            }

            // Set the new relations:
            for (int i = 0; i < length; i++)
            {
                cube.sides[relationTop].cells[(int)(relationTopRow != null ? relationTopRow : i), (int)(relationTopCol != null ? relationTopCol : i)] = newRight[i];
                cube.sides[relationBottom].cells[(int)(relationBottomRow != null ? relationBottomRow : i), (int)(relationBottomCol != null ? relationBottomCol : i)] = newLeft[i];
                cube.sides[relationLeft].cells[(int)(relationLeftRow != null ? relationLeftRow : i), (int)(relationLeftCol != null ? relationLeftCol : i)] = newTop[(length - 1) - i];
                cube.sides[relationRight].cells[(int)(relationRightRow != null ? relationRightRow : i), (int)(relationRightCol != null ? relationRightCol : i)] = newBottom[(length - 1) - i];
            }
        }
    }

    public void Reset()
    {
        for (int row = 0; row < length; row++)
        {
            for (int col = 0; col < length; col++)
            {
                cells[row, col] = cube.colors[side];
            }
        }
    }

    void Relations()
    {
        // Relation between sides:
        switch (side)
        {
            case (int)SideEnum.Blue:
                relationTop = (int)SideEnum.Yellow;
                relationTopRow = length - 1;
                relationBottom = (int)SideEnum.White;
                relationBottomRow = 0;
                relationLeft = (int)SideEnum.Orange;
                relationLeftCol = length - 1;
                relationRight = (int)SideEnum.Red;
                relationRightCol = 0;
                break;
            case (int)SideEnum.Red:
                relationTop = (int)SideEnum.Yellow;
                relationTopCol = length - 1;
                relationBottom = (int)SideEnum.White;
                relationBottomCol = length - 1;
                relationLeft = (int)SideEnum.Blue;
                relationLeftCol = length - 1;
                relationRight = (int)SideEnum.Green;
                relationRightCol = 0;
                break;
            case (int)SideEnum.Green:
                relationTop = (int)SideEnum.Yellow;
                relationTopRow = 0;
                relationBottom = (int)SideEnum.White;
                relationBottomRow = length - 1;
                relationLeft = (int)SideEnum.Red;
                relationLeftCol = length - 1;
                relationRight = (int)SideEnum.Orange;
                relationRightCol = 0;
                break;
            case (int)SideEnum.Orange:
                relationTop = (int)SideEnum.Yellow;
                relationTopCol = 0;
                relationBottom = (int)SideEnum.White;
                relationBottomCol = 0;
                relationLeft = (int)SideEnum.Green;
                relationLeftCol = length - 1;
                relationRight = (int)SideEnum.Blue;
                relationRightCol = 0;
                break;
            case (int)SideEnum.Yellow:
                relationTop = (int)SideEnum.Green;
                relationTopRow = 0;
                relationBottom = (int)SideEnum.Blue;
                relationBottomRow = 0;
                relationLeft = (int)SideEnum.Orange;
                relationLeftRow = 0;
                relationRight = (int)SideEnum.Red;
                relationRightRow = 0;
                break;
            case (int)SideEnum.White:
                relationTop = (int)SideEnum.Blue;
                relationTopRow = length - 1;
                relationBottom = (int)SideEnum.Green;
                relationBottomRow = length - 1;
                relationLeft = (int)SideEnum.Orange;
                relationLeftRow = length - 1;
                relationRight = (int)SideEnum.Red;
                relationRightRow = length - 1;
                break;
        }
    }
}