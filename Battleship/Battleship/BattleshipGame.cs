//natalia grigoriants
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Battleship
{
    public partial class BattleshipGame : Form
    {
        Graphics gfxL;
        Bitmap bmpL;
        Grid gridL;
        Graphics gfxR;
        Bitmap bmpR;
        Grid gridR;
        Ship ship;
        Player bot;
        Player player;
        int b = 0;
        int p = 0;
        Random random = new Random();
        int turnspassed = 0;
        bool einBoolean = true;
        public BattleshipGame()
        {
            InitializeComponent();
        }
        public Square[,] Check(Square[,] Squares, Point e, Player player)
        {
            for (int k = 0; k < 5; k++)
            {
                for (int l = 0; l < player.Ships[k].size; l++)
                {
                    if (player.Ships[k].body[l] == new Point(e.X, e.Y))
                    {
                        Squares[e.X, e.Y].state = State.Hit;
                        return Squares;
                    }
                }
            }
            Squares[e.X, e.Y].state = State.Miss;
            return Squares;
        }
        private void BattlshipGame_Load(object sender, EventArgs e)
        {
            bmpR = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfxR = Graphics.FromImage(bmpR);
            gridR = new Grid();
            bmpL = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            gfxL = Graphics.FromImage(bmpL);
            gridL = new Grid();
            player = new Player();
            bot = new Player();
            for (int i = 0; i < 5; i++)
            {
                bool up = random.Next(2) == 0;
                Point start = new Point(random.Next(10), random.Next(10));
                Point end = new Point();
                if (up)
                {
                    end.X = start.X;
                    if(start.Y >= i)
                    {
                        end.Y = start.Y - i;
                    }
                    else
                    {
                        end.Y = start.Y + i;
                    }
                }
                else
                {
                    end.Y = start.Y;
                    if (start.X >= i)
                    {
                        end.X = start.X - i;
                    }
                    else
                    {
                        end.X = start.X + i;
                    }
                }
                while (!bot.Setter(start, end))
                {
                    up = random.Next(2) == 0;
                    start = new Point(random.Next(10), random.Next(10));
                    end = new Point();
                    if (up)
                    {
                        end.X = start.X;
                        if (start.Y >= i)
                        {
                            end.Y = start.Y - i;
                        }
                        else
                        {
                            end.Y = start.Y + i;
                        }
                    }
                    else
                    {
                        end.Y = start.Y;
                        if (start.X >= i)
                        {
                            end.X = start.X - i;
                        }
                        else
                        {
                            end.X = start.X + i;
                        }
                    }
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                if (player.Ships[i].isplaces == false)
                {
                    return;
                }
            }
            if (einBoolean)
            {
                double a = e.Location.Y / 40;
                double b = e.Location.X / 40;
                int i = (int)Math.Ceiling(a);
                int j = (int)Math.Ceiling(b);
                gridR.Squares = Check(gridR.Squares, new Point(i, j), bot);
                einBoolean = false;
                turnspassed += 1;
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            b = 0;
            p = 0;
            for(int i = 0; i < 5; i++)
            {
                if (bot.Ships[i].isSunk(gridR))
                {
                    b++;
                }
                if (player.Ships[i].isSunk(gridL))
                {
                    p++;
                }
            }
            if(b == 5)
            {
                MessageBox.Show("bot won");
                bmpR = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                gfxR = Graphics.FromImage(bmpR);
                gridR = new Grid();
                bmpL = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                gfxL = Graphics.FromImage(bmpL);
                gridL = new Grid();
                player = new Player();
                bot = new Player();
                b = 0;
                p = 0;
                for (int i = 0; i < 5; i++)
                {
                    bool up = random.Next(2) == 0;
                    Point start = new Point(random.Next(10), random.Next(10));
                    Point end = new Point();
                    if (up)
                    {
                        end.X = start.X;
                        if (start.Y >= i)
                        {
                            end.Y = start.Y - i;
                        }
                        else
                        {
                            end.Y = start.Y + i;
                        }
                    }
                    else
                    {
                        end.Y = start.Y;
                        if (start.X >= i)
                        {
                            end.X = start.X - i;
                        }
                        else
                        {
                            end.X = start.X + i;
                        }
                    }
                    while (!bot.Setter(start, end))
                    {
                        up = random.Next(2) == 0;
                        start = new Point(random.Next(10), random.Next(10));
                        end = new Point();
                        if (up)
                        {
                            end.X = start.X;
                            if (start.Y >= i)
                            {
                                end.Y = start.Y - i;
                            }
                            else
                            {
                                end.Y = start.Y + i;
                            }
                        }
                        else
                        {
                            end.Y = start.Y;
                            if (start.X >= i)
                            {
                                end.X = start.X - i;
                            }
                            else
                            {
                                end.X = start.X + i;
                            }
                        }
                    }
                }
            }
            if (p == 5)
            {
                MessageBox.Show("player won");
                bmpR = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                gfxR = Graphics.FromImage(bmpR);
                gridR = new Grid();
                bmpL = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                gfxL = Graphics.FromImage(bmpL);
                gridL = new Grid();
                player = new Player();
                bot = new Player();
                b = 0;
                p = 0;
                for (int i = 0; i < 5; i++)
                {
                    bool up = random.Next(2) == 0;
                    Point start = new Point(random.Next(10), random.Next(10));
                    Point end = new Point();
                    if (up)
                    {
                        end.X = start.X;
                        if (start.Y >= i)
                        {
                            end.Y = start.Y - i;
                        }
                        else
                        {
                            end.Y = start.Y + i;
                        }
                    }
                    else
                    {
                        end.Y = start.Y;
                        if (start.X >= i)
                        {
                            end.X = start.X - i;
                        }
                        else
                        {
                            end.X = start.X + i;
                        }
                    }
                    while (!bot.Setter(start, end))
                    {
                        up = random.Next(2) == 0;
                        start = new Point(random.Next(10), random.Next(10));
                        end = new Point();
                        if (up)
                        {
                            end.X = start.X;
                            if (start.Y >= i)
                            {
                                end.Y = start.Y - i;
                            }
                            else
                            {
                                end.Y = start.Y + i;
                            }
                        }
                        else
                        {
                            end.Y = start.Y;
                            if (start.X >= i)
                            {
                                end.X = start.X - i;
                            }
                            else
                            {
                                end.X = start.X + i;
                            }
                        }
                    }
                }
            }
            if (!einBoolean)
            {
                Point d = new Point(random.Next(0, 400), random.Next(0, 400));
                double a = d.Y / 40;
                double b = d.X / 40;
                int i = (int)Math.Ceiling(a);
                int j = (int)Math.Ceiling(b);
                d.X = i;
                d.Y = j;
                while (gridL.Squares[i, j].state != State.None)
                {
                    d = new Point(random.Next(0, 400), random.Next(0, 400));
                    a = d.Y / 40;
                    b = d.X / 40;
                    i = (int)Math.Ceiling(a);
                    j = (int)Math.Ceiling(b);
                    d.X = i;
                    d.Y = j;
                }
                gridL.Squares = Check(gridL.Squares, d, player);
                einBoolean = true;
                turnspassed += 1;
            }
            gfxR.Clear(BackColor);
            gfxL.Clear(BackColor);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gfxR.FillRectangle(Brushes.White, gridR.Squares[i, j].Hitbox);
                    gfxL.FillRectangle(Brushes.White, gridL.Squares[i, j].Hitbox);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (player.Ships[i].isplaces)
                {
                    player.Ships[i].Draw(gridL, gfxL, Brushes.Gainsboro);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (gridL.Squares[i, j].state == State.Hit)
                    {
                        gfxL.FillRectangle(Brushes.Crimson, gridL.Squares[i, j].Hitbox);
                    }
                    else if (gridL.Squares[i, j].state == State.Miss)
                    {
                        gfxL.FillRectangle(Brushes.DeepSkyBlue, gridL.Squares[i, j].Hitbox);
                    }
                    if (gridR.Squares[i, j].state == State.Hit)
                    {
                        gfxR.FillRectangle(Brushes.Crimson, gridR.Squares[i, j].Hitbox);
                    }
                    else if (gridR.Squares[i, j].state == State.Miss)
                    {
                        gfxR.FillRectangle(Brushes.DeepSkyBlue, gridR.Squares[i, j].Hitbox);
                    }
                }
            }
            pictureBox1.Image = bmpR;
            pictureBox2.Image = bmpL;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (turnspassed == 0)
            {
                if (player.vzcxv == false)
                {
                    double temp = e.Location.X / 40;
                    double temp1 = e.Location.Y / 40;
                    int X = (int)Math.Ceiling(temp);
                    int Y = (int)Math.Ceiling(temp1);
                    player.Point = new Point(Y, X);
                    player.vzcxv = true;
                }
                else
                {
                    double temp = e.Location.X / 40;
                    double temp1 = e.Location.Y / 40;
                    int X = (int)Math.Ceiling(temp);
                    int Y = (int)Math.Ceiling(temp1);
                    player.Setter(player.Point, new Point(Y, X));
                    player.vzcxv = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmpR = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfxR = Graphics.FromImage(bmpR);
            gridR = new Grid();
            bmpL = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            gfxL = Graphics.FromImage(bmpL);
            gridL = new Grid();
            player = new Player();
            bot = new Player();
            b = 0;
            p = 0;
            for (int i = 0; i < 5; i++)
            {
                bool up = random.Next(2) == 0;
                Point start = new Point(random.Next(10), random.Next(10));
                Point end = new Point();
                if (up)
                {
                    end.X = start.X;
                    if (start.Y >= i)
                    {
                        end.Y = start.Y - i;
                    }
                    else
                    {
                        end.Y = start.Y + i;
                    }
                }
                else
                {
                    end.Y = start.Y;
                    if (start.X >= i)
                    {
                        end.X = start.X - i;
                    }
                    else
                    {
                        end.X = start.X + i;
                    }
                }
                while (!bot.Setter(start, end))
                {
                    up = random.Next(2) == 0;
                    start = new Point(random.Next(10), random.Next(10));
                    end = new Point();
                    if (up)
                    {
                        end.X = start.X;
                        if (start.Y >= i)
                        {
                            end.Y = start.Y - i;
                        }
                        else
                        {
                            end.Y = start.Y + i;
                        }
                    }
                    else
                    {
                        end.Y = start.Y;
                        if (start.X >= i)
                        {
                            end.X = start.X - i;
                        }
                        else
                        {
                            end.X = start.X + i;
                        }
                    }
                }
            }
        }
    }
}
