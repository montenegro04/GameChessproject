namespace board{
    class Part
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moveCount { get; protected set; }
        public Board board { get; protected set; }

        public Part(Board board, Color color, Position position)
        {
            this.position = position;
            this.board = board;
            this.color = color;
            this.moveCount = 0;
        }
    }
}