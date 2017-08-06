namespace Rectangles
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GenerateRectanglesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IntersectionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ContainmentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(71, 69);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(797, 394);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "Graph";
            this.chart1.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.Chart1Paint);
            // 
            // GenerateRectanglesButton
            // 
            this.GenerateRectanglesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GenerateRectanglesButton.Location = new System.Drawing.Point(340, 513);
            this.GenerateRectanglesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GenerateRectanglesButton.Name = "GenerateRectanglesButton";
            this.GenerateRectanglesButton.Size = new System.Drawing.Size(215, 61);
            this.GenerateRectanglesButton.TabIndex = 1;
            this.GenerateRectanglesButton.Text = "Generate Rectangles";
            this.GenerateRectanglesButton.UseVisualStyleBackColor = true;
            this.GenerateRectanglesButton.Click += new System.EventHandler(this.GenerateRectanglesButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 604);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Intersection";
            // 
            // IntersectionLabel
            // 
            this.IntersectionLabel.AutoSize = true;
            this.IntersectionLabel.Location = new System.Drawing.Point(71, 650);
            this.IntersectionLabel.Name = "IntersectionLabel";
            this.IntersectionLabel.Size = new System.Drawing.Size(109, 46);
            this.IntersectionLabel.TabIndex = 3;
            this.IntersectionLabel.Text = "label2";
            this.IntersectionLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 604);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "Containment";
            // 
            // ContainmentLabel
            // 
            this.ContainmentLabel.AutoSize = true;
            this.ContainmentLabel.Location = new System.Drawing.Point(374, 650);
            this.ContainmentLabel.Name = "ContainmentLabel";
            this.ContainmentLabel.Size = new System.Drawing.Size(109, 46);
            this.ContainmentLabel.TabIndex = 5;
            this.ContainmentLabel.Text = "label2";
            this.ContainmentLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 779);
            this.Controls.Add(this.ContainmentLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IntersectionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GenerateRectanglesButton);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button GenerateRectanglesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IntersectionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ContainmentLabel;
    }
}

