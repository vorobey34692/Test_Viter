using UnityEngine;

public class Cell : MonoBehaviour
{
    private Transform _cubePlace;
    [field: SerializeField] public bool IsFull { get; private set; }
    private CellManager _cellManager;

    public void Inicialization(bool isFull, Transform cubePlace, CellManager cellManager = null)
    {
        IsFull = isFull;
        _cubePlace = cubePlace;
        _cellManager = cellManager;
    }

    public virtual void ConnectLineElement(LineElement lineElement)
    {
        lineElement.transform.position = _cubePlace.position;
        lineElement.transform.parent = transform;
    }

    public virtual void MakeCell(LineElement lineElement, Cell cell)
    {
        lineElement.Disable();
        cell.IsFull = true;
    }

    public void ClearCell()
    {
        IsFull = false;
    }
}
