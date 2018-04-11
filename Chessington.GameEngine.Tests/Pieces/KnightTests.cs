using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void WhiteKnights_LongUpRight()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(5, 5), knight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 6));
        }

        [Test]
        public void BlackKnights_LongLDownLeft()
        {
            var board = new Board();
            var knight = new Knight(Player.Black);
            board.AddPiece(Square.At(5, 1), knight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(7, 0));
        }
        [Test]
        public void WhiteKnights_WideDownLeft()
        {
            var board = new Board();
            var knight = new Knight(Player.Black);
            board.AddPiece(Square.At(5, 5), knight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 3));
        }
        [Test]
        public void BlackKnights_WideUpRight()
        {
            var board = new Board();
            var knight = new Knight(Player.Black);
            board.AddPiece(Square.At(5, 5), knight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 7));
        }
    }
}