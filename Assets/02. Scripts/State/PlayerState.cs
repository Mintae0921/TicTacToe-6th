using UnityEngine;

public class PlayerState : BaseState
{
    private Constants.PlayerType playerType;

    public PlayerState(bool isFirstPlayer)
    {
        playerType = isFirstPlayer ? Constants.PlayerType.Player1 : Constants.PlayerType.Player2;
    }

    public override void HandleMove(GameLogic gameLogic, int index)
    {
        ProcessMove(gameLogic,index, playerType);
    }

    public override void HandleNextTurn(GameLogic gameLogic)
    {
        gameLogic.ChangeGameState();
    }

    public override void OnEnter(GameLogic gameLogic)
    {
        gameLogic.controller.onBlockClicked = (blockIndex) =>
        {
            HandleMove(gameLogic, blockIndex);
        };

        // UI 업데이트
        GameManager.Instance.SetGameTurn(playerType);
    }

    public override void OnExit(GameLogic gameLogic)
    {
        
    }
}
