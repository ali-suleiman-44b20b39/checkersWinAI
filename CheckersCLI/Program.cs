using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckersCLI
{
    class Program
    {

        static void assert(int testNumber, string name, int expected, int actual) {

            String result_string = "" + testNumber + "," + name + "," + expected + "," + actual; 
            
            if (expected == actual)
            {
                //pass
                Console.Out.WriteLine(result_string+",Passed");

            }
            else { 
                //fail
                Console.Out.WriteLine(result_string + ",Failed");
            
            }

        
        }

        static void assert(int testNumber, string name, bool expected, bool actual)
        {

            String result_string = "" + testNumber + "," + name + "," + expected + "," + actual;

            if (expected == actual)
            {
                //pass
                Console.Out.WriteLine(result_string + ",Passed");

            }
            else
            {
                //fail
                Console.Out.WriteLine(result_string + ",Failed");

            }


        }



        static void Main(string[] args)
        {
            //Unit Tests
            int testNum = 0;
            assert(testNum++,"isOddRow(2)" ,false ,isOddRow(2)); //False
            assert(testNum++,"isOddRow(6)" ,true ,isOddRow(6)); //True
            assert(testNum++,"isEvenRow(2)" ,true ,isEvenRow(2)); //true
            assert(testNum++,"isEvenRow(6)" ,false ,isEvenRow(6)); //false   
            assert(testNum++,"isLeftEnd(13)" ,true ,isLeftEnd(13)); //true
            assert(testNum++,"isLeftEnd(12)" ,false ,isLeftEnd(12));//false
            assert(testNum++,"isLeftEnd(11)" ,false ,isLeftEnd(11)); //false
            assert(testNum++,"isRightEnd(13)" ,false ,isRightEnd(13)); //false
            assert(testNum++,"isRightEnd(12)" , true ,isRightEnd(12));// true
            assert(testNum++,"isRightEnd(11)" ,false ,isRightEnd(11)); //false
            assert(testNum++,"isOnBottomRow(29)" ,true ,isOnBottomRow(29)); //true
            assert(testNum++,"isOnBottomRow(32)" ,true ,isOnBottomRow(32));//true
            assert(testNum++,"isOnBottomRow(28)" ,false ,isOnBottomRow(28));//false
            assert(testNum++,"isOnTopRow(4)" ,true ,isOnTopRow(4)); //true
            assert(testNum++,"isOnTopRow(1)" ,true ,isOnTopRow(1)); //true
            assert(testNum++,"isOnTopRow(5)" ,false ,isOnTopRow(5)); //false
            assert(testNum++,"downLeft(18)" ,22 ,downLeft(18)); //22
            assert(testNum++,"downLeft(14)" ,17 ,downLeft(14));//17
            assert(testNum++,"downLeft(13)" ,-1 ,downLeft(13));//none
            assert(testNum++,"downRight(3)" ,8 ,downRight(3)); //8
            assert(testNum++,"downRight(8)" ,12 ,downRight(8)); //12
            assert(testNum++,"downRight(12)" ,-1 ,downRight(12)); //none
            assert(testNum++,"upLeft(30)" ,25 ,upLeft(30)); //25
            assert(testNum++,"upLeft(25)" ,21 ,upLeft(25)); //21
            assert(testNum++,"upLeft(21)" ,-1 ,upLeft(21)); //none
            assert(testNum++,"upRight(21)" ,17 ,upRight(21)); //17
            assert(testNum++,"upRight(17)" ,14 ,upRight(17)); //14
            assert(testNum++,"upRight(20)" ,-1 ,upRight(20)); //none
    
            int[] b_test = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            b_test[18] = 2;
            b_test[14] = -1;
            b_test[15] = -1;
            b_test[22] = -1;
            b_test[23] = -1;

            assert(testNum++,"jumpUpRight(18,b_test)", 11 ,jumpUpRight(18,b_test)); //11
            assert(testNum++,"jumpUpLeft(18,b_test)", 9 ,jumpUpLeft(18,b_test)); //9
            assert(testNum++,"jumpDownRight(18, b_test)", 27 ,jumpDownRight(18, b_test)); //27
            assert(testNum++,"jumpDownLeft(18, b_test)", 25 ,jumpDownLeft(18, b_test)); //25

            b_test = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            b_test[17] = 2;
            b_test[13] = -1;
            b_test[14] = -1;
            b_test[21] = -1;
            b_test[22] = -1;

            assert(testNum++,"jumpUpRight(17,b_test)",10,jumpUpRight(17,b_test)); //10
            assert(testNum++,"jumpUpLeft(17,b_test)",-1,jumpUpLeft(17,b_test)); //-1
            assert(testNum++,"jumpDownRight(17, b_test)",26,jumpDownRight(17, b_test)); //26
            assert(testNum++,"jumpDownLeft(17, b_test)",-1,jumpDownLeft(17, b_test)); //-1


            b_test = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            b_test[16] = 2;
            b_test[11] = -1;
            b_test[12] = -1;
            b_test[19] = -1;
            b_test[20] = -1;

            assert(testNum++,"jumpUpRight(16,b_test)",-1,jumpUpRight(16,b_test)); //-1
            assert(testNum++,"jumpUpLeft(16,b_test)",7,jumpUpLeft(16,b_test)); //7
            assert(testNum++,"jumpDownRight(16, b_test)",-1,jumpDownRight(16, b_test)); //-1
            assert(testNum++,"jumpDownLeft(16, b_test)",23,jumpDownLeft(16, b_test)); //23



            //List Moves Manual test
            b_test = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            b_test[16] = 1;
            b_test[12] = 1;
            b_test[19] = -1;
            b_test[27] = -1;
            jumps = new LinkedList<string>();
            LinkedList<String> results = listAvailableMoves(b_test, 1);
            

           foreach (String result in results) {
               Console.Out.WriteLine(result);
           }
            //results.Contains("");





        }

        //TODO
        static int difficulty;
        static public int[] board;
       //"Constants for peices in checkers board"
        static int BKing = -2;
        static int BMan = -1;
        static int WKing = 2;
        static int WMan = 1;
        static int EmptySquare = 0;
        static Dictionary<int, String> peiceType;
        static LinkedList<String> jumps;
        //String[] jumps;

        static Dictionary<String, String> openingCounterMoves;
        static private bool openingMv;
        //private Checkers boardUI;

        static public void init()
        {
            //boardUI = checkers;
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
            peiceType.Add(BKing,"Black King");
            peiceType.Add(WKing,"White King");
            peiceType.Add(WMan,"White");
            peiceType.Add(BMan,"Black");
            peiceType.Add(EmptySquare,"");
            pB();

        }

        private static void pB(int[] b)
        {
	int count = 0;
	//t1 = template
	    for(count =1;count<33;count++){
            //boardUI.buttons[count].Text = peiceType[b[count]];
        }
    }
        static public void pB()
    {
        int count = 0;
        //t1 = template
        for (count = 1; count < 33; count++)
        {
            //boardUI.buttons[count].Text = peiceType[board[count]];
        }
    }
        
        private static bool isOddRow(int pos){
	        return (((pos-1)/4)%2) == 1;
        }

        private static bool isEvenRow(int pos){
            return (((pos - 1) / 4) % 2) == 0;
        }

        //'''
        //Board Boundary functions, return a true or false
        //'''
        private static bool isLeftEnd(int pos){
            return pos % 4 == 1;
        }

        private static bool isRightEnd(int pos){
            return pos % 4 == 0;
        }

        private static bool isOnBottomRow(int pos){
            return pos > 28;
        }

        private static bool isOnTopRow(int pos){
            return pos < 5;
        }



        
    /*
    '''
    Directional functions, return the value of the square in the given direction.
    If that direction is not available returns -1
    '''
    */

    private static int downLeft(int pos){
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
		    Console.Out.WriteLine("Unhandled Case!!");
            return -1;
	    }
    }

    private static int downRight(int pos){
	    if (isRightEnd(pos) && isEvenRow(pos) || isOnBottomRow(pos)){
		    return -1;
	    }
	    if(isEvenRow(pos)){
		    return pos + 5;
	    }
	    if (isOddRow(pos)){
		    return pos + 4;
	    }else{
            Console.Out.WriteLine("downRight, Unhandled case!!!");
            return -2;
        }

    }

    private static int upLeft(int pos){
	    if (isLeftEnd(pos) && isOddRow(pos) || isOnTopRow(pos)){
		    return -1;
	    }
	    if (isEvenRow(pos)){
		    return pos - 4;
	    }
	    if (isOddRow(pos)){
		    return pos - 5;
	    }else{
            Console.Out.WriteLine("upLeft, Unhandled case!!!");
            return -2;
        }
    }

    private static int upRight(int pos){
	    if (isRightEnd(pos) && isEvenRow(pos) || isOnTopRow(pos)){
		    return -1;
	    }
	    if (isEvenRow(pos)){
		    return pos - 3;
	    }
	    if (isOddRow(pos)){
		    return pos - 4;
	    }else{
            Console.Out.WriteLine("upRight, Unhandled case!!!");
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

    private static int jumpUpRight(int pos,int[] b1){
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

    private static int jumpUpLeft(int pos,int[] b1){
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

    private static int jumpDownRight(int pos, int[] b1){
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

    private static int jumpDownLeft(int pos, int[] b1){
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

    private static LinkedList<String> checkForJumps(int[] board_, int pos)
    {
	    //int[] jumps = new int[] {1, 2, 3, 4, 5};
        
	    jumps.Clear();
	    int[] b1; 
        b1 = (int[])board_.Clone();
        DirectionFunc[] directions = null;
        
	    int square = b1[pos];
	    if ((square == BKing) || (square == WKing)){
            Console.Out.WriteLine("0x01");
		    directions = new DirectionFunc[]{new DirectionFunc(jumpDownLeft),new DirectionFunc(jumpDownRight),new DirectionFunc(jumpUpLeft),new DirectionFunc(jumpUpRight)};
	    }
	    if (square == WMan){
            Console.Out.WriteLine("0x02");
		    directions = new DirectionFunc[]{new DirectionFunc(jumpDownLeft),new DirectionFunc(jumpDownRight)};
	    }
	    if (square == BMan){
            Console.Out.WriteLine("0x03");
		    directions = new DirectionFunc[]{new DirectionFunc(jumpUpLeft),new DirectionFunc(jumpUpRight)};
	    }
        //Console.Out.WriteLine("Calling Check for jumps...");
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
    private static LinkedList<String> checkForJumpsHelper(DirectionFunc[] directions, int[] b1, int pos, String path)
    {
	    //global jumps;
	    //#b1 = board;
	    //##print "pos is:" +str(pos)
	    //#printBoard(b1)

        bool jumpAvailableFlag = false;
        if (directions == null)
        {
            //Console.Out.WriteLine("***Check for jumps Warning Directions == null!!");
            return null;
        }
        //Console.Out.WriteLine("checkforjumps Foreach...");
	    foreach (DirectionFunc direction in directions){
            //Console.Out.WriteLine("checkforjumps Foreach...+");
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
                Console.Out.WriteLine("jump found!!!!!!!!!!!"+path);
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



    private static LinkedList<String> checkForSlidesHelper(DirectionFuncSingle[] directions, int[] board, int pos)
    {
	    LinkedList<String> slides = new LinkedList<String>();

        //Console.Out.WriteLine("Checking for slides helper");
        foreach(DirectionFuncSingle direction in directions){
            //Console.Out.WriteLine("Foreach Checking for slides helper");
		    if(direction(pos) != -1){
               // Console.Out.WriteLine(".Checking for slides helper");
			    if( board[direction(pos)] == 0){
                   // Console.Out.WriteLine("..Checking for slides helper");
				    //#print str(pos) + "-" + str(direction(pos))
				    slides.AddLast(""+pos+"-"+direction(pos));
                    //slides.append(str(pos) + "-" + str(direction(pos)));                     
			    }
		    }
	    }

	    return slides;
    }



    private static LinkedList<String> checkForSlides(int[] board, int pos)
    {
        //Console.Out.WriteLine("CheckForSlides Called");
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

    public static LinkedList<String> listAvailableMoves()
    {
        Console.Out.WriteLine("0.a ListMoves...");
        int player =-1;
        return listAvailableMoves(board, player);
    
    }


    private static LinkedList<String> listAvailableMoves(int[] board, int player){
	    //moves = [];
        //Console.Out.WriteLine("0.b ListMoves...");
        LinkedList<String> moves = new LinkedList<String>();
	    bool jumpsFlag = false;
	    if (player > 0){
            Console.Out.WriteLine("1.");
            for(int place = 0;place<33;place++){
                
              //  Console.Out.WriteLine("0.d ListMoves...");
			    if(board[place] > 0){
                    //Console.Out.WriteLine("Jumps False comp move");
				    if (checkForJumps(board,place) != null){
					    jumpsFlag = true;
                //        Console.Out.WriteLine("1. ListMoves Checking for jumps...");
                        Console.Out.WriteLine("****checkjumps");
                        conCat(moves, checkForJumps(board, place));
					    //moves = (LinkedList<String>)moves.Concat(checkForJumps(board,place));
				    }
			    }
		    }
            Console.Out.WriteLine("0.e ListMoves...");
		    if(jumpsFlag == false){
                
                Console.Out.WriteLine("Jumps False comp move");
			    for(int place = 0;place<33;place++){
                    if (checkForJumps(board, place) == null)
                    {
                        if (board[place] > 0)
                        {
                 //           Console.Out.WriteLine("2. ListMoves Checking for jumps...");
                            Console.Out.WriteLine("****checkslides");
                            conCat(moves, checkForSlides(board, place));
                            //moves = (LinkedList<String>)moves.Concat(checkForSlides(board, place));
                        }
                    }
			    }
            }
	    }
	    if(player < 0){
            Console.Out.WriteLine("0.f ListMoves...");
		    for(int place = 0;place<33;place++){
                //Console.Out.WriteLine("0.f ListMoves...Forloop");
			    if(board[place] < 0){
                  //  Console.Out.WriteLine("0.f ListMoves...if1");
				    if(checkForJumps(board,place) != null){
                    //    Console.Out.WriteLine("0.f ListMoves...if2");
					    jumpsFlag = true;
                      //  Console.Out.WriteLine("3. ListMoves Checking for jumps...");
                        conCat(moves, checkForJumps(board, place));
					    //moves = (LinkedList<String>)moves.Concat(checkForJumps(board,place));
				    }
			    }

		    }
		    if(jumpsFlag == false){
                //Console.Out.WriteLine("0.g ListMoves...");
                for(int place = 0;place<33;place++){
                  //  Console.Out.WriteLine("0.gForloop...");
                    //Console.Out.WriteLine("0.g Checkforjumps:" + checkForJumps(board, place));
                    if(checkForJumps(board,place) == null){
                      //  Console.Out.WriteLine("0.g Checkforjumps is null");
				        if(board[place] < 0){
                        //    Console.Out.WriteLine("4. ListMoves Checking for jumps...");
                            conCat(moves, checkForSlides(board, place));
					        //moves = (LinkedList<String>)moves.Concat(checkForSlides(board,place));
				        }
                    }
			    }
		    }
        }
        Console.Out.WriteLine("ListMoves... Returning");
	    return moves;
}


    private static void conCat(LinkedList<String> l1, LinkedList<String> l2)
    {
        foreach(String str in l2){
            l1.AddLast(str);
        }
    }

    private static LinkedList<String> listAvailableMoves1(int[] board, int player)
    {
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
    private static Tuple<String, int> min(Tuple<String, int> a, Tuple<String, int> b)
    {
	    if(a.Item2>b.Item2){
		    return b;
	    }
	    else{
		    return a;
	    }
    }

    //TODO0
    private static Tuple<String, int> max(Tuple<String, int> a, Tuple<String, int> b)
    {
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
    private static void move(int position, int to, int[] board)
    {
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
    private static void performMove(String mv, int[] board)
    {
        Console.Out.WriteLine("Move:"+mv);
	    if(mv.Contains("-")){
            String[] result = null;
            result = mv.Split('-');
            String pos,des;
		    pos= result[0];
            des = result[1]; 
		    int a =  Int32.Parse(pos);
		    int b =  Int32.Parse(des);
            //Console.Out.WriteLine("moving-...");
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
                //Console.Out.WriteLine("***moving...");
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
    private static void performMoveReal(String mv, int[] board)
    {
        //Console.Out.WriteLine("PMR, Move:" + mv);
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
                pB(board);
                Thread.Sleep(1);
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

                Thread.Sleep(1);
            }
        }
    }

/*
'''
Minimax helper function is mainly concerned with return a value for a branch
'''*/
//private var moveValPair;

    private static Tuple<String, int> minimaxHelper(int[] b, int depth, bool maximizingPlayer, String mv)
    {
	performMove(mv,b);
	if(depth == 0){
		int sumval = b.Sum();
		//#printBoard(board);
		return new Tuple<String,int>(mv,sumval);
    }
	if(maximizingPlayer){
		Tuple<String,int> bestValue = new Tuple<String,int>("",-1000);
		LinkedList<String> moves = listAvailableMoves(b,1);
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
		foreach(String move in moves){
			Tuple<String,int> val = minimaxHelper((int[])b.Clone(), depth - 1, true, mv);
			bestValue = min(bestValue, val);
        }
		return bestValue;
    }
}

/*
'''
Wraps the minimax helper, and determines the best move for the AI
'''*/
    public static Tuple<String, int> minimax(int[] b, int depth, bool maximizingPlayer, String mv)
    {
	performMove(mv,b);
	if(depth == 0){
		int sumval = b.Sum();
		//#printBoard(board)
		return new Tuple<String,int>(mv,sumval);
    }
	if(maximizingPlayer){
        //Console.Out.WriteLine("CompMoves ");
		Tuple<String,int> bestValue = new Tuple<String,int>("",-1000);
		LinkedList<String> moves = listAvailableMoves(b,1);
        
		//# if len(moves) == 1:
		//# 	return [moves[0],1]
		foreach( String move in moves){
            Console.Out.WriteLine("CompMoves " + move);
			Tuple<String,int> val = minimaxHelper((int[])b.Clone(), depth - 1, false, move);
			//val.Item1=move; TODO check this
			//#print mv + " val: " +str(val[1])
			bestValue = max(bestValue, val);
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
			//val[0] = mv;
			bestValue = min(bestValue, val);
        }
		return bestValue;
    }
   }

/*
'''
Executes a move for the AI
'''*/
///*
    private static void computerMove(int[] b, int plies)
    {
	if (listAvailableMoves(b,1) == null){
		Console.Out.WriteLine("Game Over, You win!");
    }
    Console.Out.WriteLine("Plies:"+plies);
	String res = minimax(b, plies, true, "0+0").Item1;

    Console.Out.WriteLine("Perform move real called.."+res);
    performMoveReal(res,b);
	//#print res
    pB(board);
}

    private static void computerMoveB(int[] b, int plies)
    {
    String res = minimax(b, plies, false, "0+0").Item1;
    performMove(res,b);
    //log("Computer move: "+str(res))
    //#print res
    pB(board);
}
        

    }

}
 

