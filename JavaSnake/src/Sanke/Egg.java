package Sanke;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;
import java.util.Random;



public class Egg {
	int row,col;
	int w=Yard.BLOCK_SIZE;
	int h=Yard.BLOCK_SIZE;
	
	private Color color=Color.green;
	
	private static Random r=new Random();
	
	public Egg(int row,int col)
	{
		this.row=row;
		this.col=col;
	}
	
	public Egg()
	{
		this(r.nextInt(Yard.ROWS-4)+4,r.nextInt(Yard.COLS-2)+2);
	}
	
	public void reApear()
	{
		this.row=r.nextInt(Yard.ROWS-4)+4;
		this.col=r.nextInt(Yard.COLS-2)+2;
	}
	
	void draw(Graphics g) 
	{
		Color c = g.getColor();
		g.setColor(color);
		g.fillOval(col*Yard.BLOCK_SIZE, row*Yard.BLOCK_SIZE, w, h);
		if (color == Color.GREEN)
			color = Color.RED;
		else
			color = Color.GREEN;
		g.setColor(c);
	}
	
	public Rectangle getrectRect()
	{
		return new Rectangle(col*Yard.BLOCK_SIZE, row*Yard.BLOCK_SIZE,w,h);
	}
	
}
