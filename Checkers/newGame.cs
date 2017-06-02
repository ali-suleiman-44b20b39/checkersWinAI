using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class newGame : Form
    {

        public Game game;
        Dictionary<int, Image> DifficultyImages;
        public newGame(Game gm)
        {

            InitializeComponent();
            game = gm;
            DifficultyImages = new Dictionary<int, Image>();

            DifficultyImages.Add(1, Image.FromFile("diff1.png"));
            DifficultyImages.Add(2, Image.FromFile("diff2.png"));
            DifficultyImages.Add(3, Image.FromFile("diff3.png"));
            DifficultyImages.Add(4, Image.FromFile("diff4.png"));




        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //boardUI.buttons[count].BackgroundImage = Sprite[board[count]];
            //boardUI.buttons[count].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //boardUI.buttons[count].Update();
            //boardUI.buttons[count].Refresh();
            if (radioButton5.Checked)
            {
                difficulty = 4;
                pictureBox1.Image = DifficultyImages[difficulty];
                pictureBox1.Update();
                pictureBox1.Refresh();
            }





        }

        private int difficulty=1;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked) difficulty = 1;
            pictureBox1.Image = DifficultyImages[difficulty];
            pictureBox1.Update();
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.newGame(difficulty);
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) difficulty = 2;
            pictureBox1.Image = DifficultyImages[difficulty];
            pictureBox1.Update();
            pictureBox1.Refresh();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) difficulty = 3;
            pictureBox1.Image = DifficultyImages[difficulty];
            pictureBox1.Update();
            pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void newGame_Load(object sender, EventArgs e)
        {

        }
    }
}
