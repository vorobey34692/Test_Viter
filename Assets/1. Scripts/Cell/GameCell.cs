using UnityEngine;

public class GameCell : Cell
{
    [SerializeField] private Transform _cubePlace;
    private CellManager _cellManager;
    public Vector2Int Position { get; private set; }
    private bool IsFull;

    private void Awake()
    {
        _cellManager = FindObjectOfType<CellManager>();
        Inicialization(IsFull, _cubePlace, _cellManager);
    }

    public override void ConnectLineElement(LineElement lineElement)
    {
        base.ConnectLineElement(lineElement);
        MakeCell(lineElement, this);
        _cellManager.DelitedFullLines();
    }

    public void AddPosition(int x, int y)
    {
        Position = new Vector2Int(x, y);
    }
}
