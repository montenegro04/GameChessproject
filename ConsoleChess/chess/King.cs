using board;

namespace chess
{
    class King : Piece
    {
        public King(Color color, Board board) : base(board, color){
        }

        public override string ToString()
        {
            return "K";
        }
    }
}