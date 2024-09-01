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
        ship ship;
        player bot;
        player player;
        public BattleshipGame()
        {
            InitializeComponent();
        }

        private void BattlshipGame_Load(object sender, EventArgs e)
        {
            bmpR = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfxR = Graphics.FromImage(bmpR);
            gridR = new Grid();
            bmpL = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            gfxL = Graphics.FromImage(bmpL);
            gridL = new Grid();
            ship = new ship(4);
            bot = new player();
            ship.body[0] = new Point(1, 1);
            ship.body[1] = new Point(2, 1);
            ship.body[2] = new Point(3, 1);
            ship.body[3] = new Point(4, 1);
            bot.ships[4].body[0] = new Point(1, 2);
            bot.ships[4].body[1] = new Point(1, 3);
            bot.ships[4].body[2] = new Point(1, 4);
            bot.ships[4].body[3] = new Point(1, 5);
            bot.ships[4].body[4] = new Point(1, 6);
            bot.ships[3].body[0] = new Point(2, 8);
            bot.ships[3].body[1] = new Point(3, 8);
            bot.ships[3].body[2] = new Point(4, 8);
            bot.ships[3].body[3] = new Point(5, 8);
            bot.ships[2].body[0] = new Point(6, 3);
            bot.ships[2].body[1] = new Point(6, 2);
            bot.ships[2].body[2] = new Point(6, 1);
            bot.ships[1].body[0] = new Point(7, 6);
            bot.ships[1].body[1] = new Point(6, 6);
            bot.ships[1].body[2] = new Point(5, 6);
            bot.ships[0].body[0] = new Point(8, 2);
            bot.ships[0].body[1] = new Point(8, 3);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                for(int  j = 0; j < 10; j++)
                {
                    if(gridR.Squares[i, j].Hitbox.Contains(e.Location))
                    {
                        for(int k = 0; k < 5;k++)
                        {
                            for (int l = 0; l < bot.ships[k].size; l++)
                            {
                                if (bot.ships[k].body[l] == new Point(i, j))
                                {
                                    gridR.Squares[i, j].state = State.Hit;
                                    return;
                                }
                            }
                        }
                        gridR.Squares[i, j].state = State.Miss;
                    }
                }
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (gridL.Squares[i, j].Hitbox.Contains(e.Location))
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            if (ship.body[k] == new Point(i, j))
                            {
                                gridL.Squares[i, j].state = State.Hit;
                                return;
                            }
                        }
                        gridL.Squares[i, j].state = State.Miss;
                    }
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
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
            gfxL.FillRectangle(Brushes.Gainsboro, gridL.Squares[ship.body[0].X, ship.body[0].Y].Hitbox);
            gfxL.FillRectangle(Brushes.Gainsboro, gridL.Squares[ship.body[1].X, ship.body[1].Y].Hitbox);
            gfxL.FillRectangle(Brushes.Gainsboro, gridL.Squares[ship.body[2].X, ship.body[2].Y].Hitbox);
            gfxL.FillRectangle(Brushes.Gainsboro, gridL.Squares[ship.body[3].X, ship.body[3].Y].Hitbox);
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
    }
}
