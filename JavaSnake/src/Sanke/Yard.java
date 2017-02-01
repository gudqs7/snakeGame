package Sanke;

import java.awt.Color;
import java.awt.Font;
import java.awt.Frame;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

import javax.management.monitor.Monitor;

@SuppressWarnings({ "unused", "serial" })
public class Yard extends Frame
{

	@Override
	public void update(Graphics g) {
		if(offScreenImage==null)
		{
			offScreenImage = this.createImage(BLOCK_SIZE*COLS,BLOCK_SIZE*ROWS);
		}
		Graphics goff=offScreenImage.getGraphics();
		paint(goff);
		g.drawImage(offScreenImage,0,0,null);
	}
	
	Image offScreenImage = null;

	public PaintThread paintThread=new PaintThread();
	
	private boolean gameOver = false; //游戏是否结束
	
	/**
	 * 行数
	 */
	public static final int ROWS = 30;
	public static final int COLS = 30;
	public static final int BLOCK_SIZE = 15;
	
	private Font fontGameOver = new Font(Messages.getString("Yard.0"), Font.BOLD, 50); //$NON-NLS-1$
	private Font fontSorce=new Font(Messages.getString("Yard.0"), Font.BOLD, 18);
	
	private int score = 0;
	
	public void stop()
	{
		gameOver=true;
		
	}
	
	public int getScore() {
		return score;
	}

	public void setScore(int score) {
		this.score = score;
	}

	/**
	 * 初始化
	 */
	public void lunch()
	{
		
		this.setLocation(380,80);
		this.setSize(BLOCK_SIZE*COLS,BLOCK_SIZE*ROWS);
		this.addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent e) {
				// TODO Auto-generated method stub
				System.exit(0);
			}
		});
		this.addKeyListener(new KeyMonitor());
		this.setVisible(true);
		
		new Thread(paintThread).start();
	}
	
	
	
	public static void main(String[] args) 
	{
		new Yard().lunch();
		
	}
	
	Snake s=new Snake(this);
	Egg e=new Egg();
	
	@Override
	public void paint(Graphics g) 
	{
		Color c =g.getColor();
		g.setColor(Color.gray);
		g.fillRect(0,0, BLOCK_SIZE*ROWS, BLOCK_SIZE*COLS);
		g.setColor(Color.DARK_GRAY);
		for (int i = 3; i < ROWS; i++) 
		{
			g.drawLine(0, BLOCK_SIZE*i, COLS*BLOCK_SIZE, BLOCK_SIZE*i);
		}
		
		for (int i = 1; i < COLS; i++) {
			g.drawLine(BLOCK_SIZE*i, 0, BLOCK_SIZE*i, ROWS*BLOCK_SIZE);
			
		}
		g.setColor(Color.black);
		
		s.eat(e);
		e.draw(g);
		s.draw(g);
		
		g.setColor(Color.yellow);
		if(gameOver)
		{
			g.setFont(fontGameOver);
			g.drawString("游戏结束", 120, 200);
			paintThread.pause(false);
		}
		g.setFont(fontSorce);
		g.drawString("分数:"+score, 20, 60);
		
		g.setColor(c);
	
	}

	
	private class PaintThread implements Runnable
	{
		private boolean running=true;
		private boolean pause=false;
		public void run() {
			while (running)
			{
				if(pause)
					continue;
				else 
					repaint();
				try {
					Thread.sleep(100);
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
			}
		}
		boolean flag=true;
		
		public void pause(boolean b) {
			
			if(b)
			{
				
				if(flag)
				{
					pause=true;
					flag=false;
				}else{
					pause=false;
					flag=true;
				}
			}else {
				pause=true;
			}
		}

		public void reStart() {
			this.pause = false;
			gameOver = false;
		}

		public void gameOver() {
			running = false;
		}
			
	}
	
	private class KeyMonitor extends KeyAdapter{

		@Override
		public void keyPressed(KeyEvent e) {
			int key=e.getKeyCode();
			if(key==KeyEvent.VK_F2)
			{
				gameOver=false;
				s=new Snake(Yard.this);
				paintThread.reStart();
			}
			else if(key==KeyEvent.VK_P)
			{
				paintThread.pause(true);
			}else if(key==KeyEvent.VK_K)
			{
				gameOver=false;
				paintThread.reStart();
			}
			s.keyPressed(e);
		}
		
	}
	
}
