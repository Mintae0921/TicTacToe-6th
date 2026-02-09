using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject settingsPanelPrefab;
    [SerializeField] private Canvas canvas;

    private GameType _gameType;

    

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        canvas = FindFirstObjectByType<Canvas>();

        if (scene.name == "Game")
        {
            var blockController = FindFirstObjectByType<BlockController>();
            if (blockController != null )
            {
                blockController.InitBlocks();
            }
        }

    }

    public void OpenSettingsPanel()
    {
        var settingsPanelObject = Instantiate(settingsPanelPrefab, canvas.transform);
        settingsPanelObject.GetComponent<SettingsPanelController>().Show();
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
