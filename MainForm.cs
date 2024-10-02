/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 10/2/2024
 * Time: 11:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace circleRotatingAroundOtherCircle
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Graphics g;
		public Font f;
		public Pen p = new Pen(Color.Black);
		public Brush b = new SolidBrush(Color.Black);
		public Random r = new Random();
		public int x = 0;
		public int y = 0;
		public int px = 0;
		public int py = 0;
		public List<pair>lp = new List<pair>();
		public int i = 0;
		public double rad = 180/Math.PI;
		public int speed = 12;
		public int animationSpeed = 200;
		void MainFormLoad(object sender, EventArgs e)
		{
			g = this.panel1.CreateGraphics();
			f = this.Font;
			x = (panel1.Width/2)-50+150;
			y = (panel1.Height/2)-50+150;
			timer1.Interval = animationSpeed;
			loaddatas();
		}
			
		public void loaddatas()
		{
			double cx = 0;
			double cy = 0;
			for(int ij = 0 ; ij < 360 ; ij+=1)
			{
					 cx = 200*(Math.Cos(ij/rad))+200;
					 cy = 200*(Math.Sin(ij/rad))+200;
					 lp.Add(new pair((int)cx,(int)cy));
					 Text = lp.Count.ToString();
					// textBox1.Text += "{" + cx.ToString() + "," + cy.ToString() + "} ," ;
			}
		}
		public void drawCentralCircle()
		{
			g.DrawEllipse(p,150,150,100,100);
			
		}
		public void drawLateralCircle(int x, int y)
		{
			g.DrawEllipse(p,x,y,10,10);
			
		}
		public void drawLine()
		{
			
			g.DrawLine(p,200,200,x-5,y-5);
			g.DrawLine(p,200,200,px,py);
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.timer1.Enabled = true;
			
			
		}
		public void addPairInlp(pair p)
		{
			lp.Add(p);
		}
		public class pair 
		{
			public int x = 0;
			public int y = 0;
			public pair(int px ,int py)
			{
				x = px;
				y = py;
			}
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			g.Clear(panel1.BackColor);
			i+=speed;
			if(i>360){i=0;}
			try{
			x=lp[i].x;
			y=lp[i].y;
			px = x;
			py = y;
			}
			catch{};
			drawCentralCircle();
			drawLateralCircle(x,y);
			drawLine();
		}
		void Button2Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.textBox1.Text);
		}
			
			
	}
}
