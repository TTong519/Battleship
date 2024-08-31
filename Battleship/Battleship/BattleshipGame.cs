using System.Diagnostics;

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
            ship.body[0] = new Point(1, 1);
            ship.body[1] = new Point(2, 1);
            ship.body[2] = new Point(3, 1);
            ship.body[3] = new Point(4, 1);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {

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
            pictureBox1.Image = bmpR;
            pictureBox2.Image = bmpL;
        }
    }
}
