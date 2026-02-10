using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject settingsPanelPrefab;
    [SerializeField] private GameObject ConfirmPanelPrefab;

    private Canvas canvas;

    private GameType _gameType;

    private GamePanelController _gamePanelController;

    private GameLogic Logic;

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        canvas = FindFirstObjectByType<Canvas>();

        if (scene.name == "02. Game")
        {
            var blockController = FindFirstObjectByType<BlockController>();
            if (blockController != null)
            {
                blockController.InitBlocks();
            }

            _gamePanelController = FindFirstObjectByType<GamePanelController>();

            // GameLogic »ý¼º
            Logic = new GameLogic(_gameType, blockController);
        }
    }

    public void SetGameTurn(Constants.PlayerType playerTurnType)
    {
        _gamePanelController.SetPlayerTurnPanel(playerTurnType);
    }

    public void OpenSettingsPanel()
    {
        var settingsPanelObject = Instantiate(settingsPanelPrefab, canvas.transform);
        settingsPanelObject.GetComponent<SettingsPanelController>().Show();
    }

    public void OpenConfirmPanel(string message, ConfirmPanelController.OnConfirmButtonClicked onConfirmButtonClicked)
    {
        var confirmPanelObject = Instantiate(ConfirmPanelPrefab, canvas.transform);
        confirmPanelObject.GetComponent<ConfirmPanelController>().Show(message, onConfirmButtonClicked);
    }

    public void ChangeToGameScene(GameType gameType)
    {
        _gameType = gameType;
        SceneManager.LoadScene("02. Game");


    }

    public void ChangeToMainScene()
    {

        SceneManager.LoadScene("01. Main");
    }
}
