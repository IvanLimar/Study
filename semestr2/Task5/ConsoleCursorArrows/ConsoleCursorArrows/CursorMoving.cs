using System;

namespace ConsoleCursorArrows
{
    public class CursorMoving
    {
        public void Instructions(object sender, EventArgs args)
        {
            Console.WriteLine("Use arrows to move cursor. Press Esc to exit");
        }

        public void ToUp(object sender, EventArgs args)
        {
            if (Console.CursorTop <= 1)
            {
                return;
            }
            Console.CursorTop--;
        }

        public void ToDown(object sender, EventArgs args)
        {
           if (Console.CursorTop == Console.WindowHeight - 1)
            {
                return;
            }
            Console.CursorTop++;
        }

        public void ToRight(object sender, EventArgs args)
        {
            if (Console.CursorLeft == Console.WindowWidth - 1)
            {
                return;
            }
            Console.CursorLeft++;
        }

        public void ToLeft(object sender, EventArgs args)
        {
            if (Console.CursorLeft == 0)
            {
                return;
            }
            Console.CursorLeft--;
        }
    }
}
