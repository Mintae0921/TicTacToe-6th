using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite oSprite;
    [SerializeField] private Sprite xSprite;
    [SerializeField] private SpriteRenderer markerSpriteRenderer;

    public enum MarkerType { None, O, X }

    private int _blockIndex;

    public delegate void OnBlockClicked(int index);
    private OnBlockClicked _onBlockClicked;
    // 블록 초기화
    public void InitMarker(int blockIndex, OnBlockClicked onBlockClicked)
    {
        _blockIndex = blockIndex;
        SetMarker(MarkerType.None);

        Debug.Log("Block Initialized: " + _blockIndex);
        
        //클릭 롤백 설정
        _onBlockClicked = onBlockClicked;
    }

    // 마커 설정
    public void SetMarker(MarkerType markerType)
    {
        Debug.Log($"Block SetMarker: {markerType}");
        switch (markerType)
        {
            case MarkerType.O:
                markerSpriteRenderer.sprite = oSprite;
                break;
            case MarkerType.X:
                if (xSprite == null) Debug.LogError("X Sprite가 할당되지 않았습니다!");
                markerSpriteRenderer.sprite = xSprite;
                break;
            case MarkerType.None:
                markerSpriteRenderer.sprite = null;
                break;
        }

    }


    private void OnMouseUpAsButton()
    {

        Debug.Log("Block Clicked " + _blockIndex);

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        _onBlockClicked?.Invoke(_blockIndex);
    }

}
