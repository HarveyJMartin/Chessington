using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public bool HasMoved = false;

        public Pawn(Player player)
            : base(player)
        {

        }

        public override void MoveTo(Board board, Square square)
        {
            base.MoveTo(board, square);
            HasMoved = true;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            var UpDown = this.Player == Player.White ? -1 : 1;

            // normal move case
            var squares = new List<Square>();

            var posSquare = new Square(currentSquare.Row + UpDown, currentSquare.Col);

            if (board.OnBoard(posSquare))
            {
                if (!board.IsBlocked(posSquare))
                {
                    squares.Add(posSquare);
                }
            }

            // first move case
            if (HasMoved == false)
            {
                posSquare = new Square(currentSquare.Row + UpDown * 2, currentSquare.Col);
                if (board.OnBoard((posSquare)))
                {
                    if (!board.IsBlocked(posSquare))
                    {
                        var inTheWay = new Square(currentSquare.Row + UpDown, currentSquare.Col);

                        if (!board.IsBlocked(inTheWay))
                        {
                            squares.Add(posSquare);
                        }
                    }
                }
            }

            // taking case

            posSquare = new Square(currentSquare.Row + UpDown, currentSquare.Col + 1);

            if (board.OnBoard(posSquare))
            {
                if (board.IsEnemy(posSquare, Player))
                {
                    squares.Add(posSquare);
                }
            }

            posSquare = new Square(currentSquare.Row + UpDown, currentSquare.Col - 1);

            if (board.OnBoard(posSquare))
            {
                if (board.IsEnemy(posSquare, Player))
                {
                    squares.Add(posSquare);
                }
            }

            return squares;
        }
    }
}