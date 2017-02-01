using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Snake
{
	public partial class Yard : Form
	{
		public Yard()
		{
			InitializeComponent();
		}

		private void Yard_Load(object sender, EventArgs e)
		{
			this.Size = new Size(ROWS * BLOCK_SIZE, COLS * BLOCK_SIZE);
			
			str = "";
		}

		Snake s = new Snake();
		Egg egg = new Egg(15, 15);
		private static int _score = 0;

		public static int Score
		{
			get { return Yard._score; }
			set { Yard._score = value; }
		}

		public static int BLOCK_SIZE = 20;

		public static int ROWS = 30;
		public static int COLS = 30;

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (lblGameOver.Visible == false)
			{
				s.paint(this);
				egg.draw(this);
			}
			else
			{
				if (count > 5 - 1)
				{
					timer1.Stop();
					Thread.Sleep(10 * 100);
					timer1.Start();
					Yard.Score = 0;
					lblScore.Text = "Score :" + Yard.Score.ToString();
					lblGameOver.Text = "得分清零";
					count = 0;
				}
			}
			if (s.getcol() == egg.col && s.getrow() == egg.row)
			{
				s.eat();
				Yard.Score += 5;
				lblScore.Text = "Score :" + Yard.Score.ToString();
				egg.reinitial();
			}
		}

		bool flag = false;

		int count = 0;
		private void Yard_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.W || e.KeyChar == (char)Keys.W + 32)
			{
				s.keypressed("w");
			}
			else if (e.KeyChar == (char)Keys.S || e.KeyChar == (char)Keys.S + 32)
			{
				s.keypressed("s");
			}
			else if (e.KeyChar == (char)Keys.A || e.KeyChar == (char)Keys.A + 32)
			{
				s.keypressed("a");
			}
			else if (e.KeyChar == (char)Keys.D || e.KeyChar == (char)Keys.D + 32)
			{
				s.keypressed("d");
			}
			else if (e.KeyChar == (char)Keys.K || e.KeyChar == (char)Keys.K + 32)
			{
				if (lblGameOver.Visible == false)
				{
					DialogResult resust = MessageBox.Show("是否保留上次最后死亡痕迹?", "有意思!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (resust == DialogResult.No)
					{
						s.clear();
						count++;
						lblGameOver.Visible = false;
						s = new Snake();
					}
					else
					{
						count++;
						lblGameOver.Visible = false;
						s = new Snake();
					}
				}
				else
				{
					count++;
					lblGameOver.Visible = false;
					s = new Snake();
				}
			}
			else if (e.KeyChar == (char)Keys.P || e.KeyChar == (char)Keys.P + 32)
			{
				if (flag == false)
				{
					timer1.Stop();
					flag = true;
				}
				else
				{
					timer1.Start();
					flag = false;
				}
			}
		}

		private void txtRate_TextChanged(object sender, EventArgs e)
		{
			
		}

		static string str;


		private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar ==(char) Keys.D1||
				e.KeyChar == (char)Keys.D2 ||
				e.KeyChar == (char)Keys.D3 ||
				e.KeyChar == (char)Keys.D4 ||
				e.KeyChar == (char)Keys.D5 ||
				e.KeyChar == (char)Keys.D6 ||
				e.KeyChar == (char)Keys.D7 ||
				e.KeyChar == (char)Keys.D8 ||
				e.KeyChar == (char)Keys.D9 ||
				e.KeyChar == (char)Keys.D0 ||
				e.KeyChar==(char)Keys.Back)
			{
				str=txtRate.Text;
			}
			else
			{
				e.Handled = true;
				//txtRate.Text = str;
			}
		}

		public static int size=3;

		public static string snake = "佳";

		private void button1_Click(object sender, EventArgs e)
		{
			if (!txtRate.Text.Trim().Equals(string.Empty)||!txtSize.Text.Trim().Equals(string.Empty)||!txtSnake.Text.Trim().Equals(string.Empty))
			{
				timer1.Interval = Convert.ToInt32(txtRate.Text);
				snake = txtSnake.Text;
				size = Convert.ToInt32(txtSize.Text);
				timer1.Start();
				lblScore.Text = "Score:" + Yard.Score;
				lblScore.Visible = true;
				groupBox1.Visible = false;
				groupBox2.Visible = false;
				button1.Visible = false;
				this.Focus();
			}
		}

		private void txtSize_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (Convert.ToInt32(txtSize.Text) > 15)
				{
					txtSize.Text = "";
				}
			}
			catch (Exception ex)
			{
				txtSize.Text = "";
				MessageBox.Show("不能大于15");
			}
		}
	}

	public class Snake
	{
		Node head;
		Node tail;
		int size = 1;
		Yard y;

		int count = 0;

		public void paint(Yard y)
		{
			if (size == 0)
			{
				return;
			}
			if (count == 0)
			{
				this.y = y;
				Node n = new Node(20, 22, Dir.L, y);
				this.head = n;
				this.tail = n;
				head.next = tail;
				head.prev = head;
				tail.prev = head;
				tail.next = tail;
				for (int i = 0; i < Yard.size; i++)
				{
					AddToHead();
					size++;
				}
				count++;
			}
			else
			{
				if (size == 0)
				{
					return;
				}
				move();
				draw();
			}
		}

		void draw()
		{
			for (Node node = head; node != null; node = node.next)
			{
				node.paint();
			}
			//AddToHead();
		}

		public void eat()
		{
			AddToHead();
			size++;
		}

		public int getrow()
		{
			if (size == 0)
			{
				return -1;
			}
			return head.row;
		}

		public int getcol()
		{
			if (size == 0)
			{
				return -1;
			}
			return head.col;
		}

		public void keypressed(string s)
		{
			if (size == 0)
			{
				return;
			}
			switch (s)
			{
				case "w":
					if (head.dir != Dir.D)
					{
						head.dir = Dir.U;
					}
					break;
				case "s":
					if (head.dir != Dir.U)
					{
						head.dir = Dir.D;
					}
					break;
				case "a":
					if (head.dir != Dir.R)
					{
						head.dir = Dir.L;
					}
					break;
				case "d":
					if (head.dir != Dir.L)
					{
						head.dir = Dir.R;
					}
					break;
				default:
					break;
			}
		}

		private void AddToHead()
		{
			Node n;
			switch (head.dir)
			{
				case Dir.R:
					n = new Node(head.row + 1, head.col, head.dir, head.y);
					n.next = head;
					head.prev = n;
					head = n;

					break;
				case Dir.L:
					n = new Node(head.row - 1, head.col, head.dir, head.y);
					n.next = head;
					head.prev = n;
					head = n;

					break;
				case Dir.U:
					n = new Node(head.row, head.col - 1, head.dir, head.y);
					n.next = head;
					head.prev = n;
					head = n;

					break;
				case Dir.D:
					n = new Node(head.row, head.col + 1, head.dir, head.y);
					n.next = head;
					head.prev = n;
					head = n;

					break;
			}

		}

		public void move()
		{
			AddToHead();
			DeleteFromTail();
			checkDead();
		}

		private void DeleteFromTail()
		{
			tail = tail.prev;
			tail.y.Controls.Remove(tail.next.N);
			tail.next = null;
		}

		void checkDead()
		{
			if (size == 0)
			{
				return;
			}
			if (head.row < 0 || head.col < 0 || head.col >= Yard.COLS - 2 || head.row >= Yard.ROWS - 1)
			{
				y.lblGameOver.Visible = true;
				clear();
			}
			if (size == 0)
			{
				return;
			}
			for (Node n = head.next; n != null; n = n.next)
			{
				if (n.row == head.row && n.col == head.col)
				{
					y.lblGameOver.Visible = true;
					clear();
				}
			}
		}

		public void clear()
		{
			if (size==0)
			{
				return;
			}
			while (tail.prev != null)
			{
				tail = tail.prev;
				tail.next.y.Controls.Remove(tail.next.N);
				tail.next = null;
				size--;
			}
			head.y.Controls.Remove(head.N);
			head = null;
			size--;
		}

		private class Node
		{
			public Label N = new Label();
			public int row;
			public int col;
			public Dir dir;
			public Node next;
			public Node prev;
			public Yard y;

			public Node(int row, int col, Dir dir, Yard y)
			{
				this.row = row;
				this.col = col;
				this.dir = dir;
				this.y = y;

			}

			/// <summary>
			/// 画蛇的每一节身躯
			/// </summary>
			public void paint()
			{
				//█
				N.Text =Yard.snake;
				N.ForeColor = Color.Red;
				N.TextAlign=ContentAlignment.MiddleLeft;
				N.AutoSize = false;
				N.BackColor = Color.Transparent;
				N.Location = new Point(this.row * Yard.BLOCK_SIZE, this.col * Yard.BLOCK_SIZE);
				N.Size = new Size(Yard.BLOCK_SIZE, Yard.BLOCK_SIZE);
				N.Font = new Font("楷体", 13);
				y.Controls.Add(N);
			}

			public void move()
			{
				N.Location = new Point(1000, 1000);
			}

		}

	}

	public class Egg
	{
		public Label N = new Label();
		public int row, col;

		public Yard y;

		public Egg(int row, int col)
		{
			this.row = row;
			this.col = col;
		}

		public void draw(Yard y)
		{
			N.Text = "●";
			N.AutoSize = false;
			N.Font = new Font("楷体", 13);
			N.BackColor = Color.Transparent;
			this.y = y;
			if (N.ForeColor == Color.Green)
			{
				N.ForeColor = Color.Red;
			}
			else
			{
				N.ForeColor = Color.Green;
			}
			N.Location = new Point(this.row * Yard.BLOCK_SIZE, this.col * Yard.BLOCK_SIZE);
			N.Size = new Size(Yard.BLOCK_SIZE, Yard.BLOCK_SIZE);
			this.y.Controls.Add(N);

		}

		Random r = new Random();

		public void reinitial()
		{
			this.row = r.Next(2, 27);
			this.col = r.Next(2, 27);
		}

	}

	enum Dir
	{
		D, U, L, R
	}
}
