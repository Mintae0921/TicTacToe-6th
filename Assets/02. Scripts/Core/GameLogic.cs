
using static Constants;

public class GameLogic
{
    public BlockController controller;

    private PlayerType[,] board;

    public BaseState playerStateA;
    public BaseState playerStateB;

    private BaseState currentState;

    public enum GameResult { None, Win, Lose, Draw }

    // 보드 정보
    public Constants.PlayerType[,] Board {  get { return board; } }



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
                playerStateB = new AIState(false);

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

        return true;
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

    public GameResult CheckGameResult()
    {
        if (TicTacToeAI.CheckGameWin(PlayerType.Player1, board))
            return GameResult.Win;

        if (TicTacToeAI.CheckGameWin(PlayerType.Player2, board))
            return GameResult.Lose;

        if (TicTacToeAI.CheckGameDraw(board))
            return GameResult.Draw;

        return GameResult.None;
    }


    public void EndGame(GameResult gameResult)
    {
        string resultStr = "";
        switch (gameResult)
        {
            case GameResult.Win:
                resultStr = "Player1 승리!";
                break;
            case GameResult.Lose:
                resultStr = "Player2 승리!";
                break;
            case GameResult.Draw:
                resultStr = "무승부";
                break;
        }

        GameManager.Instance.OpenConfirmPanel(resultStr, () =>
        {
            GameManager.Instance.ChangeToMainScene();
        });

    }

}
