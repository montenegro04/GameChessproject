using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(board, color){
        }

        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position position)
        {
            Piece p = board.piece(position);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMove()
        {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            // northeast
            pos.setValues(position.line - 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column + 1);
            }

            // northwest
            pos.setValues(position.line - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column - 1);
            }

            // southeast
            pos.setValues(position.line + 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column + 1);
            }

            // southwest
            pos.setValues(position.line + 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
