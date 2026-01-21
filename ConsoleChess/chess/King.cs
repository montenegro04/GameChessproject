using board;

namespace chess
{
    class King : Piece
    {

        private MatchChess game;
        public King(Color color, Board board, MatchChess game) : base(board, color){
            this.game = game;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position position)
        {
            Piece p = board.piece(position);
            return p == null || p.color != color;
        }

        private bool testTowerToRoque(Position position)
        {
            Piece p = board.piece(position);
            return p != null && p is Tower && p.color == color && p.moveCount == 0;
        }

        public override bool[,] possibleMove()
        {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            // above
            pos.setValues(position.line - 1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //northeast
            pos.setValues(position.line - 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // right
            pos.setValues(position.line, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // southeast
            pos.setValues(position.line + 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // below
            pos.setValues(position.line + 1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // southwest
            pos.setValues(position.line + 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // left
            pos.setValues(position.line, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // northwest
            pos.setValues(position.line - 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //#specialmove roque
            if(moveCount == 0 && !game.check)
            {
                //king side small rocke
                Position posT1 = new Position(position.line, position.column + 3);
                if(testTowerToRoque(posT1))
                {
                    Position p1 = new Position(position.line, position.column +1);
                    Position p2 = new Position(position.line, position.column +2);
                    if(board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }

                //king side big rocke
                Position posT2 = new Position(position.line, position.column - 4);
                if (testTowerToRoque(posT2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }

                
            }

            return mat;

        }
    }
}