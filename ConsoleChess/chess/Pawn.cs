using board;

namespace chess
{
    class Pawn : Piece
    {
        private MatchChess game;
        public Pawn(Color color, Board board, MatchChess game) : base(board, color)
        {
            this.game = game;
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

                //#especialmove en passant
                if(position.line == 3)
                {
                    Position left = new Position(position.line, position.column -1);
                    if (board.validPosition(left) && existEnemy(left) && board.piece(left) == game.vulnerableEnPassant)
                    {
                        mat[left.line - 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column +1);
                    if (board.validPosition(right) && existEnemy(right) && board.piece(right) == game.vulnerableEnPassant)
                    {
                        mat[right.line - 1, right.column] = true;
                    }
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

                //#especialmove en passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.validPosition(left) && existEnemy(left) && board.piece(left) == game.vulnerableEnPassant)
                    {
                        mat[left.line + 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (board.validPosition(right) && existEnemy(right) && board.piece(right) == game.vulnerableEnPassant)
                    {
                        mat[right.line + 1, right.column] = true;
                    }
                }
            }

            return mat;
        }
    }
}