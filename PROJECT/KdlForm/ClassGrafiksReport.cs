using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace KdlForm
{
    class ClassGrafiksReport
    {
        public static void PrintToGraphics(Graphics graphics, Rectangle bounds, string pzagol0, DevExpress.XtraEditors.XtraForm _form1,int smechenie)
        {
            //this.Text = "";
            // const  string HELLO_WORLD = "HELLO WORLD ";  // this.Text;
            //HELLO_WORLD = PZAGOLOVOK0;  // this.Text;
            _form1.Text = "";
            var messageSize = graphics.MeasureString(pzagol0, _form1.Font);
            Bitmap bitmap0 = new Bitmap((int)messageSize.Width, (int)messageSize.Height);
            _form1.DrawToBitmap(bitmap0, new Rectangle(0, 0, bitmap0.Width, bitmap0.Height));

            Rectangle target0 = new Rectangle(0, 0, bitmap0.Width, bitmap0.Height);
            PointF p = new PointF(10, 5);
            //PointF p = new PointF((ClientSize.Width - messageSize.Width) / 2,
            // (ClientSize.Height - messageSize.Height) / 2);
            graphics.DrawString(pzagol0, _form1.Font, SystemBrushes.WindowText, p);
            //SettargetRazmer(bounds, target0, bitmap0);
            double xScale0 = (double)bitmap0.Width / bounds.Width;
            double yScale0 = (double)bitmap0.Height / bounds.Height;
            if (xScale0 < yScale0)
                target0.Width = (int)(xScale0 * target0.Width / yScale0);
            else
                target0.Height = (int)(yScale0 * target0.Height / xScale0);
            //==
            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap0, target0);
            //  this.Text = "";
            Bitmap bitmap = new Bitmap(_form1.Width, _form1.Height);
            _form1.DrawToBitmap(bitmap, new Rectangle(0, bitmap0.Height + smechenie, bitmap.Width, bitmap.Height));
            Rectangle target = new Rectangle(0, 0, bounds.Width, bounds.Height + smechenie);
            // SettargetRazmer(bounds, target, bitmap);
            double xScale = (double)bitmap.Width / bounds.Width;
            double yScale = (double)bitmap.Height / bounds.Height;
            if (xScale < yScale)
                target.Width = (int)(xScale * target.Width / yScale);
            else
                target.Height = (int)(yScale * target.Height / xScale);
            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap, target);

        } 
    }
}
