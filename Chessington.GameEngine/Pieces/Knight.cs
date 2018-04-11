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

            var _squares = new List<Square>();
            var squares = new List<Square>();

            _squares.Add(new Square(currentSquare.Row + 2, currentSquare.Col + 1));
            _squares.Add(new Square(currentSquare.Row + 2, currentSquare.Col - 1));


            _squares.Add(new Square(currentSquare.Row - 2, currentSquare.Col + 1));
            _squares.Add(new Square(currentSquare.Row - 2, currentSquare.Col - 1));


            _squares.Add(new Square(currentSquare.Row + 1, currentSquare.Col + 2));
            _squares.Add(new Square(currentSquare.Row + 1, currentSquare.Col - 2));


            _squares.Add(new Square(currentSquare.Row - 1, currentSquare.Col + 2));
            _squares.Add(new Square(currentSquare.Row - 1, currentSquare.Col - 2));

            foreach (Square sq in _squares)
            {
                if (board.OnBoard(sq))
                {
                    if (!board.IsBlocked(sq))
                    {
                        squares.Add(sq);
                    }

                    if (board.IsEnemy(sq, Player))
                    {
                        squares.Add(sq);
                    }
                }
            }
            return squares;
        }
    }
}