using System;
using System.Collections.Generic;
using System.Text;

namespace Golf
{
    class AngleInvalidException: Exception
    {
        static public void invalid()
        {
            //throw new AngleInvalidException();
            Console.WriteLine("Your angle shoud be betwen 1 and 90 degrees");
        }
    }
}
