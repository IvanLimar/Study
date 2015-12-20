using System;
using System.Collections.Generic;

namespace SimpleEditor
{
    /// <summary>
    /// Represents a line in R^2.
    /// </summary>
    public class Line
    {
        private float firstXCoordinate;
        private float firstYCoordinate;
        private float secondXCoordinate;
        private float secondYCoordinate;

        /// <summary>
        /// Gets coordinates of line's ends.
        /// </summary>
        public List<float> Coordinates
        {
            get
            {
                return new List<float>() { firstXCoordinate, firstYCoordinate, secondXCoordinate, secondYCoordinate };
            }
        }

        public Line(float firstXCoordinare, float firstYCoordinate, float secondXCoordinate, float secondYCoordinate)
        {
            this.firstXCoordinate = firstXCoordinare;
            this.firstYCoordinate = firstYCoordinate;
            this.secondXCoordinate = secondXCoordinate;
            this.secondYCoordinate = secondYCoordinate;
        }

        /// <summary>
        /// Changes coordinates of line's end.
        /// </summary>
        public void ChangeEnd(int numberOfPoint, float xCoordinate, float yCoordinate)
        {
            switch (numberOfPoint)
            {
                case 1: firstXCoordinate = xCoordinate; firstYCoordinate = yCoordinate; break;
                case 2: secondYCoordinate = yCoordinate; secondXCoordinate = xCoordinate; break;
                default: break;
            }
        }

        /// <summary>
        /// Returns true, if distance between line and point is little
        /// </summary>
        public bool IsPointNear(float xCoordinate, float yCoordinate)
        {
            const float temp = 2;
            if (firstXCoordinate == secondXCoordinate)
            {
                return Math.Abs(xCoordinate - firstXCoordinate) < temp && yCoordinate >= Math.Min(firstYCoordinate, secondYCoordinate)
                    && yCoordinate <= Math.Max(firstYCoordinate, secondYCoordinate);
            }
            if (secondYCoordinate == firstYCoordinate)
            {
                return Math.Abs(yCoordinate - firstYCoordinate) < temp && xCoordinate >= Math.Min(firstXCoordinate, secondXCoordinate)
                    && xCoordinate <= Math.Max(firstXCoordinate, secondXCoordinate);
            }
            float y1 = (xCoordinate - firstXCoordinate + temp) * (firstYCoordinate - secondYCoordinate)
                / (firstXCoordinate - secondXCoordinate) + firstYCoordinate;
            float y2 = (xCoordinate - firstXCoordinate - temp) * (firstYCoordinate - secondYCoordinate)
                / (firstXCoordinate - secondXCoordinate) + firstYCoordinate;
            return yCoordinate <= Math.Max(y1, y2) && yCoordinate >= Math.Min(y1, y2);
        }

        private double Distation(float x1, float y1, float x2, float y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        /// <summary>
        /// Determines the number of end, which coordinates will be changed
        /// </summary>
        public int NumberOfRemovingEnd(float xCoordinate, float yCoordinate)
        {
            float temp = 1000;
            double distOne = Distation(xCoordinate, yCoordinate, firstXCoordinate, firstYCoordinate);
            double distTwo = Distation(xCoordinate, yCoordinate, secondYCoordinate, secondYCoordinate);
            while (distOne <= temp && distTwo <= temp)
            {
                temp /= 2;
            }
            if (distOne < temp)
            {
                return 1;
            }
            if (distTwo < temp)
            {
                return 2;
            }
            return 0;
        }
    }
}
