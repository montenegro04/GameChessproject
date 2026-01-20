using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "P";
        }

        private bool existEnemy(Position position)
        {
            Piece p = board.piece(position);
            return p != null && p.color != color;
        }

        private bool free(Position position)
        {
            return board.piece(position) == null;
        }

        public override bool[,] possibleMove()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.setValues(position.line - 1, position.column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 2, position.column);
                if (board.validPosition(pos) && free(pos) && board.validPosition(pos) && free(pos) && moveCount == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column - 1);
                if (board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column + 1);
                if (board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.setValues(position.line + 1, position.column);
                if (board.validPosition(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 2, position.column);
                if (board.validPosition(pos) && free(pos) && board.validPosition(pos) && free(pos) && moveCount == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column - 1);
                if (board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column + 1);
                if (board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }

            return mat;
        }
    }
}