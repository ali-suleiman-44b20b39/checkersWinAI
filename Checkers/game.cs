using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkers{

    
    public class  Game
    {
        //TODO
        int difficulty;
        public int[] board;
       //"Constants for peices in checkers board"
        int BKing = -2;
        int BMan = -1;
        int WKing = 2;
        int WMan = 1;
        int EmptySquare = 0;
        Dictionary<int,String> peiceType;
        Dictionary<int, Image> Sprite;
        LinkedList<String> jumps;
        //String[] jumps;

        Dictionary<String,String> openingCounterMoves;
        String logfilename;

        private bool openingMv;
        private Checkers boardUI;
        
        public void saveGame(String filename){
            System.IO.StreamWriter file = System.IO.File.AppendText(@".\saved_games\"+filename);
            
            file.Write(difficulty);
            
            for(int i=1; i<33;i++){
                file.Write(","+board[i]);
                
            }
            file.Close();  
        }

        public void loadGame(System.IO.Stream fileStream)
        {
            
           // System.IO.StreamReader file = new System.IO.StreamReader(filename);
            System.IO.StreamReader reader = new System.IO.StreamReader(fileStream);
            String data = reader.ReadLine();

            String[] temp = data.Split(',');
            int i =0;
            difficulty = Int32.Parse(temp[0]);
            
            foreach (string str in temp)
            {
                board[i] = Int32.Parse(str);//int32.parse(str);
                i++;
            }
            board[0] = 0;
            openingMv = false;
            pB();
        }

        public void newGame(int diff)
        {
            this.difficulty = diff;
            DateTime time = DateTime.Now;
            logfilename = time.Year.ToString() + "_" + time.Month.ToString() + "_" + time.TimeOfDay.ToString() + ".log";
            logfilename = logfilename.Replace(":", "_");
            Debug.WriteLine(logfilename);
            openingMv = true;
            log("Difficulty: "+diff);
            
            jumps = new LinkedList<String>();
            board = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            openingCounterMoves = new Dictionary<String, String>();
            openingCounterMoves.Add("22-18", "10-14");
            openingCounterMoves.Add("24-19", "11-15");
            openingCounterMoves.Add("22-17", "11-15");
            openingCounterMoves.Add("23-18", "12-16");
            openingCounterMoves.Add("23-19", "9-14");
            openingCounterMoves.Add("21-17", "9-13");
            openingCounterMoves.Add("24-20", "11-15");
            peiceType = new Dictionary<int, string>();
            peiceType.Add(BKing, "Black King");
            peiceType.Add(WKing, "White King");
            peiceType.Add(WMan, "White");
            peiceType.Add(BMan, "Black");
            peiceType.Add(EmptySquare, "");
            Sprite = new Dictionary<int, Image>();
            Sprite.Add(BKing, Image.FromFile("blackKing.png"));
            Sprite.Add(WKing, Image.FromFile("whiteKing.png"));
            Sprite.Add(WMan, Image.FromFile("whiteMan.png"));
            Sprite.Add(BMan, Image.FromFile("blackMan.png"));
            Sprite.Add(EmptySquare, null);

            pB();
        }

        
        
        public Game(Checkers checkers){
            boardUI = checkers;
            //checkers.newGame();

        }

    private void pB(int[] b){
    Thread.Sleep(1000);
	int count = 0;
	//t1 = template
	    for(count =1;count<33;count++){
            boardUI.buttons[count].BackgroundImage = Sprite[b[count]];
            boardUI.buttons[count].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            boardUI.buttons[count].Update();
            boardUI.buttons[count].Refresh();
            //boardUI.buttons[count].Text = peiceType[b[count]];
        }
    }
    public void pB()
    {
        Thread.Sleep(1000);
        int count = 0;
        //t1 = template
        for (count = 1; count < 33; count++)
        {
            boardUI.buttons[count].BackgroundImage = Sprite[board[count]];
            boardUI.buttons[count].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            boardUI.buttons[count].Update();
            boardUI.buttons[count].Refresh();
           // boardUI.buttons[count].Text = peiceType[board[count]];
        }
    }
        
        private bool isOddRow(int pos){
	        return (((pos-1)/4)%2) == 1;
        }

        private bool isEvenRow(int pos){
            return (((pos - 1) / 4) % 2) == 0;
        }

        //'''
        //Board Boundary functions, return a true or false
        //'''
        private bool isLeftEnd(int pos){
            return pos % 4 == 1;
        }

        private bool isRightEnd(int pos){
            return pos % 4 == 0;
        }

        private bool isOnBottomRow(int pos){
            return pos > 28;
        }

        private bool isOnTopRow(int pos){
            return pos < 5;
        }



        
    /*
    '''
    Directional functions, return the value of the square in the given direction.
    If that direction is not available returns -1
    '''
    */

    private int downLeft(int pos){
	    if (isLeftEnd(pos) && isOddRow(pos) || isOnBottomRow(pos)){
		    return -1;
	    }
	    if(isEvenRow(pos)){
		    return pos + 4;
	    }
	    if(isOddRow(pos)){
		    return pos + 3;
	    }
	    else{
		    //Debug.WriteLine("Unhandled Case!!");
            return -1;
	    }
    }

    private int downRight(int pos){
	    if (isRightEnd(pos) && isEvenRow(pos) || isOnBottomRow(pos)){
		    return -1;
	    }
	    if(isEvenRow(pos)){
		    return pos + 5;
	    }
	    if (isOddRow(pos)){
		    return pos + 4;
	    }else{
            //Debug.WriteLine("downRight, Unhandled case!!!");
            return -2;
        }

    }

    private int upLeft(int pos){
	    if (isLeftEnd(pos) && isOddRow(pos) || isOnTopRow(pos)){
		    return -1;
	    }
	    if (isEvenRow(pos)){
		    return pos - 4;
	    }
	    if (isOddRow(pos)){
		    return pos - 5;
	    }else{
            //Debug.WriteLine("upLeft, Unhandled case!!!");
            return -2;
        }
    }

    private int upRight(int pos){
	    if (isRightEnd(pos) && isEvenRow(pos) || isOnTopRow(pos)){
		    return -1;
	    }
	    if (isEvenRow(pos)){
		    return pos - 3;
	    }
	    if (isOddRow(pos)){
		    return pos - 4;
	    }else{
            //Debug.WriteLine("upRight, Unhandled case!!!");
            return -2;
        }
    }

    /*
    '''
    Jump functions, return the pos of the landing square, if 
	    1. Landing square is vacant
	    2. && Opponent peice is in immediate square of given direction
	    Returns NOP if destination is not available, checks for board 
	    boundaries.
	    Odd and even rows are handled by the direction functions
    '''
    */

    private int jumpUpRight(int pos,int[] b1){
	    int target = upRight(pos);
	    if (target ==-1){
		    return -1;
	    }
	    int des = upRight(upRight(pos));
	    //## print "des:" + str(des)
	    //## print "target:" + str(target)
	    if( des == -1){
		    return -1;
	    }
	    if(b1[des] == 0 && 
            (((b1[target] == -1 || b1[target] == -2) && 
            b1[pos]>0) || ((b1[target] == 1 || b1[target] == 2) && b1[pos]<0))){
		    return des;
	    }
	    else{
		    return -1;
	    }
    }

    private int jumpUpLeft(int pos,int[] b1){
	    int target = upLeft(pos);
	    if(target ==-1){
		    return -1;
	    }
        int des = upLeft(upLeft(pos)); // This isnt safe passing NOP && triggering an error
	    //## print "des:" + str(des)
	    //## print "target:" + str(target)
	    if(des == -1){
		    return -1;
	    }
	    if(b1[des] == 0 && (((b1[target] == -1 || b1[target] == -2) && b1[pos]>0) || ((b1[target] == 1 || b1[target] == 2) && b1[pos]<0) )){
		    return des;
	    }
	    else{
		    return -1;
	    }
    }

    private int jumpDownRight(int pos, int[] b1){
	    int target = downRight(pos);
	    if (target ==-1){
		    return -1	;
	    }
        int des = downRight(downRight(pos));
	    if (des == -1){
		    return -1;
	    }
	    if(b1[des] == 0 && (((b1[target] == -1 || b1[target] == -2) && b1[pos]>0) || ((b1[target] == 1 || b1[target] == 2) && b1[pos]<0) )){
		    return des;
	    }
	    else{
		    return -1	;
	    }
    }

    private int jumpDownLeft(int pos, int[] b1){
	    int target = downLeft(pos);
	    if (target ==-1){
		    return -1;
	    }
        int des = downLeft(downLeft(pos));
	    if(des == -1){
		    return -1;
	    }
	    if(b1[des] == 0 && (
            ((b1[target] == -1 || b1[target] == -2) 
            && b1[pos]>0) || ((b1[target] == 1 || b1[target] == 2) && b1[pos]<0) )){
		    return des;
	    }
	    else{
		    return -1;
	    }
    }

    /*'''
    Check for Jumps Functions
    '''*/
    delegate int DirectionFunc(int a,int[] b);
    delegate int DirectionFuncSingle(int a);
        
    private LinkedList<String> checkForJumps(int[] board_, int pos){
	    //int[] jumps = new int[] {1, 2, 3, 4, 5};
        //return null;
        jumps.Clear();
	    int[] b1; 
        b1 = (int[])board_.Clone();
        DirectionFunc[] directions = null;
        
	    int square = b1[pos];
	    if ((square == BKing) || (square == WKing)){
            ////Debug.WriteLine("0x01");
		    directions = new DirectionFunc[]{new DirectionFunc(jumpDownLeft),new DirectionFunc(jumpDownRight),new DirectionFunc(jumpUpLeft),new DirectionFunc(jumpUpRight)};
	    }
	    if (square == WMan){
            ////Debug.WriteLine("0x02");
		    directions = new DirectionFunc[]{new DirectionFunc(jumpDownLeft),new DirectionFunc(jumpDownRight)};
	    }
	    if (square == BMan){
            ////Debug.WriteLine("0x03");
		    directions = new DirectionFunc[]{new DirectionFunc(jumpUpLeft),new DirectionFunc(jumpUpRight)};
	    }
        ////Debug.WriteLine("Calling Check for jumps...");
        LinkedList<string> result = checkForJumpsHelper(directions,b1,pos,""+pos);
	    //if(result != null){
            //jumps = result;
        //}
        
	    //#print jumps
        if (jumps.Count == 0)
        {
            return null;
        }
	    return jumps ;
    }

    
    /*'''
    Check for jumps Helper function
    '''*/
    private LinkedList<String> checkForJumpsHelper(DirectionFunc[] directions,int[] b1,int pos,String path){
	    //global jumps;
	    //#b1 = board;
	    //##print "pos is:" +str(pos)
	    //#printBoard(b1)

        bool jumpAvailableFlag = false;
        if (directions == null)
        {
            ////Debug.WriteLine("***Check for jumps Warning Directions == null!!");
            return null;
        }
        ////Debug.WriteLine("checkforjumps Foreach...");
	    foreach (DirectionFunc direction in directions){
            ////Debug.WriteLine("checkforjumps Foreach...+");
		    if(direction(pos,b1) != -1){
                
			    int nextpos = direction(pos,b1);
			    b1[nextpos]=b1[pos];
			    checkForJumpsHelper(directions,b1,nextpos, path+"x"+nextpos);
			    b1[nextpos] = 0;
			    jumpAvailableFlag = true;
			    //#paths.append(path);
		    }
	    }
	    if (!jumpAvailableFlag){
		    if (path.Contains("x")){
                ////Debug.WriteLine("jump found!!!!!!!!!!!"+path);
                //#print path
                if (jumps == null)
                {
                    jumps = new LinkedList<String>();
                    jumps.AddLast(path);
                }
                jumps.AddLast(path);
			    //#print jumps
			    return jumps;
		    }
	    }
        return null;
    }



    private LinkedList<String>  checkForSlidesHelper(DirectionFuncSingle[] directions,int[] board,int pos){
	    LinkedList<String> slides = new LinkedList<String>();

        ////Debug.WriteLine("Checking for slides helper");
        foreach(DirectionFuncSingle direction in directions){
            ////Debug.WriteLine("Foreach Checking for slides helper");
		    if(direction(pos) != -1){
               // //Debug.WriteLine(".Checking for slides helper");
			    if( board[direction(pos)] == 0){
                   // //Debug.WriteLine("..Checking for slides helper");
				    //#print str(pos) + "-" + str(direction(pos))
				    slides.AddLast(""+pos+"-"+direction(pos));
                    //slides.append(str(pos) + "-" + str(direction(pos)));                     
			    }
		    }
	    }

	    return slides;
    }

    

    private LinkedList<String> checkForSlides(int[] board,int pos){
        ////Debug.WriteLine("CheckForSlides Called");
	    int square = board[pos];
	    DirectionFuncSingle[] directions = null;
	    if (square == BKing || square == WKing){
		    //directions = new DirectionFuncSingle[]{jumpDownLeft,jumpDownRight,jumpUpLeft,jumpUpRight};
            directions = new DirectionFuncSingle[]{downLeft, downRight, upLeft, upRight};
	    }
	    if (square == WMan){
		    directions = new DirectionFuncSingle[]{downLeft, downRight};
	    }
	    if (square == BMan){
		    directions = new DirectionFuncSingle[]{upLeft, upRight};
	    }
	    return checkForSlidesHelper(directions,board,pos);
    }

    public LinkedList<String> listAvailableMoves() {
        //Debug.WriteLine("0.a ListMoves...");
        int player =-1;
        return listAvailableMoves(board, player);
    
    }

    public LinkedList<String> listAvailableMovesForWhite()
    {
        //Debug.WriteLine("0.a ListMoves...");
        int player = 1;
        return listAvailableMoves(board, player);

    }


    private LinkedList<String> listAvailableMoves(int[] board, int player){
	    //moves = [];
        ////Debug.WriteLine("0.b ListMoves...");
        LinkedList<String> moves = new LinkedList<String>();
	    bool jumpsFlag = false;
	    if (player > 0){
            ////Debug.WriteLine("1.");
            for(int place = 0;place<33;place++){
                
              //  //Debug.WriteLine("0.d ListMoves...");
			    if(board[place] > 0){
                    ////Debug.WriteLine("Jumps False comp move");
				    if (checkForJumps(board,place) != null){
					    jumpsFlag = true;
                //        //Debug.WriteLine("1. ListMoves Checking for jumps...");
                        ////Debug.WriteLine("****checkjumps");
                        conCat(moves, checkForJumps(board, place));
					    //moves = (LinkedList<String>)moves.Concat(checkForJumps(board,place));
				    }
			    }
		    }
            ////Debug.WriteLine("0.e ListMoves...");
		    if(jumpsFlag == false){
                
                ////Debug.WriteLine("Jumps False comp move");
			    for(int place = 0;place<33;place++){
                    if (checkForJumps(board, place) == null)
                    {
                        if (board[place] > 0)
                        {
                 //           //Debug.WriteLine("2. ListMoves Checking for jumps...");
                            ////Debug.WriteLine("****checkslides");
                            conCat(moves, checkForSlides(board, place));
                            //moves = (LinkedList<String>)moves.Concat(checkForSlides(board, place));
                        }
                    }
			    }
            }
	    }
	    if(player < 0){
            ////Debug.WriteLine("0.f ListMoves...");
		    for(int place = 0;place<33;place++){
                ////Debug.WriteLine("0.f ListMoves...Forloop");
			    if(board[place] < 0){
                  //  //Debug.WriteLine("0.f ListMoves...if1");
				    if(checkForJumps(board,place) != null){
                    //    //Debug.WriteLine("0.f ListMoves...if2");
					    jumpsFlag = true;
                      //  //Debug.WriteLine("3. ListMoves Checking for jumps...");
                        conCat(moves, checkForJumps(board, place));
					    //moves = (LinkedList<String>)moves.Concat(checkForJumps(board,place));
				    }
			    }

		    }
		    if(jumpsFlag == false){
                ////Debug.WriteLine("0.g ListMoves...");
                for(int place = 0;place<33;place++){
                  //  //Debug.WriteLine("0.gForloop...");
                    ////Debug.WriteLine("0.g Checkforjumps:" + checkForJumps(board, place));
                    if(checkForJumps(board,place) == null){
                      //  //Debug.WriteLine("0.g Checkforjumps is null");
				        if(board[place] < 0){
                        //    //Debug.WriteLine("4. ListMoves Checking for jumps...");
                            conCat(moves, checkForSlides(board, place));
					        //moves = (LinkedList<String>)moves.Concat(checkForSlides(board,place));
				        }
                    }
			    }
		    }
        }
        ////Debug.WriteLine("ListMoves... Returning");
	    return moves;
}
    

    private void conCat(LinkedList<String> l1, LinkedList<String> l2){
        foreach(String str in l2){
            l1.AddLast(str);
        }
    }

    private LinkedList<String> listAvailableMoves1(int[] board, int player){
        LinkedList<String> moves = new LinkedList<String>();
	    bool jumpsFlag = false;
	    if(player > 0){
		    for(int place =0;place<33;place++){
			    if (board[place] > 0){
				    if (checkForJumps(board,place) != null){
					    jumpsFlag = true;
				    }
				    if (jumpsFlag == false){
                        conCat(moves, checkForSlides(board, place)); 
                        //moves = (LinkedList<String>)moves.Concat(checkForSlides(board,place));
				    }
				    else{
                        conCat(moves, checkForJumps(board, place));
                        //moves = (LinkedList<String>)moves.Concat(checkForJumps(board,place));
				    }
		        }
	        }
        }
	    if (player < 0){
            for(int place=0;place<33;place++){
			    if (board[place] < 0){
				    if (checkForJumps(board,place) != null){
					    jumpsFlag = true;
                    }
                    if(jumpsFlag == false){
                        conCat(moves, checkForSlides(board, place));
					   // moves = (LinkedList<String>)moves.Concat(checkForSlides(board,place));

				    }
				    else{
                        conCat(moves, checkForJumps(board, place));
					    //moves = (LinkedList<String>)moves.Concat(checkForJumps(board,place));
				    }
			    }
		    }
	    }
	    return moves;
    }

    //TODO Are these heaps?
    private Tuple<String,int> min(Tuple<String,int> a, Tuple<String,int> b){
	    if(a.Item2>b.Item2){
		    return b;
	    }
	    else{
		    return a;
	    }
    }

    //TODO0
    private Tuple<String,int> max(Tuple<String,int> a,Tuple<String,int>  b){
	    if(a.Item2>b.Item2){
		    return a;
	    }
	    else{
		    return b;
	    }
    }


/*    '''
    move a peice from one location of the board to another
    This 
 * 
 * tion should never be called from main.
    '''*/
    private void move(int position,int to,int[] board){
	    int peice = board[position];
	    board[position] = 0;
	    board [to] = peice;
        board.Sum();
	    //sum(board);
	    //printBoard(board);
    }

    /*'''
    Performs the move
    With out pausing between jumps, uses for searching
    '''*/
    private void performMove(String mv,int[] board){
        ////Debug.WriteLine("Move:"+mv);
	    if(mv.Contains("-")){
            String[] result = null;
            result = mv.Split('-');
            String pos,des;
		    pos= result[0];
            des = result[1]; 
		    int a =  Int32.Parse(pos);
		    int b =  Int32.Parse(des);
            ////Debug.WriteLine("moving-...");
		    move(a,b,board);
	    }
	    if (mv.Contains("x")){
		    String[] mvlist = mv.Split('x');
		    //#print mvlist

		    String pos = mvlist[0];
            for(int i = 0;i<mvlist.Length-1;i++){//ams
			    int a = Int32.Parse(mvlist[i]);
			    int b = Int32.Parse(mvlist[i+1]);
			    int delta = a - b;
			    if (delta == 9){
				    board[upLeft(a)] = 0;
			    }
			    if (delta == 7){
				    //#upright
				    board[upRight(a)] = 0;
			    }
			    if (delta == -7){
				    //#downleft
				    board[downLeft(a)] = 0;
			    }
			    if (delta == -9){
				    board[downRight(a)] = 0;
			    }
                ////Debug.WriteLine("***moving...");
			    move(a,b,board);
			    //#time.sleep(1)
		    }
	    }
        //Crown the kings?
        for(int space = 1;space<5;space++){
		    if (board[space] == -1){
			    board[space] = -2;
		    }
	    }
        for (int space = 29; space < 33; space++)
        {
            if (board[space] == 1)
            {
                board[space] = 2;
                //#printBoard(board)
                //#time.sleep(1)
            }
        }
    }


    /*        '''
    Performs moves(slides/jumps), and pause between jumps.
    Where mv is a string of either of the following formats:
	    17-22
	    1x6x2
    '''
     */
    private void performMoveReal(String mv, int[] board)
    {
        
        //Debug.WriteLine("PMR, Move:" + mv);
        if (mv.Contains('-'))
        {
            String[] result = null;
            result = mv.Split('-');
            String pos, des;
            pos = result[0];
            des = result[1];
            int a = Int32.Parse(pos);
            int b = Int32.Parse(des);
            move(a, b, board);
            pB(board);
        }
        if (mv.Contains("x"))
        {
            String[] Result = mv.Split('x');
            //#print mvlist
            int pos = Int32.Parse(Result[0]);
            for (int i = 0; i < (Result.Length - 1); i++)
            {
                int a = Int32.Parse(Result[i]);
                int b = Int32.Parse(Result[i + 1]);
                int delta = a - b;
                if (delta == 9)
                    board[upLeft(a)] = 0;
                if (delta == 7)
                    //#upright
                    board[upRight(a)] = 0;
                if (delta == -7)
                    //#downleft
                    board[downLeft(a)] = 0;
                if (delta == -9)
                    board[downRight(a)] = 0;
                move(a, b, board);
                //Thread.Sleep(500);
                pB(board);
                
                //Crown the kings?
                for (int space = 1; space < 5; space++)
                {
                    if (board[space] == -1)
                    {
                        board[space] = -2;
                    }
                }
                for (int space = 29; space < 33; space++)
                {
                    if (board[space] == 1)
                    {
                        board[space] = 2;
                        //#printBoard(board)
                        //#time.sleep(1)
                    }
                }			//#printBoard(board)

                //Thread.Sleep(1);
            }
        }
    }

/*
'''
Minimax helper function is mainly concerned with return a value for a branch
'''*/
//private var moveValPair;

private Tuple<String,int> minimaxHelper(int[] b, int depth, bool maximizingPlayer, String mv){
	performMove(mv,b);
	if(depth == 0){

        for(int i =0; i<33; i++){
            if (b[i] == -2) {
                b[i] = -1;
            }
            if (b[i] == 2)
            {
                b[i] = 1;
            }
        
        }
		int sumval = b.Sum();
		//#printBoard(board);
		return new Tuple<String,int>(mv,sumval);
    }
	if(maximizingPlayer){
		Tuple<String,int> bestValue = new Tuple<String,int>("",-1000);
		LinkedList<String> moves = listAvailableMoves(b,1);

        ////Debug.WriteLine("mHelper List availabe Moves for maxP:");
        //foreach (String move in moves)
        //{
        //    //Debug.WriteLine(move);
        //}
		foreach(String move in moves){
			Tuple<String,int> val = minimaxHelper((int[])b.Clone(), depth - 1, false, move);
			bestValue = max(bestValue, val);
			//#time.sleep(1)
			//#printBoard(board)
			//#time.sleep(1)
        }
		return bestValue;
    }else{
		Tuple<String,int> bestValue = new Tuple<String,int>("",1000);
		LinkedList<String> moves = listAvailableMoves(b,-1);
        //Debug.WriteLine("mHelper List availabe Moves for minP:");
        foreach (String move in moves)
        {
            //Debug.WriteLine(move);
        }
		foreach(String move in moves){
			Tuple<String,int> val = minimaxHelper((int[])b.Clone(), depth - 1, true, move);
			bestValue = min(bestValue, val);
        }
		return bestValue;
    }
}

/*
'''
Wraps the minimax helper, and determines the best move for the AI
'''*/
public Tuple<String,int> minimax(int[] b, int depth, bool maximizingPlayer, String mv){
	performMove(mv,b);
	if(depth == 0){
        for (int i = 0; i < 33; i++)
        {
            if (b[i] == -2)
            {
                b[i] = -1;
            }
            if (b[i] == 2)
            {
                b[i] = 1;
            }

        }
		int sumval = b.Sum();
		//#printBoard(board)
		return new Tuple<String,int>(mv,sumval);
    }
	if(maximizingPlayer){
        ////Debug.WriteLine("CompMoves ");
		Tuple<String,int> bestValue = new Tuple<String,int>("",-1000);
		LinkedList<String> moves = listAvailableMoves(b,1);
        
		//# if len(moves) == 1:
		//# 	return [moves[0],1]
		foreach( String move in moves){
            //Debug.WriteLine("CompMoves " + move);
			Tuple<String,int> val = minimaxHelper((int[])b.Clone(), depth - 1, false, move);
			//val.Item1=move; TODO check this
			//#print mv + " val: " +str(val[1])
            val = new Tuple<String, int>(move, val.Item2);
			bestValue = max(bestValue, val);
            //bestValue.Item1 = move;
            //bestValue = new Tuple<String, int>(move, bestValue.Item2);
        }
		//#	time.sleep(1)
		//#	printBoard(board)
		//#	time.sleep(1)
		return bestValue;
	}else{
		Tuple<String,int> bestValue = new Tuple<String,int>("",1000);
		LinkedList<String> moves = listAvailableMoves(b,-1);
		foreach(String move in moves){
			Tuple<String,int> val = minimaxHelper((int[])b.Clone(), depth - 1, true, move);
            val = new Tuple<String, int>(move, val.Item2); 
			bestValue = min(bestValue, val);
            //bestValue = new Tuple<String, int>(move, bestValue.Item2);
            //Debug.WriteLine("Warning this code should never be reached!!!");
        }
		return bestValue;
    }
   }

/*
'''
Executes a move for the AI
'''*/
///*
private void computerMove(int[] b,int plies){
    //Debug.WriteLine("Computer Move Called!!");
	if (listAvailableMoves(b,1).Count <1){
		Debug.WriteLine("Game Over, You win!");
        boardUI.statusBar.Text = "Game Over, You win!";
        boardUI.youWin();
        boardUI.statusBar.Update();
        boardUI.statusBar.Refresh();
        Thread.Sleep(1000);
    }
    ////Debug.WriteLine("Plies:"+plies);
    ////Debug.WriteLine("Listing Moves before..");
    //foreach (String move in listAvailableMoves(b, 1)) {
    //    //Debug.WriteLine(move);
    //}
    Tuple<String,int> result = minimax(b, plies, true, "0+0");
	String res = result.Item1;

    //Debug.WriteLine("Value:" + result.Item2);

    //Debug.WriteLine("Perform move real called.."+res);
    if (listAvailableMoves(b, 1).Contains(res))
    {
        performMoveReal(res, board);
    }
    else {
        //Debug.WriteLine("Minimax returned illegal move");
    
    }
    
	//#print res
    log("Computer move: " + res);
    pB(board);
}

private void  computerMoveB(int[] b,int plies){
    String res = minimax(b, plies, false, "0+0").Item1;
    performMove(res,b);
    //log("Computer move: "+str(res))
    //#print res
    pB(board);
}
        
//#Setvalue for logfile name
//log_file = str(time.strftime("%Y-%m-%d_t%H_%M") +"log.txt")


       




  public void run1(String cmd){
	//cmd = "";
	//plies = difficulty * 2;
    int plies = difficulty*2;
	//pB(board);
	//while(cmd != "q"){
		//log("User Entry: " + str(cmd))
		//prompt = "\nEnter your next move:"
		if(cmd == "r"){//TODO
            //board = [0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1];
            //difficulty = int(raw_input("Please enter your difficulty level (1-4):"))
            //while (difficulty not in valid_difficulty):
            //    print "That is not a valid difficult, please enter (1,2,3,or 4) \n"
            //    difficulty = int(raw_input("Please enter your difficulty level(1-4):"))
            //plies = difficulty * 2
            //pB(board)
            return;
        }
		if( cmd == "c"){
			computerMoveB(board,plies);
        }
		if( cmd == "p"){
			pB(board);
			return;
        }
		if (cmd == "h"){
            //print "The following moves are available:"
            //for i in listAvailableMoves(board,-1):
            //    print i
            //raw_input("Press Enter to continue...")
            //pB(board)
			return;
        }
		//allowed = listAvailableMoves(board,-1)
        LinkedList<String> allowed = listAvailableMoves(board,-1);
		if(allowed.First().Contains("x")){
			cmd = cmd.Replace(" ","x");
        }
        if(allowed.First().Contains("-")){
			cmd = cmd.Replace(" ","-");
        }

		if( allowed.Contains(cmd)){
            //Debug.WriteLine("Legal Move found, executing..");
			performMove(cmd,board);
            log("Human Move:" + cmd);
			//Thread.Sleep(1000);
			pB(board);
            //Debug.WriteLine("Pausing 1000ms");
            //Thread.Sleep(1000);
        }
		else{
            
            //Debug.WriteLine("Not  a legal move!!");
            //if "x" in allowed[0]:
            //    print "You have jumps available, you must jump, \nEnter 'h' for a list of allowed \n moves."
            //    raw_input("Press Enter to continue...")
            //    pB(board)
            //    return;
            //#time.sleep(1)
			return;
        }
		if(openingMv){
			//print openingCounterMoves[cmd];
            log("Computer Move:" + openingCounterMoves[cmd]);
            performMoveReal(openingCounterMoves[cmd],board);
			//Thread.Sleep(1);
			//pB(board);
			openingMv = false;
        }
		else{
			if(difficulty < 2){
				//Thread.Sleep(1);
            }
			if (listAvailableMoves(board,1) == null){
				//print "You Win!!!"
				//cmd ="r"
				return;
            }
            //Thread.Sleep(1000);
            computerMove(board, plies);
			if (listAvailableMoves(board,1) == null){
				//"Game Over, you lose."
				//cmd = "r"
				return;
            }
        }
    //}
  }

        private void log(String str){
            System.IO.StreamWriter file = System.IO.File.AppendText(@".\logs\"+logfilename);
            file.WriteLine(str);
            file.Close();        
        }

public void run(String cmd){
    //Need to Rewrite this whole function
    int plies = 2;
	//#Launches the set script to set the commandline to the correct width for the program.
	//subprocess.call("setup.bat")
	//cmd = ""
	//global board
	
	//int[] valid_difficulty = {1,2,3,4};
	//int difficulty = 2;//int(raw_input("Please enter your difficulty level (1-4):"))
	//log("Difficulty selected: "+ str(difficulty))

	//while (difficulty not in valid_difficulty):
		//print "That is not a valid difficult, please enter (1,2,3,or 4) \n"
		//difficulty = int(raw_input("Please enter your difficulty level(1-4):"))
	//int plies = difficulty * 2;
	//pB(board)
	//print "Enter your next move(EX: 22 17):"
	//prompt = ""
	if( cmd != "q"){
		//cmd = str(raw_input(prompt))
		//log("User Entry: " + str(cmd))
		//prompt = "\nEnter your next move:"
		if(cmd == "r"){
			board = new int[]{0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
			difficulty = 2;//int(raw_input("Please enter your difficulty level (1-4):"))
			//while (difficulty not in valid_difficulty):
				//print "That is not a valid difficult, please enter (1,2,3,or 4) \n"
				//difficulty = int(raw_input("Please enter your difficulty level(1-4):"))
			//plies = difficulty * 2;
			pB(board);
			return;
        }
        if (openingMv)
        {
            //print openingCounterMoves[cmd];
            performMoveReal(openingCounterMoves[cmd],board);
            //Thread.Sleep(1);
            //Debug.WriteLine("Computer Move openingmove");
            pB(board);
            openingMv = false;
            return;
        }
        if(cmd == "c"){
            //Debug.WriteLine("cmd == c");
            computerMove(board, plies);
			//computerMoveB(board,plies);
        }
		if (cmd == "p"){
			pB(board);
			return;
        }
		if (cmd == "h"){
			//print "The following moves are available:"
			foreach(String i in listAvailableMoves(board,-1)){
				//print i
            }
			//raw_input("Press Enter to continue...")
			//pB(board)
			return;
        }
		LinkedList<String> allowed = listAvailableMoves(board,-1);
		if(allowed.First().Contains("x")){
			cmd = cmd.Replace(" ","x");
        }
		if(allowed.First().Contains("-")){
			cmd = cmd.Replace(" ","-");
        }
		if(allowed.Contains(cmd)){
			performMove(cmd,board);
            log("Human Move:" + cmd);
			//Thread.Sleep(1);
			pB(board);
        }
		else{
			if(allowed.First().Contains("x")){
				//print "You have jumps available, you must jump, \nEnter 'h' for a list of allowed \n moves."
				//raw_input("Press Enter to continue...")
                boardUI.statusBar.Text = "<font color=\"red\">You have jumps you must take!!!</font>";

				pB(board);
				return;
            }
			//#time.sleep(1)
            return;
        }
		if(openingMv){
            //print openingCounterMoves[cmd];
			//performMoveReal(openingCounterMoves[cmd],board);
			//Thread.Sleep(1);
            //Debug.WriteLine("Computer Move openingmove");
			pB(board);
			openingMv = false;
         }
		else{
			//if(difficulty < 2)
				//Thread.Sleep(1000);
			if(listAvailableMoves(board,1) == null){
				//print "You Win!!!"
				cmd ="r";
				//continue;
                return;
            }
			//computerMove(board,plies);
			if(listAvailableMoves(board,1) == null){
				//"Game Over, you lose.";
				cmd = "r";
				//continue
                return;
            }
        }
    }

}
    /*
"""
Logging function, for trouble shooting, and collecting user data
"""
def log(data):
	f = open(log_file, "a+")
	f.write(str(time.strftime("%Y-%m-%d %H:%M")) + " " + data +"\n")
	f.close
        */

        /*
        */



        public void test(){
            ////Debug.WriteLine(""+test[1]);
        
        }

    }
}
