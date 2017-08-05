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
            this.bottomLeftPoint = new[] { x, y + height };
            this.bottomRightPoint = new[] { x + length, y + height };
        }
    }
}
