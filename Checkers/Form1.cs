using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Checkers : Form
    {
        public Game game;
        public newGame newgame;
        private String cmdEntry;
        public void youLose(){

            LoseForm lose = new LoseForm();
            lose.ShowDialog();
        
        }
        public void youWin()
        {

            WinForm win = new WinForm();
            win.ShowDialog();

        }

        
        //private bool jumpsAvailable;
        private void handleButtonPress(int ButtonID){

            //Check status of space
            LinkedList<String> moves = null;
            Debug.WriteLine("Button "+ButtonID+"Pressed");
            int space = 0;
          

            space = game.board[ButtonID];
            //Debug.WriteLine("Space: " + space + " ");
            moves = game.listAvailableMoves();
            
            if (space < 0) { 
                //Friendly Space
                //Debug.WriteLine("Black peice Selected!");
                
                //Debug.WriteLine("Moves"+moves == null);
                //Debug.WriteLine("First:"+moves.First);
                //Debug.WriteLine("Board State:");
                //foreach (int spot in game.board)
                //{
                //    Debug.WriteLine("" + spot + " ");
                //}
                
                foreach(String move in moves){
                    //Debug.WriteLine("Move:");
                    //Debug.WriteLine(move);

                    if(move.Contains("" + ButtonID)){
                        cmdEntry = "" + ButtonID;
                        //Debug.WriteLine("cmdEntry: " + cmdEntry);
                        Debug.WriteLine("here!!!3");
                        return;
                    }
                }
            
            }
            if (space > 0) {
                //Opponant space
            }
            if (space == 0) { 
            //SPace is empty
                
                if (cmdEntry.Length > 0) {
                    Debug.WriteLine("emptySpace clicked!");
                    foreach (String move in moves) {
                        //Debug.WriteLine("MOVE1:"+move);
                        if(move == (cmdEntry +"x"+ButtonID)){
                            //Debug.WriteLine(cmdEntry +"x"+ButtonID);
                            cmdEntry += "x" + ButtonID;
                            richTextBox1.Text = "Red to Move";
                            richTextBox1.ForeColor = Color.Black;
                            richTextBox1.Update();
                            richTextBox1.Refresh();

                            game.run1(cmdEntry);
                            if(game.listAvailableMoves().Count <1){
                                Debug.WriteLine("You Lose!!!");
                                richTextBox1.Text = "You Lose!!!";
                                youLose();
                                return;
                            }


                            richTextBox1.Text = "Black to Move";
                            richTextBox1.ForeColor = Color.Black;
                            //game.run1("c");
                            cmdEntry = "";
                            //Debug.WriteLine("cmdEntry: " + cmdEntry);
                            Debug.WriteLine("here!!!2");
                            return;
                        }
                        if(move == cmdEntry+"-"+ButtonID){
                            //Debug.WriteLine("emptySpace clicked!");
                            cmdEntry += "-" + ButtonID;
                            richTextBox1.Text = "Red to Move";
                            richTextBox1.ForeColor = Color.Black;
                            richTextBox1.Update();
                            richTextBox1.Refresh();
                            game.run1(cmdEntry);
                            richTextBox1.Text = "Black to Move";
                            richTextBox1.ForeColor = Color.Black;
                            if (game.listAvailableMoves().Count < 1)
                            {
                                Debug.WriteLine("You Lose!!!");
                                richTextBox1.Text = "You Lose!!!!";
                                youLose();
                                return;
                            }
                           

                            //Debug.WriteLine("calling game run with c");
                            //game.run1("c");
                            cmdEntry = "";
                            //Debug.WriteLine("cmdEntry: " + cmdEntry);
  
                            return;
                        }
                        if (move.Contains("x"))
                        {
                            //print "You have jumps available, you must jump, \nEnter 'h' for a list of allowed \n moves."
                            //raw_input("Press Enter to continue...")
                            //richTextBox1.Text  = "<font color=\"red\">You have jumps you must take!!!</font>";

                            //return;

                        }
                        if(move.Contains(cmdEntry +"x"+ButtonID)){
                            cmdEntry += "x" + ButtonID;

                            //Debug.WriteLine("cmdEntry: " + cmdEntry);
                            Debug.WriteLine("here!!!");
                            return;
                        }else{
                            if(move.Contains(cmdEntry +"-"+ButtonID)){
                                cmdEntry += "-" + ButtonID;
                                //Debug.WriteLine("cmdEntry: " + cmdEntry);
                                
                                return;                        
                            }
                           

                        }
                    }
                    
             
                }
                if (moves.First().Contains("x"))
                {
                    richTextBox1.Text = "You Have Jumps Available!!!";
                    richTextBox1.ForeColor = Color.Red;
                    richTextBox1.Update();
                    richTextBox1.Refresh();  
                    return;
                }
               


            
            }



        
        
        }

        public Button[] buttons;
        public RichTextBox statusBar;

        public Checkers()
        {
            InitializeComponent();
            //jumpsAvailable = false;
            buttons = new Button[]{null,button1,button2,button3,button4,button5,button6,button7,
                                    button8,button9,button10, button11,button12,button13,
                                    button14,button15,button16,button17,button18,button19,button20,
                                     button21,button22,button23,button24,button25,button26,
                                    button27,button28,button29,button30,button31,button32};

            statusBar = richTextBox1;
            game = new Game(this);
            game.newGame(3);
            
            cmdEntry = "";
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            newGame();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            handleButtonPress(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            handleButtonPress(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            handleButtonPress(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            handleButtonPress(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            handleButtonPress(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            handleButtonPress(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            handleButtonPress(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            handleButtonPress(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            handleButtonPress(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            handleButtonPress(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            handleButtonPress(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            handleButtonPress(12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            handleButtonPress(13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            handleButtonPress(14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            handleButtonPress(15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            handleButtonPress(16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            handleButtonPress(17);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            handleButtonPress(18);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            handleButtonPress(19);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            handleButtonPress(20);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            handleButtonPress(21);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            handleButtonPress(22);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            handleButtonPress(23);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            handleButtonPress(24);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            handleButtonPress(25);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            handleButtonPress(26);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            handleButtonPress(27);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            handleButtonPress(28);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            handleButtonPress(29);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            handleButtonPress(30);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            handleButtonPress(31);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            handleButtonPress(32);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }
        public void newGame() {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            newgame = new newGame(game);
            newgame.ShowDialog();
            //Application.Run(newgame);
            //game.newGame();
        
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            String filename = time.Year.ToString() + "_" + time.Month.ToString() + "_" + time.TimeOfDay.ToString() + ".sav";
            filename = filename.Replace(":", "_");
            game.saveGame(filename);
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.sav)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            System.IO.Stream fileStream = openFileDialog1.OpenFile();
            game.loadGame(fileStream);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
