using System;
using board;

namespace chess
{
    class MatchChess
    {
        public Board board{ get;  private set; }
        public int turn{ get;  private set; }
        public  Color currentPlayer{ get;  private set; }
        public bool finished { get; private set; }

        public MatchChess()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;   //regra do xadrez, o branco começa jogando
            putPieces();
        }

        public void executeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoveCount();
            Piece capturedPiece = board.removePiece(destination);
            board.putPiece(p, destination);
        }

        public void validadePositionOrigin(Position pos)
        {
            if(board.piece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position!");
            }
            if(currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if(!board.piece(pos).existMovePossible())
            {
                throw new BoardException("There are no possible moves for the origin piece!");
            }
        }

        public void makeMove(Position origin, Position destination)
        {
            executeMove(origin, destination);
            turn++;
            currentPlayer = (currentPlayer == Color.White) ? Color.Black : Color.White;
        }

        public void validadePositionDestination(Position origin, Position destination)
        {
            if(!board.piece(origin).canMoveTo(destination))
            {
                throw new BoardException("The chosen piece can't move to the destination position!");
            }
        }

        public void changePlayer()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        private void putPieces()
        {
            board.putPiece(new Tower(Color.White, board), new PositionChess('c', 1).toPosition());
            board.putPiece(new Tower(Color.White, board), new PositionChess('c', 2).toPosition());
            board.putPiece(new Tower(Color.White, board), new PositionChess('d', 2).toPosition());
            board.putPiece(new Tower(Color.White, board), new PositionChess('e', 2).toPosition());
            board.putPiece(new Tower(Color.White, board), new PositionChess('e', 1).toPosition());
            board.putPiece(new King(Color.White, board), new PositionChess('d', 1).toPosition());

            board.putPiece(new Tower(Color.Black, board), new PositionChess('c', 7).toPosition());
            board.putPiece(new Tower(Color.Black, board), new PositionChess('c', 8).toPosition());
            board.putPiece(new Tower(Color.Black, board), new PositionChess('d', 7).toPosition());
            board.putPiece(new Tower(Color.Black, board), new PositionChess('e', 7).toPosition());
            board.putPiece(new Tower(Color.Black, board), new PositionChess('e', 8).toPosition());
            board.putPiece(new King(Color.Black, board), new PositionChess('d', 8).toPosition());
        }
    }
}