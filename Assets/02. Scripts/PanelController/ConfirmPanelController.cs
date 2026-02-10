using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanelController : PanelController
{
    [SerializeField] private TMP_Text messageText;

    public delegate void OnConfirmButtonClicked();
    public OnConfirmButtonClicked onConfirmButtonClicked;

    public void Show(string message, OnConfirmButtonClicked onConfirmButtonClicked = null)
    {
        this.onConfirmButtonClicked = onConfirmButtonClicked;
        messageText.text = message;
        Show();
    }

    // x 버튼 누르면
    public void OnClickCloseButton()
    {
        Hide(() =>
        {
            onConfirmButtonClicked.Invoke();

        });
    }
}