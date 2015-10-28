using System.Collections.Generic;

namespace SimpleEditor
{
    public class Core
    {
        private List<Line> lines;
        private Line activeLine;
        private State state;
        private bool isLineRemoving;
        private int numberOfRemovingEnd;

        public bool IsLineRemoving
        {
            get
            {
                return isLineRemoving;
            }
        }

        public Line ActiveLine
        {
            get
            {
                return activeLine;
            }
        }

        public List<Line> Lines
        {
            get
            {
                return lines;
            }
        }

        public Core()
        {
            lines = new List<Line>();
            state = new State();
            activeLine = null;
            isLineRemoving = false;
            numberOfRemovingEnd = 0;
        }

        /// <summary>
        /// Sets active line, which user can delete or remove end of it.
        /// </summary>
        public void SetActiveLine(float xCoordinate, float yCoordinate)
        {
            foreach (var x in lines)
            {
                if (x.IsPointNear(xCoordinate, yCoordinate))
                {
                    activeLine = x;
                    return;
                }
            }
            activeLine = null;
            numberOfRemovingEnd = 0;
            isLineRemoving = false;
        }

        /// <summary>
        /// Creates new line.
        /// </summary>
        public void AddLine()
        {
            const float firstPoint = 10;
            const float secondPoint = 20;
            Line line = new Line(firstPoint, firstPoint, secondPoint, secondPoint);
            lines.Add(line);
        }

        /// <summary>
        /// Deletes active line
        /// </summary>
        public void DeleteLine()
        {
            if (activeLine != null)
            {
                lines.Remove(activeLine);
                activeLine = null;
                isLineRemoving = false;
                numberOfRemovingEnd = 0;
            }
        }

        /// <summary>
        /// Sets line, which end will be removed.
        /// </summary>
        public void SetRemovingLine(float xCoordinate, float yCoordinate)
        {
            numberOfRemovingEnd = activeLine.NumberOfRemovingEnd(xCoordinate, yCoordinate);
            if (numberOfRemovingEnd != 0)
            {
                isLineRemoving = true;
            }
        }

        /// <summary>
        /// Changes the coordinates of line's end.
        /// </summary>
        public void ChangeEnd(float xCoordinate, float yCoordinate)
        {
            activeLine.ChangeEnd(numberOfRemovingEnd, xCoordinate, yCoordinate);
        }

        public void ChangingComplete()
        {
            numberOfRemovingEnd = 0;
            isLineRemoving = false;
        }

        public void UpdadeState()
        {
            List<Line> temp = CloneLines();
            state.UpdateState(temp);
        }

        public void Undo()
        {
            List<Line> argument = CloneLines();
            List<Line> temp = state.PreviousState(argument);
            if (temp != null)
            {
                lines = temp;
            }
        }

        public void Redo()
        {
            List<Line> argument = CloneLines();
            List<Line> temp = state.CanceledState(new List<Line>(argument));
            if (temp != null)
            {
                lines = temp;
            }
        }

        private List<Line> CloneLines()
        {
            List<Line> result = new List<Line>();
            for (int i = 0; i < lines.Count; ++i)
            {
                result.Add(new Line(lines[i].Coordinates[0], lines[i].Coordinates[1], lines[i].Coordinates[2], lines[i].Coordinates[3]));
            }
            return result;
        }
    }
}