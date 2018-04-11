using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            if (this.Player == Player.White)
            {
                // normal move case
                var squares = new List<Square>();

                var posSquare = new Square(currentSquare.Row - 1, currentSquare.Col);

                if (posSquare.Row > -1 || posSquare.Col > -1 || posSquare.Row < 7 || posSquare.Col < 7)
                {
                    if (board.GetPiece(posSquare) == null)
                    {
                        squares.Add(posSquare);
                    }
                }

                // first move case
                if (currentSquare.Row == 6)
                {

                    posSquare = new Square(currentSquare.Row - 2, currentSquare.Col);

                    if (board.GetPiece(posSquare) == null)
                    {
                        squares.Add(posSquare);
                    }
                }

                // taking case

                posSquare = new Square(currentSquare.Row - 1, currentSquare.Col + 1);

                if (posSquare.Row > -1 || posSquare.Col > -1 || posSquare.Row < 7 || posSquare.Col < 7)
                {

                    if (board.GetPiece(posSquare) != null)
                    {
                        squares.Add(posSquare);
                    }
                }

                posSquare = new Square(currentSquare.Row - 1, currentSquare.Col - 1);

                if (posSquare.Row > -1 || posSquare.Col > -1 || posSquare.Row < 7 || posSquare.Col < 7)
                {

                    if (board.GetPiece(posSquare) != null)
                    {
                        squares.Add(posSquare);
                    }
                }

                return squares;
            }
            else
            {
                // normal move case
                var squares = new List<Square>();

                var posSquare = new Square(currentSquare.Row + 1, currentSquare.Col);

                if (posSquare.Row > -1 || posSquare.Col > -1 || posSquare.Row < 7 || posSquare.Col < 7)
                {
                    if (board.GetPiece(posSquare) == null)
                    {
                        squares.Add(posSquare);
                    }
                }

                // first move case
                if (currentSquare.Row == 1)
                {

                    posSquare = new Square(currentSquare.Row + 2, currentSquare.Col);

                    if (board.GetPiece(posSquare) == null)
                    {
                        squares.Add(posSquare);
                    }
                }

                // taking case

                posSquare = new Square(currentSquare.Row + 1, currentSquare.Col + 1);

                if (posSquare.Row > -1 || posSquare.Col > -1 || posSquare.Row < 7 || posSquare.Col < 7)
                {

                    if (board.GetPiece(posSquare) != null)
                    {
                        squares.Add(posSquare);
                    }
                }

                posSquare = new Square(currentSquare.Row + 1, currentSquare.Col - 1);

                if (posSquare.Row > -1 || posSquare.Col > -1 || posSquare.Row < 7 || posSquare.Col < 7)
                {

                    if (board.GetPiece(posSquare) != null)
                    {
                        squares.Add(posSquare);
                    }
                }

                return squares;
            }
        }
    }
}