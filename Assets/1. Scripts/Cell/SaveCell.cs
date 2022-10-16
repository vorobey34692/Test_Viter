using UnityEngine;

public class SaveCell : Cell
{
    [SerializeField] private Transform _cubePlace;
    private bool IsFull;

    private void Start()
    {
        Inicialization(IsFull, _cubePlace);
    }

    public override void MakeCell(LineElement lineElement, Cell cell)
    {
        IsFull = true;
    }

    public override void ConnectLineElement(LineElement lineElement)
    {
        base.ConnectLineElement(lineElement);
        MakeCell(lineElement, this);
    }
}
