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
            squares = squares
                .Concat(getLine(board, currentSquare, Direction.N))
                .Concat(getLine(board, currentSquare, Direction.S))
                .Concat(getLine(board, currentSquare, Direction.E))
                .Concat(getLine(board, currentSquare, Direction.W)).ToList();
            return squares;

            //Square posSquare;

            //// get squares down
            //for (int i = currentSquare.Row+1; i < 8; i++)
            //{
            //    posSquare = new Square(i, currentSquare.Col);
            //    if (!board.OnBoard(posSquare)) break;
            //    if (board.IsBlocked(posSquare) && !board.IsEnemy(posSquare, Player)) break;
            //    squares.Add(posSquare);
            //    if (board.IsEnemy(posSquare, Player)) break;
            //}

            //// get squares up
            //for (int i = currentSquare.Row-1; i > -1; i--)
            //{
            //    posSquare = new Square(i, currentSquare.Col);
            //    if (!board.OnBoard(posSquare)) break;
            //    if (board.IsBlocked(posSquare) && !board.IsEnemy(posSquare, Player)) break;
            //    squares.Add(posSquare);
            //    if (board.IsEnemy(posSquare, Player)) break;
            //}

            //// get squares right
            //for (int i = currentSquare.Col+1; i < 8; i++)
            //{
            //    posSquare = new Square(currentSquare.Row, i);
            //    if (!board.OnBoard(posSquare)) break;
            //    if (board.IsBlocked(posSquare) && !board.IsEnemy(posSquare, Player)) break;
            //    squares.Add(posSquare);
            //    if (board.IsEnemy(posSquare, Player)) break;
            //}

            //// get squares left
            //for (int i = currentSquare.Col-1; i > -1; i--)
            //{
            //    posSquare = new Square(currentSquare.Row, i);
            //    if (!board.OnBoard(posSquare)) break;
            //    if (board.IsBlocked(posSquare) && !board.IsEnemy(posSquare, Player)) break;
            //    squares.Add(posSquare);
            //    if (board.IsEnemy(posSquare, Player)) break;
            //}

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