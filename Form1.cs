using System; 
using System.Windows.Forms;

namespace _2048_new
{
    public partial class Form1 : Form
    {
        public int[,] gameArrayLogic = new int[4, 4];

        public Form1()
        {
            InitializeComponent();

            //init game array logic
            init();
        }

        private void init()
        {
            //init game array logic

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gameArrayLogic[i, j] = 0;
                }
            }

            addCustommValue();

            updateView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveLeft();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moveDown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveUp();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveRight();
        }

        private void moveLeft()
        {
            //move left
            Boolean addNew = false;
            for (int i = 0; i < 4; i++)
            {
                bool lineClear = true;
                for (int j = 0; j < 4; j++)
                {
                    if (gameArrayLogic[i, j] != 0)
                    {
                        int x = i, y = j;
                        while ((y - 1 >= 0) && gameArrayLogic[x, y - 1] == 0)
                        {
                            y--;
                        }

                        if (lineClear)
                            while ((y - 1 >= 0) && gameArrayLogic[x, y - 1] == gameArrayLogic[i, j])
                            {
                                y--;
                                gameArrayLogic[i, j] = gameArrayLogic[i, j] * 2;
                                lineClear = false;
                                break;
                            }

                        if (y != j)
                        {
                            gameArrayLogic[x, y] = gameArrayLogic[i, j];
                            gameArrayLogic[i, j] = 0;
                            addNew = true;
                        }
                    }
                }
            }

            //update game
            if (addNew) addCustommValue();
            updateView();
            ifGameOver();
        }

        private void moveDown()
        {
            //move down
            Boolean addNew = false;
            for (int j = 3; j >= 0; j--)
            {
                bool lineClear = true;
                for (int i = 3; i >= 0; i--)
                {
                    if (gameArrayLogic[i, j] != 0)
                    {
                        int x = i, y = j;
                        while ((x + 1 < 4) && gameArrayLogic[x + 1, y] == 0)
                        {
                            x++;
                        }

                        if (lineClear)
                            while ((x + 1 < 4) && gameArrayLogic[x + 1, y] == gameArrayLogic[i, j])
                            {
                                x++;
                                gameArrayLogic[i, j] = gameArrayLogic[i, j] * 2;
                                lineClear = false;
                                break;
                            }

                        if (x != i)
                        {
                            gameArrayLogic[x, y] = gameArrayLogic[i, j];
                            gameArrayLogic[i, j] = 0;
                            addNew = true;
                        }
                    }
                }
            }

            //update game
            if (addNew) addCustommValue();
            updateView();
            ifGameOver();
        }

        private void moveUp()
        {
            //move up
            Boolean addNew = false;
            for (int j = 0; j < 4; j++)
            {
                bool lineClear = true;
                for (int i = 0; i < 4; i++)
                {
                    if (gameArrayLogic[i, j] != 0)
                    {
                        int x = i, y = j;
                        while ((x - 1 >= 0) && gameArrayLogic[x - 1, y] == 0)
                        {
                            x--;
                        }

                        if (lineClear)
                            while ((x - 1 >= 0) && gameArrayLogic[x - 1, y] == gameArrayLogic[i, j])
                            {
                                x--;
                                gameArrayLogic[i, j] = gameArrayLogic[i, j] * 2;
                                lineClear = false;
                                break;
                            }

                        if (x != i)
                        {
                            gameArrayLogic[x, y] = gameArrayLogic[i, j];
                            gameArrayLogic[i, j] = 0;
                            addNew = true;
                        }
                    }
                }
            }

            //update game
            if (addNew) addCustommValue();
            updateView();
            ifGameOver();
        }

        private void moveRight()
        {
            //move right
            Boolean addNew = false;
            for (int i = 0; i < 4; i++)
            {
                bool lineClear = true;
                for (int j = 3; j >= 0; j--)
                {
                    if (gameArrayLogic[i, j] != 0)
                    {
                        int x = i, y = j;
                        while ((y + 1 < 4) && gameArrayLogic[x, y + 1] == 0)
                        {
                            y++;
                        }

                        if (lineClear)
                            while ((y + 1 < 4) && gameArrayLogic[x, y + 1] == gameArrayLogic[i, j])
                            {
                                y++;
                                gameArrayLogic[i, j] = gameArrayLogic[i, j] * 2;
                                lineClear = false;
                                break;
                            }

                        if (y != j)
                        {
                            gameArrayLogic[x, y] = gameArrayLogic[i, j];
                            gameArrayLogic[i, j] = 0;
                            addNew = true;
                        }
                    }
                }
            }

            //update game
            if (addNew) addCustommValue();
            updateView();
            ifGameOver();
        }

        private bool ifGameOver()
        {

            bool gameOver = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameArrayLogic[i, j] == 2048)
                    {
                        DialogResult result1 = MessageBox.Show("You Win in 2048!");

                        if (result1 == DialogResult.OK)
                        {
                            init(); 
                        }
                        return true;
                    }

                    if (gameArrayLogic[i, j] == 0)
                    {
                        gameOver = false;
                    }

                }
            }

            if (gameOver)
            {
                DialogResult result1 = MessageBox.Show("Game Over!");

                if (result1 == DialogResult.OK)
                {
                    init(); 
                }
                return true;
            }

            return false;

        }

        private void addCustommValue() {

            if (ifGameOver()) return;

            Random r = new Random(System.DateTime.Now.Millisecond);
            int x, y;

            do
            {
                x = r.Next(0, 4);
                y = r.Next(0, 4);
            } while (gameArrayLogic[x, y] != 0);


            //decide number
            int tempNumber = r.Next(0, 100);
            int number = tempNumber > 10 ? 2 : 4;

            //set number
            gameArrayLogic[x, y] = number;
        }

        private void updateView()
        {
            label1.Text = Convert.ToString(gameArrayLogic[0, 0]);
            label2.Text = Convert.ToString(gameArrayLogic[0, 1]);
            label3.Text = Convert.ToString(gameArrayLogic[0, 2]);
            label4.Text = Convert.ToString(gameArrayLogic[0, 3]);

            label5.Text = Convert.ToString(gameArrayLogic[1, 0]);
            label6.Text = Convert.ToString(gameArrayLogic[1, 1]);
            label7.Text = Convert.ToString(gameArrayLogic[1, 2]);
            label8.Text = Convert.ToString(gameArrayLogic[1, 3]);

            label9.Text = Convert.ToString(gameArrayLogic[2, 0]);
            label10.Text = Convert.ToString(gameArrayLogic[2, 1]);
            label11.Text = Convert.ToString(gameArrayLogic[2, 2]);
            label12.Text = Convert.ToString(gameArrayLogic[2, 3]);

            label13.Text = Convert.ToString(gameArrayLogic[3, 0]);
            label14.Text = Convert.ToString(gameArrayLogic[3, 1]);
            label15.Text = Convert.ToString(gameArrayLogic[3, 2]);
            label16.Text = Convert.ToString(gameArrayLogic[3, 3]);

            pictureBox1.Image = gameArrayLogic[0, 0] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[0, 0] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[0, 0] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[0, 0] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[0, 0] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[0, 0] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[0, 0] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[0, 0] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[0, 0] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[0, 0] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[0, 0] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[0, 0] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox2.Image = gameArrayLogic[0, 1] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[0, 1] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[0, 1] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[0, 1] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[0, 1] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[0, 1] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[0, 1] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[0, 1] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[0, 1] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[0, 1] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[0, 1] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[0, 1] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox3.Image = gameArrayLogic[0, 2] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[0, 2] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[0, 2] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[0, 2] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[0, 2] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[0, 2] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[0, 2] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[0, 2] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[0, 2] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[0, 2] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[0, 2] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[0, 2] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox4.Image = gameArrayLogic[0, 3] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[0, 3] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[0, 3] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[0, 3] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[0, 3] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[0, 3] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[0, 3] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[0, 3] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[0, 3] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[0, 3] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[0, 3] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[0, 3] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;

            pictureBox5.Image = gameArrayLogic[1, 0] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[1, 0] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[1, 0] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[1, 0] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[1, 0] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[1, 0] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[1, 0] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[1, 0] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[1, 0] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[1, 0] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[1, 0] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[1, 0] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox6.Image = gameArrayLogic[1, 1] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[1, 1] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[1, 1] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[1, 1] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[1, 1] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[1, 1] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[1, 1] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[1, 1] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[1, 1] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[1, 1] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[1, 1] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[1, 1] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox7.Image = gameArrayLogic[1, 2] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[1, 2] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[1, 2] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[1, 2] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[1, 2] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[1, 2] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[1, 2] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[1, 2] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[1, 2] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[1, 2] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[1, 2] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[1, 2] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox8.Image = gameArrayLogic[1, 3] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[1, 3] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[1, 3] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[1, 3] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[1, 3] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[1, 3] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[1, 3] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[1, 3] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[1, 3] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[1, 3] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[1, 3] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[1, 3] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;

            pictureBox9.Image = gameArrayLogic[2, 0] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[2, 0] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[2, 0] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[2, 0] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[2, 0] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[2, 0] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[2, 0] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[2, 0] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[2, 0] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[2, 0] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[2, 0] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[2, 0] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox10.Image = gameArrayLogic[2, 1] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[2, 1] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[2, 1] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[2, 1] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[2, 1] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[2, 1] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[2, 1] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[2, 1] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[2, 1] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[2, 1] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[2, 1] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[2, 1] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox11.Image = gameArrayLogic[2, 2] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[2, 2] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[2, 2] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[2, 2] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[2, 2] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[2, 2] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[2, 2] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[2, 2] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[2, 2] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[2, 2] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[2, 2] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[2, 2] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox12.Image = gameArrayLogic[2, 3] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[2, 3] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[2, 3] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[2, 3] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[2, 3] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[2, 3] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[2, 3] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[2, 3] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[2, 3] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[2, 3] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[2, 3] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[2, 3] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;

            pictureBox13.Image = gameArrayLogic[3, 0] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[3, 0] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[3, 0] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[3, 0] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[3, 0] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[3, 0] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[3, 0] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[3, 0] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[3, 0] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[3, 0] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[3, 0] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[3, 0] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox14.Image = gameArrayLogic[3, 1] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[3, 1] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[3, 1] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[3, 1] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[3, 1] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[3, 1] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[3, 1] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[3, 1] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[3, 1] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[3, 1] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[3, 1] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[3, 1] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox15.Image = gameArrayLogic[3, 2] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[3, 2] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[3, 2] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[3, 2] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[3, 2] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[3, 2] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[3, 2] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[3, 2] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[3, 2] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[3, 2] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[3, 2] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[3, 2] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;
            pictureBox16.Image = gameArrayLogic[3, 3] == 0 ? Properties.Resources.score_0000 : gameArrayLogic[3, 3] == 2 ? Properties.Resources.score_0001 : gameArrayLogic[3, 3] == 4 ? Properties.Resources.score_0002 : gameArrayLogic[3, 3] == 8 ? Properties.Resources.score_0003 : gameArrayLogic[3, 3] == 16 ? Properties.Resources.score_0004 : gameArrayLogic[3, 3] == 32 ? Properties.Resources.score_0005 : gameArrayLogic[3, 3] == 64 ? Properties.Resources.score_0006 : gameArrayLogic[3, 3] == 128 ? Properties.Resources.score_0007 : gameArrayLogic[3, 3] == 256 ? Properties.Resources.score_0008 : gameArrayLogic[3, 3] == 512 ? Properties.Resources.score_0009 : gameArrayLogic[3, 3] == 1024 ? Properties.Resources.score_0010 : gameArrayLogic[3, 3] == 2048 ? Properties.Resources.score_0011 : Properties.Resources.score_0000;

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.A)
            {
                moveLeft();
            }

            if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.W)
            {
                moveUp();
            }

            if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D)
            {
                moveRight();
            }

            if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.S)
            {
                moveDown();
            }
        }
    }
}
