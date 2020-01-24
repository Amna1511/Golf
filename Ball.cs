using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
 
    class Ball
    {
        public int MaxSwings { get; set; }

        private int swingCounter;
        public int SwingCounter
        {
            get { return swingCounter; }
            set
            {
                if (value >= this.MaxSwings)
                {

                  
                    this.Lost= true;
                    Ended = true;
                }
                swingCounter = value;
                
            }
        }
        public List<Swing> Swings { get; set; }
        public double Rough { get; set; }
        public double Length { get; set; }
        public bool Ended { get; set; }
        public bool Lost { get; set; }

        public bool Won { get; set; }
        public const double Tolerance = 0.1;
        public bool IsOutOfBounds { get; set; }
        private Ball()
        {
            this.Swings = new List<Swing>();
        }
        public Ball(int maxSwings) : this()
        {
            this.MaxSwings = maxSwings;
        }
        public Ball(double Length, int maxSwings, double Rough = 1000
            )
            : this(maxSwings: maxSwings)
        {
            this.Length = Length;
            this.Rough = Rough;
        }
      
		public double DistanceTravelled
        {
            get
            {
                double totalDistance = 0;
                foreach (Swing swing in Swings)
                {
                    totalDistance += swing.Distance;
                }
                return totalDistance;
            }
        }
        public double DistanceFromHole
        {
            get
            {
                double distanceFromHole = Length;
                foreach (Swing swing in Swings)
                {
                    distanceFromHole = Math.Abs(distanceFromHole - swing.Distance);
                }
                return distanceFromHole;
            }
        }
        public void Swing(double angle, double velocity)
        {
            Swing swing = new Swing(angle, velocity, this);
            Swings.Add(swing);
            this.SwingCounter++;
            if (this.DistanceFromHole <= Ball.Tolerance)
            {
                this.Ended = true;
                this.Won = true;
            }
             else if (this.DistanceFromHole > Rough)
            {
                this.IsOutOfBounds = true;
                this.Ended = true;
                this.Lost = true;
            }
            
        }
    }
}
