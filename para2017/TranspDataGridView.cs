using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace para2017
{
    class TranspDataGridView : DataGridView
    {
        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);
            this.Refresh();
        }
        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
            graphics.Clear(Color.FromArgb(230, Color.DarkTurquoise));
            SetCellsTransparent();

            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(new Rectangle(-this.Location.X, -this.Location.Y, Parent.ClientRectangle.Width, Parent.ClientRectangle.Height));

            //PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
           Color customColor = Color.FromArgb(230, Color.Black);
            //Color customColor = Color.Transparent;
            SolidBrush shadowBrush = new SolidBrush(customColor);
            //pathGradientBrush.CenterColor = Color.FromArgb(105, 88, 44);
            //Color[] colors = { Color.FromArgb(250,36, 30, 15) };
            //pathGradientBrush.SurroundColors = colors;
            
            graphics.FillRectangle(shadowBrush, gridBounds);
        }
        public void SetCellsTransparent()
        {
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            this.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;


            foreach (DataGridViewColumn col in this.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.Transparent;
                col.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            }
        }
    }
}
