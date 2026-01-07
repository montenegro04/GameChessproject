using System;
using board;

namespace chess
{
    class MatchChess
    {
        public Board board{ get;  private set; }
        private int turn;
        private Color currentPlayer;
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