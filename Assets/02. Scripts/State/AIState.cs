using UnityEngine;

public class AIState : BaseState
{
    private Constants.PlayerType playerType;

    public AIState(bool isFirstPlayer)
    {
        playerType = isFirstPlayer ? Constants.PlayerType.Player1 : Constants.PlayerType.Player2;
    }

    public override void HandleMove(GameLogic gameLogic, int index)
    {
        ProcessMove(gameLogic, index, playerType);
    }

    public override void HandleNextTurn(GameLogic gameLogic)
    {
        gameLogic.ChangeGameState();
    }

    public override void OnEnter(GameLogic gameLogic)
    {
        GameManager.Instance.SetGameTurn(playerType);

        // AI의 이동 처리
        var board = gameLogic.Board;
        var result = TicTacToeAI.GetBestMove(board);

        if (result.HasValue)
        {
            int row = result.Value.row;
            int col = result.Value.col;
            int index = row * Constants.Board_Size + col;

            HandleMove(gameLogic, index);
        }
    }

    public override void OnExit(GameLogic gameLogic)
    {

    }
}
