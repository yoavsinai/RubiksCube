namespace RubiksCube
{

    enum SideEnum
    {
        Blue = 0,
        Red = 1,
        Green = 2,
        Orange = 3,
        Yellow = 4,
        White = 5
    }

    public enum Colors
    {
        Blue = ConsoleColor.Blue,
        Red = ConsoleColor.Red,
        Green = ConsoleColor.Green,
        Orange = ConsoleColor.DarkYellow,
        Yellow = ConsoleColor.Yellow,
        White = ConsoleColor.White
    }



    class Cube
    {
        private const int SIDES_NUM = 6;
        private int length;
        private Side front;
        private Side right;
        private Side back;
        private Side left;
        private Side top;
        private Side bottom;

        public Side[] sides;
        public int[] colors = new int[] { (int)Colors.Blue, (int)Colors.Red, (int)Colors.Green, (int)Colors.Orange, (int)Colors.Yellow, (int)Colors.White };

        public Cube(int length = 3)
        {
            this.length = length;

            // Create the cube sides:
            this.front = new Side((int)SideEnum.Blue, length, this);
            this.right = new Side((int)SideEnum.Red, length, this);
            this.back = new Side((int)SideEnum.Green, length, this);
            this.left = new Side((int)SideEnum.Orange, length, this);
            this.top = new Side((int)SideEnum.Yellow, length, this);
            this.bottom = new Side((int)SideEnum.White, length, this);

            this.sides = new Side[] { front, right, back, left, top, bottom };
        }

        public void Print()
        {
            // Print the front side:
            sides[0].Print();
            InputInterface(0);
        }

        void InputInterface(int side)
        {

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.RightArrow:
                    if (side == SIDES_NUM - 1)
                        side = 0;
                    else
                        side += 1;
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.LeftArrow:
                    if (side == 0)
                        side = SIDES_NUM - 1;
                    else
                        side -= 1;
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.R:
                    R_Rotate();
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.T:
                    R_Rotate(false);
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.L:
                    L_Rotate();
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.K:
                    L_Rotate(false);
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.U:
                    U_Rotate();
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.I:
                    U_Rotate(false);
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.F:
                    F_Rotate();
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.G:
                    F_Rotate(false);
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.Escape:
                    break;
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.F9:
                    Scrumble();
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.F10:
                    Reset();
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.F11:
                    Solve();
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.Z:
                    sides[side].Rotate();
                    sides[side].Print();
                    InputInterface(side);
                    break;
                case ConsoleKey.X:
                    sides[side].Rotate(false);
                    sides[side].Print();
                    InputInterface(side);
                    break;
                default:
                    InputInterface(side);
                    break;
            }
        }

        public void R_Rotate(bool clockwise = true)
        {
            right.Rotate(clockwise);
        }

        public void L_Rotate(bool clockwise = true)
        {
            left.Rotate(clockwise);
        }

        public void U_Rotate(bool clockwise = true)
        {
            top.Rotate(clockwise);
        }

        public void F_Rotate(bool clockwise = true)
        {
            front.Rotate(clockwise);
        }

        public void Scrumble()
        {
            const int MAX_SCRUMBLE = 100;
            Random rand = new Random();
            for (int i = 0; i < MAX_SCRUMBLE; i++)
            {
                int randSide = rand.Next(0, SIDES_NUM);
                sides[randSide].Rotate();
                int rand1 = rand.Next(0, 2);
                int rand2 = rand.Next(0, 2);
                int rand3 = rand.Next(0, 2);
                int rand4 = rand.Next(0, 2);

                for (int j = 0; j < rand1; j++)
                    R_Rotate();
                for (int j = 0; j < rand2; j++)
                    L_Rotate();
                for (int j = 0; j < rand3; j++)
                    U_Rotate();
                for (int j = 0; j < rand4; j++)
                    U_Rotate();
            }
        }

        public void Reset()
        {
            for (int i = 0; i < SIDES_NUM; i++)
            {
                sides[i].Reset();
            }
        }

        public void Solve()
        {

        }
    }
}

