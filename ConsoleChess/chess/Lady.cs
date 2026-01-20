using board;

namespace chess
{
    class Lady : Piece
    {
        public Lady(Color color, Board board) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "D";
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
            // above
            pos.setValues(position.line - 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }
            
            // below
            pos.setValues(position.line + 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }

            // right
            pos.setValues(position.line, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            // left
            pos.setValues(position.line, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }
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