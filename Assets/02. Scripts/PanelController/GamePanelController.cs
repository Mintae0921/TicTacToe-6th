using UnityEngine;
using UnityEngine.UI;
using static Constants;

public class GamePanelController : MonoBehaviour
{
    //[SerializeField] private Button backButton;
    //[SerializeField] private Button settingButton;

    //private void Start()
    //{
    //    backButton.onClick.AddListener(OnClickBackButton);
    //    settingButton.onClick.AddListener(OnClickSettingsButton);
    //}  // 버튼 자동 할당 방식

    [SerializeField] private Image playerATurnImage;
    [SerializeField] private Image playerBTurnImage;

    

    public void OnClickBackButton()
    {
        GameManager.Instance.OpenConfirmPanel("게임을 종료합니다.", () =>
        {
            GameManager.Instance.ChangeToMainScene();
        });

    }

    public void OnClickSettingsButton()
    {
        GameManager.Instance.OpenSettingsPanel();

    }

    public void SetPlayerTurnPanel(Constants.PlayerType playerTurnType)
    {
        switch (playerTurnType)
        {
            case Constants.PlayerType.None:
                playerATurnImage.color = Color.white;
                playerBTurnImage.color = Color.white;
                break;
            case Constants.PlayerType.Player1:
                playerATurnImage.color = Color.blue;
                playerBTurnImage.color = Color.white;
                break;
            case Constants.PlayerType.Player2:
                playerATurnImage.color = Color.white;
                playerBTurnImage.color = Color.blue;
                break;
        }

    }
}
