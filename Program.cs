using System;

namespace Golf
{
    class Program
    { 
        static void Main(string[] args)
        {
            Random rng = new Random();
            int Length = rng.Next(200, 800);
            int maxSwings = rng.Next(1,9);
            Console.WriteLine("{0}",maxSwings);
            Ball ball = new Ball(Length:Length, maxSwings: maxSwings);
            while (!ball.Ended)
            {
               
                Console.WriteLine($"Goal Hole {ball.Length} meters");
                Console.WriteLine($"Area of Game is {ball.Rough} meters (Max bounds: {ball.Rough + ball.Length} meters)");
                Console.WriteLine($"Distance to Hole: {ball.DistanceFromHole.ToString("0.00")} meters");
                Console.WriteLine($"You have taken {ball.SwingCounter} swings at this hole. (Max is {ball.MaxSwings})");
                Console.WriteLine("----------------------------------------------------------------------------------");

              
                foreach (var item in ball.Swings)
                {
                    Console.WriteLine($"\tAngle:{item.Angle}\tVelocity:{item.Velocity}\tDistance:{item.Distance.ToString("N2")} meters");
                }
                Console.WriteLine("------------------------------------------------------------------------------------");
               
                    Console.Write("Angle: ");
                    double inValue1 = double.Parse(Console.ReadLine());
                    Console.Write("Velocity (only positive values): ");
                    double inValue2 = double.Parse(Console.ReadLine());
                    ball.Swing(inValue1, inValue2);

            
            
                Console.ReadKey();
                Console.Clear();
            }
          
            if (ball.Lost)
            {
                Console.WriteLine("You failed to reach the cup.");
                Console.WriteLine($"Distance to Hole: {ball.DistanceFromHole.ToString("0.00")} meters");
               
                if (ball.IsOutOfBounds)
                {
                    Console.WriteLine("Because the golf ball is out of bounds.");
                    Console.ReadKey();
                }
                if (ball.SwingCounter >= ball.MaxSwings)
                {
                    Console.WriteLine("Because you took too many swings.");
                    Console.ReadKey(); 
                }
            }
            else if (ball.Won)
            {
                Console.WriteLine("You reached the cup.");
                if (ball.SwingCounter == 1)
                {
                    Console.WriteLine("You do it in One swing");
                }
                Console.ReadKey();

            }

        }
    }
}
