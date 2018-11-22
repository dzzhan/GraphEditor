using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphEdior
{
    public partial class GraphEdit : Form
    {
        private Point m_stCurrentPoint;
        private Point m_stStartPoint;
        private Graphics m_stGraphs;
        private Pen m_stPen;
        private List<TaskInfo> m_vTaskList = null;
        private Point m_stScrollPoint;
     
        public GraphEdit()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.m_stGraphs = this.CreateGraphics();//实例化Graphics类
            this.m_stPen = new Pen(Color.Red, 3);//实例化Pen类
            this.m_vTaskList = new List<TaskInfo>();
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            statusLabel.Text = rect.ToString();
            AutoScrollMinSize = new Size(m_stScrollPoint.X, m_stScrollPoint.Y);
        }

        private void addDSPTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void GraphEdit_Load(object sender, EventArgs e)
        {

        }

        private void GraphEdit_MouseMove(object sender, MouseEventArgs e)
        {
            m_stCurrentPoint = e.Location;
            //statusLabel.Text = m_stCurrentPoint.ToString();
        }

        private void GraphEdit_MouseDown(object sender, MouseEventArgs e)
        {
            m_stStartPoint = e.Location;
        }
        private void GraphEdit_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (m_vTaskList != null)
            {
                m_stGraphs.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
                ShowAllTasks();
            }
        }

        private void GraphEdit_MouseUp(object sender, MouseEventArgs e)
        {
            TaskInfo taskInfo = new TaskInfo(m_stStartPoint, e.Location);
            m_vTaskList.Add(taskInfo);
            ShowTask(taskInfo);
            m_stScrollPoint.X = Math.Max(m_stScrollPoint.X, taskInfo.MaxX + 200);
            m_stScrollPoint.Y = Math.Max(m_stScrollPoint.Y, taskInfo.MaxY + 200);
            AutoScrollMinSize = new Size(m_stScrollPoint.X, m_stScrollPoint.Y);
        }

        private void ShowTask(TaskInfo taskInfo)
        {
            m_stGraphs.DrawRectangle(m_stPen, taskInfo.X, taskInfo.Y, taskInfo.W, taskInfo.H);
        }

        private void ShowAllTasks()
        {
            m_stGraphs.Clear(Color.White);
            foreach (TaskInfo taskInfo in m_vTaskList)
            {
                ShowTask(taskInfo);
            }
        }

        private void GraphEdit_Resize(object sender, System.EventArgs e)
        {
            if (m_vTaskList != null)
            {
                ShowAllTasks();
            }
        }
    }
}
