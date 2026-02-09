
using static Constants;

public class GameLogic
{
    public BlockController controller;

    private PlayerType[,] board;

    public BaseState playerStateA;
    public BaseState playerStateB;

    private BaseState currentState;

    public GameLogic(GameType gameType, BlockController blockController)
    {
        controller = blockController;


        // 보드 정보 초기화
        board = new PlayerType[Board_Size, Board_Size];


        //GameTpye에 따른 초기화 작업 수행
        switch (gameType)
        {
            case GameType.SinglePlay:
                playerStateA = new PlayerState(true);
                playerStateB = new AIState();

                SetState(playerStateA);
                break;
            case GameType.DualPlay:
                playerStateA = new PlayerState(true);
                playerStateB = new PlayerState(false);

                SetState(playerStateA);
                break;

        }

    }

    public void SetState(BaseState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }

    public bool PlaceMarker(int index, Constants.PlayerType playerType)
    {
        var row = index / Board_Size;
        var col = index % Board_Size;

        if (board[row, col] != Constants.PlayerType.None)
            return false;

        controller.PlaceMarker(index, playerType);
        board[row, col] = playerType;

        return false;
    }

    public void ChangeGameState()
    {
        if (currentState == playerStateA)
        {
            SetState(playerStateB);
        }
        else
        {
            SetState(playerStateA);
        }
    }

    public void CheckGameResult()
    {
        // 승리 조건 확인 로직 구현(생략)
    }

    public bool CheckGameWin(Constants.PlayerType playerType, Constants.PlayerType[,] board)
    {
        return false;
    }
}
