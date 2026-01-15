using System;
using System.Collections.Generic;
using board;

namespace chess
{
    public class MatchChess
    {
        public Board board{ get;  private set; }
        public int turn{ get;  private set; }
        public  Color currentPlayer{ get;  private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public MatchChess()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;   //regra do xadrez, o branco começa jogando
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public void executeMove(Position origin, Position destination)
        {
            Piece? p = board.removePiece(origin);
            p?.incrementMoveCount();
            Piece? capturedPiece = board.removePiece(destination);
            board.putPiece(p!, destination);

            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in pieces)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('c', 1, new Tower(Color.White, board));
            putNewPiece('c', 2, new Tower(Color.White, board));
            putNewPiece('d', 2, new Tower(Color.White, board));
            putNewPiece('e', 2, new Tower(Color.White, board));
            putNewPiece('e', 1, new Tower(Color.White, board));
            putNewPiece('d', 1, new King(Color.White, board));

            putNewPiece('c', 7, new Tower(Color.Black, board));
            putNewPiece('c', 8, new Tower(Color.Black, board));
            putNewPiece('d', 7, new Tower(Color.Black, board));
            putNewPiece('e', 7, new Tower(Color.Black, board));
            putNewPiece('e', 8, new Tower(Color.Black, board));
            putNewPiece('d', 8, new King(Color.Black, board));

        }
    }
}