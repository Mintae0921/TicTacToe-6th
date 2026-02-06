using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject settingsPanelPrefab;
    [SerializeField] private Canvas canvas;

    private GameType _gameType;

    private void Awake()
    {
        canvas = FindFirstObjectByType<Canvas>();
    }

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {

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
