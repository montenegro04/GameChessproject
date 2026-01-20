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
        public bool check { get; private set; }

        public MatchChess()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;   //regra do xadrez, o branco começa jogando
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public Piece executeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoveCount();
            Piece capturedPiece = board.removePiece(destination);
            board.putPiece(p, destination);

            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void movementUndo(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.removePiece(destination);
            p.decrementMoveCount();

            if(capturedPiece != null)
            {
                board.putPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.putPiece(p, origin);
        }
        public void makeMove(Position origin, Position destination)
        {
            Piece pieceCaptured = executeMove(origin, destination);

            if(isInCheck(currentPlayer))
            {
                movementUndo(origin, destination, pieceCaptured);
                throw new BoardException("You can't put yourself in check!");
            }

            if(isInCheck(opponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if(testCheckMate(opponent(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                changePlayer();
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

        public void validadePositionDestination(Position origin, Position destination)
        {
            if(!board.piece(origin).possibleMovement(destination))
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

        private Color opponent(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach(Piece x in piecesInGame(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
           return null;
        }

        public bool isInCheck(Color color)
        {
            Piece k = king(color);
            if(k == null)
            {
                throw new BoardException("There is no " + color + " king on the board!");
            }

            foreach(Piece x in piecesInGame(opponent(color)))
            {
                bool[,] mat = x.possibleMove();
                if(mat[k.position.line, k.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckMate(Color color)
        {
            if(!isInCheck(color))
            {
                return false;
            }
            foreach(Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMove();
                for(int i = 0; i < board.lines; i++)
                {
                    for(int j = 0; j < board.columns; j++)
                    {
                        if(mat[i,j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i,j);
                            Piece capturedPiece = executeMove(origin, destination);
                            bool testCheck = isInCheck(color);
                            movementUndo(origin, destination, capturedPiece);
                            if(!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('a', 1, new Tower(Color.White, board));
            putNewPiece('b', 1, new Horse(Color.White, board));
            putNewPiece('c', 1, new Bishop(Color.White, board));
            putNewPiece('d', 1, new Lady(Color.White, board));
            putNewPiece('e', 1, new King(Color.White, board));
            putNewPiece('f', 1, new Bishop(Color.White, board));
            putNewPiece('g', 1, new Horse(Color.White, board));
            putNewPiece('h', 1, new Tower(Color.White, board));
            putNewPiece('a', 2, new Pawn(Color.White, board));
            putNewPiece('b', 2, new Pawn(Color.White, board));
            putNewPiece('c', 2, new Pawn(Color.White, board));
            putNewPiece('d', 2, new Pawn(Color.White, board));
            putNewPiece('e', 2, new Pawn(Color.White, board));
            putNewPiece('f', 2, new Pawn(Color.White, board));
            putNewPiece('g', 2, new Pawn(Color.White, board));
            putNewPiece('h', 2, new Pawn(Color.White, board));

            putNewPiece('a', 8, new Tower(Color.Black, board));
            putNewPiece('b', 8, new Horse(Color.Black, board));
            putNewPiece('c', 8, new Bishop(Color.Black, board));
            putNewPiece('d', 8, new Lady(Color.Black, board));
            putNewPiece('e', 8, new King(Color.Black, board));
            putNewPiece('f', 8, new Bishop(Color.Black, board));
            putNewPiece('g', 8, new Horse(Color.Black, board));
            putNewPiece('h', 8, new Tower(Color.Black, board));
            putNewPiece('a', 7, new Pawn(Color.Black, board));
            putNewPiece('b', 7, new Pawn(Color.Black, board));
            putNewPiece('c', 7, new Pawn(Color.Black, board));
            putNewPiece('d', 7, new Pawn(Color.Black, board));
            putNewPiece('e', 7, new Pawn(Color.Black, board));
            putNewPiece('f', 7, new Pawn(Color.Black, board));
            putNewPiece('g', 7, new Pawn(Color.Black, board));
            putNewPiece('h', 7, new Pawn(Color.Black, board));



            
        }
    }
}