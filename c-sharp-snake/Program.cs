using Snake;

Coord gridDimensions = new Coord(70, 30);
Coord snakePosition = new Coord(10, 1);

Random random = new Random();

Coord applePosition = new Coord(random.Next(1, gridDimensions.X-1), random.Next(1, gridDimensions.Y-1));
int frameDelayInMilliseconds = 100;

Direction movementDirection = Direction.Down;


while (true)
{
    Console.Clear();
    snakePosition.ApplyMovementDirection(movementDirection);
    
    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentCoord = new Coord(x, y);
            
            if (snakePosition.Equals(currentCoord))
                Console.Write('■');
            
            else if (applePosition.Equals(currentCoord))
                Console.Write("a");
            
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");
            
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
    Thread.Sleep(frameDelayInMilliseconds);
}