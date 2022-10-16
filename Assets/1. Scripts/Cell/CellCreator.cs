using UnityEngine;

public class CellCreator : MonoBehaviour
{
    [SerializeField] private GameCell _cellPrefab;
    [SerializeField] private Transform _start;
    [SerializeField] public int XSize { get; private set; } = 3;
    [SerializeField] public int YSize { get; private set; } = 3;
    [SerializeField] private LineElement _lineElementPrefab;
    [SerializeField] private CellManager _cellManager;

    private void Awake() => EventManager.Start += CreateCell;

    private void CreateCell()
    {
        for (int x = 0; x < XSize; x++)
        {
            for (int y = 0; y < YSize; y++)
            {
                GameCell newCell = Instantiate(_cellPrefab, new Vector3(_start.position.x + y, _start.position.y + x, _start.position.z), transform.rotation, _start);
                _cellManager.AddCellDictionary(x, y, newCell);
                newCell.AddPosition(x, y);
                CreateLineElement(newCell);
            }
        }
        EventManager.Start -= CreateCell;
    }

    private void CreateLineElement(GameCell gameCell)
    {
        if (gameCell.Position == new Vector2Int(1, 0) || gameCell.Position == new Vector2Int(1, 2))
        {
            LineElement newLineElement = Instantiate(_lineElementPrefab, gameCell.transform.position, gameCell.transform.rotation, gameCell.transform);
            gameCell.MakeCell(newLineElement, gameCell);
            newLineElement.Disable();
        }
    }
}
