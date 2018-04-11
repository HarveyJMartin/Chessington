using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var squares = new List<Square>();
            var currentSquare = board.FindPiece(this);
            squares = squares
                .Concat(getLine(board, currentSquare, Direction.NE))
                .Concat(getLine(board, currentSquare, Direction.NW))
                .Concat(getLine(board, currentSquare, Direction.SE))
                .Concat(getLine(board, currentSquare, Direction.SW)).ToList();
            return squares;
        }
        private List<Square> getLine(Board board, Square currentSquare, Direction direction)
        {
            var squares = new List<Square>();
            var dCol = 0;
            var dRow = 0;
            switch (direction)
            {
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
            for (var i = 1; i < 8; i++)
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