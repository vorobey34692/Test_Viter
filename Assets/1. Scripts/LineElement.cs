using UnityEngine;

public class LineElement : MonoBehaviour
{
    private BoxCollider _lineElementCollider;
    private Cell _targetCell;
    private Vector3 _startPosition;
    private bool _isSelected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _startPosition = transform.position;

        if (_isSelected)
        {
            if (Input.GetMouseButtonUp(0))
                _targetCell.ConnectLineElement(this);
        }
        else if (!_isSelected)
            if (Input.GetMouseButtonUp(0))
                transform.position = _startPosition;
    }

    public void Disable()
    {
        _lineElementCollider = GetComponent<BoxCollider>();
        _lineElementCollider.enabled = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Cell cell))
        {
            _isSelected = true;
            _targetCell = cell;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!_isSelected) return;
        if (collision.transform.TryGetComponent(out Cell cell))
            _isSelected = false;
    }
}
