using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var squares = new List<Square>();
            var currentSquare = board.FindPiece(this);

            Square posSquare;

            // get squares down
            for (int i = currentSquare.Row+1; i < 8; i++)
            {
                posSquare = new Square(i, currentSquare.Col);
                squares.Add(posSquare);
                if (board.IsBlocked(posSquare))
                {
                    break;
                }
            }

            // get squares up
            for (int i = currentSquare.Row-1; i > -1; i--)
            {
                posSquare = new Square(i, currentSquare.Col);
                squares.Add(posSquare);
                if (board.IsBlocked(posSquare))
                {
                    break;
                }
            }

            // get squares right
            for (int i = currentSquare.Col+1; i < 8; i++)
            {
                posSquare = new Square(currentSquare.Row, i);
                squares.Add(posSquare);
                if (board.IsBlocked(posSquare))
                {
                    break;
                }
            }

            // get squares left
            for (int i = currentSquare.Col-1; i > -1; i--)
            {
                posSquare = new Square(currentSquare.Row, i);
                squares.Add(posSquare);
                if (board.IsBlocked(posSquare))
                {
                    break;
                }
            }

            return squares;
        }
    }
}