namespace board{
    class Board{

        public int lines { get; set; }
        public int columns { get; set; }
        public Part[,] parts;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            parts = new Part[lines, columns];
        }
    }
}
