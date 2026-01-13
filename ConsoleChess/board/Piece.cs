namespace board{
    public abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moveCount { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.moveCount = 0;
        }

        public void incrementMoveCount()
        {
            moveCount++;
        }

        public abstract bool[,] possibleMove();

    }
}