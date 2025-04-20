using Snake;

int score = 0;

Coord gridDimensions = new Coord(70, 30);
Coord snakePosition = new Coord(10, 1);

Random random = new Random();

Coord applePosition = new Coord(random.Next(1, gridDimensions.X-1), random.Next(1, gridDimensions.Y-1));
int frameDelayInMilliseconds = 100;

Direction movementDirection = Direction.Down;

List<Coord> snakePositionHistory = new List<Coord>();
int tailLength = 1;

while (true)
{
    Console.Clear();
    Console.WriteLine("Score: " + score);

    snakePosition.ApplyMovementDirection(movementDirection);
    
    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentCoord = new Coord(x, y);

            if (snakePosition.Equals(currentCoord) || snakePositionHistory.Contains(currentCoord))
                Console.Write('■');

            else if (applePosition.Equals(currentCoord))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("@");
                Console.ResetColor();
            }
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");

            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
    
    if (snakePosition.Equals(applePosition))
    {
        tailLength++;
        score++;
        applePosition = new Coord(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
    }
    else if (snakePosition.X == 0 || snakePosition.Y == 0 || snakePosition.X == gridDimensions.X - 1 || snakePosition.Y == gridDimensions.Y - 1 || snakePositionHistory.Contains(snakePosition))
    {
        score = 0;
        tailLength = 1;
        snakePosition = new Coord(10, 1);
        snakePositionHistory.Clear();
        movementDirection = Direction.Down;
        continue;
    }
    
    snakePositionHistory.Add(new Coord(snakePosition.X, snakePosition.Y));
 
    if (snakePositionHistory.Count > tailLength)
        snakePositionHistory.RemoveAt(0);

    
    DateTime time = DateTime.Now;
    
    while((DateTime.Now - time).Milliseconds < frameDelayInMilliseconds)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
            }
            
        }
    }
}