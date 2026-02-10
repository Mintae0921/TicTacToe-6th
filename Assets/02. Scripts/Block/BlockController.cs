using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;

    public delegate void OnBlockClicked(int index);
    public OnBlockClicked onBlockClicked;

    public void InitBlocks()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].InitMarker(i, blockIndex =>
            {
                onBlockClicked?.Invoke(blockIndex);
            });
        }
    }

    //특정 블럭에 마커 설정
    public void PlaceMarker(int blockIndex, Constants.PlayerType playerType)
    {
        Debug.Log($"PlaceMarker 호출됨: Index {blockIndex}, Player {playerType}");

        switch (playerType)
        {
            case Constants.PlayerType.Player1:
                blocks[blockIndex].SetMarker(Block.MarkerType.O);
                break;
            case Constants.PlayerType.Player2:
                blocks[blockIndex].SetMarker(Block.MarkerType.X);
                break;
        }

    }

}
