using UnityEngine;
using static Constants;

public class GamePanelController : MonoBehaviour
{
    private void Start()
    {
        
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
