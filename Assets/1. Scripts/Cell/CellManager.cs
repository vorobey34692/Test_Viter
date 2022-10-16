using UnityEngine;
using System.Collections.Generic;

public class CellManager : MonoBehaviour
{
    [SerializeField] private CellCreator _cellCreator;
    public Dictionary<Vector2Int, GameCell> _cellsDictionary { get; private set; } = new Dictionary<Vector2Int, GameCell>();

    public void AddCellDictionary(int x, int y, GameCell cell) => _cellsDictionary.Add(new Vector2Int(x, y), cell);

    public void DelitedFullLines()
    {
        bool[] line = new bool[3];
        GameCell[] lineIsFull = new GameCell[3];

        for (int y = 0; y < 3; y++)
        {
            bool isFull = true;
            for (int x = 0; x < 3; x++)
            {
                GameCell cell = _cellsDictionary[new Vector2Int(y, x)];
                if (!cell.IsFull)
                    isFull = false;
                else
                    lineIsFull[x] = cell;
            }

            if (isFull)
            {
                line[y] = true;
                for (int i = 0; i < lineIsFull.Length; i++)
                {
                    Destroy(lineIsFull[i].transform.GetChild(2).gameObject);
                    lineIsFull[i].ClearCell();
                }
            }
            if (y == 2)
                CheckWin(line);
        }
    }

    private void CheckWin(bool[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i])
                EventManager.OnWin();
        EventManager.OnLoose();
    }
}
