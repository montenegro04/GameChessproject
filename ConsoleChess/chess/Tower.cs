using board;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Color color, Board board) : base(board, color){
        }

        public override string ToString()
        {
            return "T";
        }
    }
}