using UnityEngine;

public class CellCreator : MonoBehaviour
{
    [SerializeField] private GameCell _cellPrefab;
    [SerializeField] private Transform _start;
    [SerializeField] private int _xSize = 3;
    [SerializeField] private int _ySize = 3;
    [SerializeField] private LineElement _lineElementPrefab;
    [SerializeField] private CellManager _cellManager;

    private void Awake()
    {
        EventManager.Start += CreateCell;
    }

    private void CreateCell()
    {
        for (int x = 0; x < _xSize; x++)
        {
            for (int y = 0; y < _ySize; y++)
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
