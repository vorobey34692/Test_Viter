using UnityEngine;

public class RaySelector : MonoBehaviour
{
    [SerializeField] private CellCreator _cellCreator;
    private Transform _targetCell;

    private void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0))
            if (Physics.Raycast(ray, out hit))
                CheckClick(ray, hit);

        if (_targetCell != null && Input.GetMouseButton(0))
            MoveLineElement(ray);

        if (!Input.GetMouseButton(0))
            _targetCell = null;
    }

    private void CheckClick(Ray ray, RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out LineElement lineElement))
            _targetCell = lineElement.transform;
    }

    private void MoveLineElement(Ray ray)
    {
        if (_targetCell != null && Input.GetMouseButton(0))
        {
            Plane plane = new Plane(-Vector3.forward, _targetCell.transform.position);
            plane.Raycast(ray, out float distance);
            _targetCell.transform.position = ray.GetPoint(distance);
        }
    }
}
