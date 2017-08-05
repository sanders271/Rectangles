// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="Aston Inc.">
//   Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Aston Sanders</author>
// <summary>
//   Defines the Form1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rectangles
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;

    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The first rectangle to analyze.
        /// </summary>
        private Rectangle rectangle1;

        /// <summary>
        /// The second rectangle to analyze.
        /// </summary>
        private Rectangle rectangle2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            // Set Chart Margins
            this.chart1.ChartAreas[0].Position.Auto = false;
            this.chart1.ChartAreas[0].Position.X = 10;
            this.chart1.ChartAreas[0].Position.Y = 10;
            this.chart1.ChartAreas[0].Position.Width = 80;
            this.chart1.ChartAreas[0].Position.Height = 80;

            // Configure X Axis
            this.chart1.ChartAreas[0].AxisX.Crossing = 0;
            this.chart1.ChartAreas[0].AxisX.Interval = 1;
            this.chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            this.chart1.ChartAreas[0].AxisX.LineWidth = 2;
            this.chart1.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;

            // Configure Y Axis
            this.chart1.ChartAreas[0].AxisY.Crossing = 0;
            this.chart1.ChartAreas[0].AxisY.Interval = 1;
            this.chart1.ChartAreas[0].AxisY.LineWidth = 2;
            this.chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            this.chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;

            // Set Chart Type
            this.chart1.Series[0].ChartType = SeriesChartType.Point;

            this.chart1.Series[0].IsVisibleInLegend = false;
        }

        /// <summary>
        /// The event called when the generate rectangles button is clicked.
        /// </summary>
        /// <param name="sender">The Sender.</param>
        /// <param name="e">The EventArgs.</param>
        private void GenerateRectanglesButtonClick(object sender, EventArgs e)
        {
            int xMax = 5;
            int xMin = -5;
            int yMax = 5;
            int yMin = -5;
            Random r = new Random();
            this.rectangle1 = new Rectangle(r.Next(xMin, xMax), r.Next(yMin, yMax), r.Next(1, yMax), r.Next(1, xMax));
            this.rectangle2 = new Rectangle(r.Next(xMin, xMax), r.Next(yMin, yMax), r.Next(1, yMax) + 5, r.Next(1, xMax) + 5);
            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.AddRange(this.rectangle1.GetDataPoints());
            dataPoints.AddRange(this.rectangle2.GetDataPoints());
            this.chart1.Series[0].Points.Clear();
            foreach (DataPoint dataPoint in dataPoints)
            {
                this.chart1.Series[0].Points.Add(dataPoint);
            }

            this.chart1.Invalidate();            
        }

        /// <summary>
        /// The event called after the chart control has been painted.
        /// </summary>
        /// <param name="sender">The Sender.</param>
        /// <param name="e">The ChartPaintEventArgs.</param>
        private void Chart1Paint(object sender, ChartPaintEventArgs e)
        {
            if (this.rectangle1 != null)
            {
                this.DrawRectangle(this.rectangle1, e, Color.Red);
            }

            if (this.rectangle2 != null)
            {
                this.DrawRectangle(this.rectangle2, e, Color.Blue);
            }
        }

        /// <summary>
        /// Draws the graphic lines for the given rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="chartPaintEventArgs">The ChartPaintEventArgs.</param>
        /// <param name="color">The color to draw the lines.</param>
        private void DrawRectangle(Rectangle rectangle, ChartPaintEventArgs chartPaintEventArgs, Color color)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.AddRange(rectangle.GetDataPoints());
            List<Point> drawPoints = new List<Point>();
            foreach (DataPoint p in dataPoints)
            {
                double x = this.chart1.ChartAreas[0].AxisX.ValueToPixelPosition(p.XValue);
                double y = this.chart1.ChartAreas[0].AxisY.ValueToPixelPosition(p.YValues[0]);
                drawPoints.Add(new Point((int)x, (int)y));
            }

            Point topLeft = drawPoints[0];
            Point topRight = drawPoints[1];
            Point bottomLeft = drawPoints[2];
            Point bottomRight = drawPoints[3];

            chartPaintEventArgs.ChartGraphics.Graphics.DrawLine(new Pen(color, 2), topLeft, topRight);
            chartPaintEventArgs.ChartGraphics.Graphics.DrawLine(new Pen(color, 2), topLeft, bottomLeft);
            chartPaintEventArgs.ChartGraphics.Graphics.DrawLine(new Pen(color, 2), topRight, bottomRight);
            chartPaintEventArgs.ChartGraphics.Graphics.DrawLine(new Pen(color, 2), bottomLeft, bottomRight);
        }
    }
}