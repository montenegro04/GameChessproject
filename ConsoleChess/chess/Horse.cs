using board;

namespace chess
{
    class Horse : Piece
    {
        public Horse(Color color, Board board) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool canMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] possibleMove()
        {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            pos.setValues(position.line - 1, position.column - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(position.line - 2, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(position.line - 2, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(position.line - 1, position.column + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(position.line + 1, position.column + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(position.line + 2, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(position.line + 2, position.column - 1);
           if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            pos.setValues(position.line + 1, position.column - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }
    }
}