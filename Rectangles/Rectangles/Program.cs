// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Aston Inc.">
//   Copyright (c) 2017 All Rights Reserved
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rectangles
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RectanglesForm());
        }
    }
}
