using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    class Swing
    {
        public const double GRAVITY = 9.8;
        public double Angle { get; set; }
        public double Velocity { get; set; }
        public Ball Ball { get; set; }
        
        
        public double AngleInRadians
        {
            get
            {
                return (Math.PI / 180) * this.Angle;
            }
        }
        public double Distance {
			get
			{
				return Math.Pow(this.Velocity, 2) / GRAVITY * 
					Math.Sin(2 * this.AngleInRadians);
			}
		}
       
        public Swing(double angle, double velocity,Ball ball)
        {
            try
            {

                if (angle >= 90 || angle <= 0)
                {
                    throw new AngleInvalidException();
                }
            if (velocity <= 0)
            {
                    throw new Exception();
            }
            else
            {
                this.Velocity = velocity;
            }
            }
            catch (AngleInvalidException)
            {
                AngleInvalidException.invalid();
                Console.WriteLine("Angle should between 1 to 90");
            }
            catch (Exception)
            {
                Console.WriteLine("velocity sholud b greater than zero ");
            }
            this.Angle = angle;
            this.Ball= ball;
        }

        
    }
}
