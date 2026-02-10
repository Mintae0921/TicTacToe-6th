using UnityEngine;

public static class TicTacToeAI
{

    public static (int row, int col)? GetBestMove(Constants.PlayerType[,] board)
    {
        float bestScore = float.MinValue;
        (int row, int col) bestMove = (-1, -1);

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == Constants.PlayerType.None)
                {
                    board[row, col] = Constants.PlayerType.Player2; // AI의 턴
                    float socre = DoMinMax(board, 0, false);
                    board[row, col] = Constants.PlayerType.None; // 되돌리기

                    if (socre > bestScore)
                    {
                        bestScore = socre;
                        bestMove = (row, col);
                    }
                }
            }
        }

        if (bestMove != (-1, -1))
        {
            return bestMove;
        }

        return null;
    }

    private static float DoMinMax(Constants.PlayerType[,] board, int depth, bool isMaximizing)
    {
        // 게임 결과 확인
        if (CheckGameWin(Constants.PlayerType.Player1, board))
            return -10 + depth;
        if (CheckGameWin(Constants.PlayerType.Player2, board))
            return 10 - depth;
        if (CheckGameDraw(board))
            return 0;

        if (isMaximizing)
        {
            float bestScore = float.MinValue;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == Constants.PlayerType.None)
                    {
                        board[row, col] = Constants.PlayerType.Player2; // AI의 턴
                        float score = DoMinMax(board, depth + 1, false);
                        board[row, col] = Constants.PlayerType.None; // 되돌리기
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else
        {
            float bestScore = float.MaxValue;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == Constants.PlayerType.None)
                    {
                        board[row, col] = Constants.PlayerType.Player1; // 플레이어의 턴
                        float score = DoMinMax(board, depth + 1, true);
                        board[row, col] = Constants.PlayerType.None; // 되돌리기
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }

    public static bool CheckGameWin(Constants.PlayerType playerType, Constants.PlayerType[,] board)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] == playerType &&
                board[row, 1] == playerType &&
                board[row, 2] == playerType)
            {
                return true;
            }

        }

        for (var col = 0; col < board.GetLength(1); col++)
        {
            if (board[0, col] == playerType &&
                board[1, col] == playerType &&
                board[2, col] == playerType)
            {
                return true;
            }
        }

        if (board[0, 0] == playerType &&
            board[1, 1] == playerType &&
            board[2, 2] == playerType)
        {
            return true;
        }

        if (board[0, 2] == playerType &&
            board[1, 1] == playerType &&
            board[2, 0] == playerType)
        {
            return true;
        }

        return false;
    }

    public static bool CheckGameDraw(Constants.PlayerType[,] board)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == Constants.PlayerType.None) return false;
            }
        }

        return true;
    }
}
