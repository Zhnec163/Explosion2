using UnityEngine;

public class FissileCubeClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.TryGetComponent(out FissileCube fissileCube))
            {
                fissileCube.ProcessClick();
            }
        }
    }
}