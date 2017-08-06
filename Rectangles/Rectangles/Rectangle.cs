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
    using System.Windows.Forms.DataVisualization.Charting;

    /// <summary>
    /// The rectangle entity.
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Represents the coordinate pair of the rectangle's top left point.
        /// </summary>
        private int[] topLeftPoint;

        /// <summary>
        /// Represents the coordinate pair of the rectangle's top right point.
        /// </summary>
        private int[] topRightPoint;

        /// <summary>
        /// Represents the coordinate pair of the rectangle's bottom left point.
        /// </summary>
        private int[] bottomLeftPoint;

        /// <summary>
        /// Represents the coordinate pair of the rectangle's bottom right point.
        /// </summary>
        private int[] bottomRightPoint;

        /// <summary>
        /// Represents the height of the rectangle.
        /// </summary>
        private int height;

        /// <summary>
        /// Represents the length of the rectangle.
        /// </summary>
        private int length;

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

            this.height = height;

            if (length <= 0)
            {
                throw new ArgumentException(@"The length of the rectangle must be greater than 0.", nameof(length));
            }

            this.length = length;
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
        /// <returns>A value indicating whether or not the rectangles intersect.</returns>
        public bool Intersects(Rectangle rectangle)
        {
            if (this.topLeftPoint[(int)Coordinates.X] > rectangle.bottomRightPoint[(int)Coordinates.X]
                || rectangle.topLeftPoint[(int)Coordinates.X] > this.bottomRightPoint[(int)Coordinates.X])
            {
                return false;
            }

            if (this.topLeftPoint[(int)Coordinates.Y] < rectangle.bottomRightPoint[(int)Coordinates.Y]
                || rectangle.topLeftPoint[(int)Coordinates.Y] < this.bottomRightPoint[(int)Coordinates.Y])
            {
                return false;
            }

            return true;
        }

        public bool Contains(Rectangle rectangle)
        {
            if (((rectangle.topLeftPoint[(int)Coordinates.X] + rectangle.length) < (this.topLeftPoint[(int)Coordinates.X] + this.length))
                && (rectangle.topLeftPoint[(int)Coordinates.X] >= this.topLeftPoint[(int)Coordinates.X])
                && (rectangle.topLeftPoint[(int)Coordinates.Y] <= this.topLeftPoint[(int)Coordinates.Y])
                && ((rectangle.topLeftPoint[(int)Coordinates.Y] + rectangle.height) < (this.topLeftPoint[(int)Coordinates.Y] + this.height)))
            {
                return true;
            }

            return false;
        }
    }
}
