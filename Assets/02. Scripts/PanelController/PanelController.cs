using DG.Tweening;
using System.Transactions;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private RectTransform panelTransform;

    public delegate void PanelControllerHideDelegate();

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void Show()
    {
        canvasGroup.alpha = 0;
        panelTransform.localScale = Vector3.zero;

        canvasGroup.DOFade(1, 0.3f).SetEase(Ease.Linear);
        panelTransform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    public void Hide(PanelControllerHideDelegate onComplete = null)
    {
        canvasGroup.DOFade(0, 0.3f).SetEase(Ease.Linear);
        panelTransform.DOScale(0, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            onComplete?.Invoke();
            Destroy(gameObject);
        });

    }
}
