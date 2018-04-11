using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {

            var currentSquare = board.FindPiece(this);
            
                var squares = new List<Square>();

                squares.Add(new Square(currentSquare.Row + 2, currentSquare.Col + 1));
                squares.Add(new Square(currentSquare.Row + 2, currentSquare.Col - 1));


                squares.Add(new Square(currentSquare.Row - 2, currentSquare.Col + 1));
                squares.Add(new Square(currentSquare.Row - 2, currentSquare.Col - 1));


                squares.Add(new Square(currentSquare.Row + 1, currentSquare.Col + 2));
                squares.Add(new Square(currentSquare.Row + 1, currentSquare.Col - 2));


                squares.Add(new Square(currentSquare.Row - 1, currentSquare.Col + 2));
                squares.Add(new Square(currentSquare.Row - 1, currentSquare.Col - 2));

                return squares;
        }
    }
}