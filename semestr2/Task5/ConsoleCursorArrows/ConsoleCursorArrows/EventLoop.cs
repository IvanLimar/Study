using System;

namespace ConsoleCursorArrows
{
    public class EventLoop
    {
        public event EventHandler<EventArgs> UpHandler = (sender, args) => {};
        public event EventHandler<EventArgs> DownHandler = (sender, args) => {};
        public event EventHandler<EventArgs> RightHandler = (sender, args) => {};
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => {};
        public event EventHandler<EventArgs> InstructionHandler = (sender, args) => {};
        public event EventHandler<EventArgs> ExitHandler = (sender, args) => {};

        public void Run()
        {
            InstructionHandler(this, EventArgs.Empty);
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    ExitHandler(this, EventArgs.Empty);
                    break;
                }
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        UpHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        DownHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}
