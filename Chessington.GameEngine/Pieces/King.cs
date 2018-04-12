using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var squares = new List<Square>();
            var currentSquare = board.FindPiece(this);
            squares = squares
                .Concat(getLine(board, currentSquare, Direction.NE))
                .Concat(getLine(board, currentSquare, Direction.NW))
                .Concat(getLine(board, currentSquare, Direction.SE))
                .Concat(getLine(board, currentSquare, Direction.SW))
                .Concat(getLine(board, currentSquare, Direction.N))
                .Concat(getLine(board, currentSquare, Direction.S))
                .Concat(getLine(board, currentSquare, Direction.E))
                .Concat(getLine(board, currentSquare, Direction.W)).ToList();
            return squares;
        }
        private List<Square> getLine(Board board, Square currentSquare, Direction direction)
        {
            var squares = new List<Square>();
            var dCol = 0;
            var dRow = 0;
            switch (direction)
            {
                case (Direction.N):
                    dRow = -1;
                    dCol = 0;
                    break;
                case (Direction.S):
                    dRow = 1;
                    dCol = 0;
                    break;
                case (Direction.E):
                    dRow = 0;
                    dCol = 1;
                    break;
                case (Direction.W):
                    dRow = 0;
                    dCol = -1;
                    break;
                case (Direction.NE):
                    dRow = -1;
                    dCol = 1;
                    break;
                case (Direction.NW):
                    dRow = -1;
                    dCol = -1;
                    break;
                case (Direction.SE):
                    dRow = 1;
                    dCol = 1;
                    break;
                case (Direction.SW):
                    dRow = 1;
                    dCol = -1;
                    break;
            }
            for (var i = 1; i < 2; i++)
            {
                var posSquare = new Square(currentSquare.Row + i * dRow, currentSquare.Col + i * dCol);
                if (!board.OnBoard(posSquare)) break;
                if (board.IsBlocked(posSquare) && !board.IsEnemy(posSquare, Player)) break;
                squares.Add(posSquare);
                if (board.IsEnemy(posSquare, Player)) break;
            }
            return squares;
        }
    }
}