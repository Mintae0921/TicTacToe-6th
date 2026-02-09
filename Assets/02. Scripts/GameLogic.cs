using static Constants;

public class GameLogic
{
    private BlockController Controller;

    public GameLogic(GameType gameType, BlockController blockController)
    {
        Controller = blockController;
    }
}
