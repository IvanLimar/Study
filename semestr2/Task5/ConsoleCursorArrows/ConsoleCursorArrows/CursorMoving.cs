using System;

namespace ConsoleCursorArrows
{
    /// <summary>
    /// Класс отвечает за перемещение курсора по консоли.
    /// </summary>
    public class CursorMoving
    {
        public void Exit(object senfer, EventArgs args)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 1;
        }

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
