using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphEdior
{
    class TaskInfo
    {
        private int m_X;
        private int m_Y;
        private int m_W;
        private int m_H;
     
        public TaskInfo(Point start, Point end)
        {
            m_X = Math.Min(start.X, end.X);
            m_Y = Math.Min(start.Y, end.Y);
            m_W = Math.Abs(start.X - end.X);
            m_H = Math.Abs(start.Y - end.Y);
        }

        public int X
        {
            get { return m_X; }
        }

        public int Y
        {
            get { return m_Y; }
        }

        public int W
        {
            get { return m_W; }
        }

        public int H
        {
            get { return m_H; }
        }

        public int MaxX
        {
            get { return m_X + m_W; }
        }

        public int MaxY
        {
            get { return m_Y + m_H; }
        }
    };

}