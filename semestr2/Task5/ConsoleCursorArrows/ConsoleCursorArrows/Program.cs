using System;

namespace ConsoleCursorArrows
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var cursorMoving = new CursorMoving();

            eventLoop.DownHandler += cursorMoving.ToDown;
            eventLoop.UpHandler += cursorMoving.ToUp;
            eventLoop.RightHandler += cursorMoving.ToRight;
            eventLoop.LeftHandler += cursorMoving.ToLeft;
            eventLoop.InstructionHandler += cursorMoving.Instructions;

            eventLoop.Run();
        }
    }
}
