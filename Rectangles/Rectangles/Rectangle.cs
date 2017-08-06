// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="Aston Inc.">
//   Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Aston Sanders</author>
// <summary>
//   Defines the Rectangle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rectangles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms.DataVisualization.Charting;

    /// <summary>
    /// The rectangle entity.
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Represents the coordinate pair of the rectangle's top left point.
        /// </summary>
        private readonly int[] topLeftPoint;

        /// <summary>
        /// Represents the coordinate pair of the rectangle's top right point.
        /// </summary>
        private readonly int[] topRightPoint;

        /// <summary>
        /// Represents the coordinate pair of the rectangle's bottom left point.
        /// </summary>
        private readonly int[] bottomLeftPoint;

        /// <summary>
        /// Represents the coordinate pair of the rectangle's bottom right point.
        /// </summary>
        private readonly int[] bottomRightPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the rectangle's top left point.</param>
        /// <param name="y">The y-axis coordinate of the rectangle's top left point.</param>
        /// <param name="height">The height of the rectangle. Must be greater than 0.</param>
        /// <param name="length">The length of the rectangle. Must be greater than 0.</param>
        public Rectangle(int x, int y, int height, int length)
        {
            if (height <= 0)
            {
                throw new ArgumentException(@"The height of the rectangle must be greater than 0.", nameof(height));
            }

            if (length <= 0)
            {
                throw new ArgumentException(@"The length of the rectangle must be greater than 0.", nameof(length));
            }

            this.topLeftPoint = new[] { x, y };
            this.topRightPoint = new[] { x + length, y };
            this.bottomLeftPoint = new[] { x, y - height };
            this.bottomRightPoint = new[] { x + length, y - height };
        }

        /// <summary>
        /// The coordinates.
        /// </summary>
        private enum Coordinates
        {
            /// <summary>
            /// The x-axis coordinate.
            /// </summary>
            X,

            /// <summary>
            /// the y-axis coordinate.
            /// </summary>
            Y
        }

        /// <summary>
        /// Gets the data points to for the four corners of the rectangle.
        /// </summary>
        /// <returns>A list of data points.</returns>
        public IEnumerable<DataPoint> GetDataPoints()
        {
            List<DataPoint> points = new List<DataPoint>
            {
                new DataPoint(this.topLeftPoint[(int)Coordinates.X], this.topLeftPoint[(int)Coordinates.Y]),
                new DataPoint(this.topRightPoint[(int)Coordinates.X], this.topRightPoint[(int)Coordinates.Y]),
                new DataPoint(this.bottomLeftPoint[(int)Coordinates.X], this.bottomLeftPoint[(int)Coordinates.Y]),
                new DataPoint(this.bottomRightPoint[(int)Coordinates.X], this.bottomRightPoint[(int)Coordinates.Y])
            };
            return points;
        }

        /// <summary>
        /// Determines if this rectangles intersects the given rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to check intersection with.</param>
        /// <returns>The intersection point rectangle or null if there are no intersections.</returns>
        public string Intersects(Rectangle rectangle)
        {
            if (this.topLeftPoint[(int)Coordinates.X] > rectangle.bottomRightPoint[(int)Coordinates.X]
                || rectangle.topLeftPoint[(int)Coordinates.X] > this.bottomRightPoint[(int)Coordinates.X])
            {
                return null;
            }

            if (this.topLeftPoint[(int)Coordinates.Y] < rectangle.bottomRightPoint[(int)Coordinates.Y]
                || rectangle.topLeftPoint[(int)Coordinates.Y] < this.bottomRightPoint[(int)Coordinates.Y])
            {
                return null;
            }

            int x2 = Math.Max(this.bottomLeftPoint[(int)Coordinates.X], rectangle.bottomLeftPoint[(int)Coordinates.X]);
            int y2 = Math.Max(this.bottomLeftPoint[(int)Coordinates.Y], rectangle.bottomLeftPoint[(int)Coordinates.Y]);
            int x3 = Math.Min(this.topRightPoint[(int)Coordinates.X], rectangle.topRightPoint[(int)Coordinates.X]);
            int y3 = Math.Min(this.topRightPoint[(int)Coordinates.Y], rectangle.topRightPoint[(int)Coordinates.Y]);
            int x = x2;
            int y = y3;
            int x4 = x3;
            int y4 = y2;

            List<int> xValues = GetXValues(rectangle);
            List<int> yValues = GetYValues(rectangle);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Intersection points: ");
            if ((xValues.Contains(x) || yValues.Contains(y)) && !IsDataPoint(rectangle, x, y))
            {
                sb.Append("(").Append(x).Append(",").Append(y).AppendLine(")");
            }

            if ((xValues.Contains(x2) || yValues.Contains(y2)) && !IsDataPoint(rectangle, x2, y2))
            {
                sb.Append("(").Append(x2).Append(",").Append(y2).AppendLine(")");
            }

            if ((xValues.Contains(x3) || yValues.Contains(y3)) && !IsDataPoint(rectangle, x3, y3))
            {
                sb.Append("(").Append(x3).Append(",").Append(y3).AppendLine(")");
            }

            if ((xValues.Contains(x4) || yValues.Contains(y4)) && !IsDataPoint(rectangle, x4, y4))
            {
                sb.Append("(").Append(x4).Append(",").Append(y4).AppendLine(")");
            }

            return sb.ToString();
        }        

        /// <summary>
        /// Checks to see if the given rectangle is completely contained within this rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to check.</param>
        /// <returns>A value indicating whether or not the given rectangle is contained within this rectangle.</returns>
        public bool Contains(Rectangle rectangle)
        {
            return rectangle.topLeftPoint[(int)Coordinates.X] > this.topLeftPoint[(int)Coordinates.X]
                   && rectangle.topLeftPoint[(int)Coordinates.Y] < this.topLeftPoint[(int)Coordinates.Y]
                   && rectangle.bottomRightPoint[(int)Coordinates.X] < this.bottomRightPoint[(int)Coordinates.X]
                   && rectangle.bottomRightPoint[(int)Coordinates.Y] > this.bottomRightPoint[(int)Coordinates.Y];
        }

        /// <summary>
        /// Determines if this rectangle is adjacent to the given rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to check for adjacency.</param>
        /// <returns>A value indicating whether or not this rectangle is adjacent to the given rectangle.</returns>
        public bool IsAdjacentTo(Rectangle rectangle)
        {
            // Top to top adjacency
            if (this.topLeftPoint[(int)Coordinates.Y] == rectangle.topLeftPoint[(int)Coordinates.Y]
                && this.topLeftPoint[(int)Coordinates.X] <= rectangle.topLeftPoint[(int)Coordinates.X]
                && this.topRightPoint[(int)Coordinates.X] >= rectangle.topRightPoint[(int)Coordinates.X]
                && rectangle.bottomRightPoint[(int)Coordinates.Y] >= this.bottomRightPoint[(int)Coordinates.Y])
            {
                return true;
            }

            // Top to bottom adjacency
            if (this.topLeftPoint[(int)Coordinates.Y] == rectangle.bottomLeftPoint[(int)Coordinates.Y]
                && rectangle.bottomRightPoint[(int)Coordinates.X] >= this.topLeftPoint[(int)Coordinates.X]
                && rectangle.bottomLeftPoint[(int)Coordinates.X] <= this.topRightPoint[(int)Coordinates.X])
            {
                return true;
            }

            // Left to left adjacency
            if (this.topLeftPoint[(int)Coordinates.X] == rectangle.topLeftPoint[(int)Coordinates.X]
                && this.topLeftPoint[(int)Coordinates.Y] >= rectangle.topLeftPoint[(int)Coordinates.Y]
                && this.bottomLeftPoint[(int)Coordinates.Y] <= rectangle.bottomLeftPoint[(int)Coordinates.Y]
                && rectangle.bottomRightPoint[(int)Coordinates.X] <= this.bottomRightPoint[(int)Coordinates.X])
            {
                return true;
            }

            // Left to right adjacency
            if (this.topLeftPoint[(int)Coordinates.X] == rectangle.topRightPoint[(int)Coordinates.X]
                && rectangle.bottomRightPoint[(int)Coordinates.Y] <= this.topLeftPoint[(int)Coordinates.Y]
                && rectangle.topRightPoint[(int)Coordinates.Y] >= this.bottomLeftPoint[(int)Coordinates.Y])
            {
                return true;
            }

            // Right to right adjacency
            if (this.topRightPoint[(int)Coordinates.X] == rectangle.topRightPoint[(int)Coordinates.X]
                && this.bottomRightPoint[(int)Coordinates.Y] <= rectangle.bottomRightPoint[(int)Coordinates.Y]
                && this.topRightPoint[(int)Coordinates.Y] >= rectangle.topRightPoint[(int)Coordinates.Y]
                && rectangle.bottomLeftPoint[(int)Coordinates.X] >= this.bottomLeftPoint[(int)Coordinates.X])
            {
                return true;
            }

            // Bottom to bottom adjacency
            if (this.bottomLeftPoint[(int)Coordinates.Y] == rectangle.bottomLeftPoint[(int)Coordinates.Y]
                && this.bottomLeftPoint[(int)Coordinates.X] <= rectangle.bottomRightPoint[(int)Coordinates.X]
                && this.bottomRightPoint[(int)Coordinates.X] >= rectangle.bottomRightPoint[(int)Coordinates.X]
                && rectangle.topRightPoint[(int)Coordinates.Y] <= this.topRightPoint[(int)Coordinates.Y])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the unique x-axis values for the given rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to get the x-axis values from.</param>
        /// <returns>The list of x-axis coordinates.</returns>
        private static List<int> GetXValues(Rectangle rectangle)
        {
            List<int> values = new List<int>
                                   {
                                       rectangle.topLeftPoint[(int)Coordinates.X],
                                       rectangle.bottomRightPoint[(int)Coordinates.X]
                                   };

            return values;
        }

        /// <summary>
        /// Gets the unique y-axis values for the given rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to get the y-axis values from.</param>
        /// <returns>The list of y-axis coordinates.</returns>
        private static List<int> GetYValues(Rectangle rectangle)
        {
            List<int> values = new List<int>
                                   {
                                       rectangle.topLeftPoint[(int)Coordinates.Y],
                                       rectangle.bottomLeftPoint[(int)Coordinates.Y]
                                   };

            return values;
        }

        /// <summary>
        /// Determines if the given x and y coordinates are an existing corner point of the given rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to check.</param>
        /// <param name="x">The x-axis coordinate.</param>
        /// <param name="y">The y-axis coordinate.</param>
        /// <returns>A value indicating if the given point is a corner of the given rectangle.</returns>
        private static bool IsDataPoint(Rectangle rectangle, int x, int y)
        {
            if (rectangle.topLeftPoint[(int)Coordinates.X] == x && rectangle.topLeftPoint[(int)Coordinates.Y] == y)
            {
                return true;
            }

            if (rectangle.topRightPoint[(int)Coordinates.X] == x && rectangle.topRightPoint[(int)Coordinates.Y] == y)
            {
                return true;
            }

            if (rectangle.bottomLeftPoint[(int)Coordinates.X] == x && rectangle.bottomLeftPoint[(int)Coordinates.Y] == y)
            {
                return true;
            }

            if (rectangle.bottomRightPoint[(int)Coordinates.X] == x && rectangle.bottomRightPoint[(int)Coordinates.Y] == y)
            {
                return true;
            }

            return false;
        }
    }
}
