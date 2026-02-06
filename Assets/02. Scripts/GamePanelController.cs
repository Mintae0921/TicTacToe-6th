using UnityEngine;
using UnityEngine.UI;
using static Constants;

public class GamePanelController : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button settingButton;

    private void Start()
    {
        backButton.onClick.AddListener(OnClickBackButton);
        settingButton.onClick.AddListener(OnClickSettingsButton);
    }

    public void OnClickBackButton()
    {
        GameManager.Instance.ChangeToMainScene();

    }

    public void OnClickSettingsButton()
    {
        GameManager.Instance.OpenSettingsPanel();

    }
}
