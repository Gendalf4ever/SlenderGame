using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    /*
    [SerializeField] private Camera _fpsCamera;
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private float _maxDistanceRay;
    private void Update() //need Fixed Update
    {
        Ray();
        DrawRay();
        //Interactive();
    }
    private void Ray() {
        _ray = _fpsCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, color: Color.blue);
        }

        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, color: Color.red);
        }
    }

    
    private void Interactive()
    {
        if (_hit.transform.GetComponent<DoorAnimation>())
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, color: Color.green);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _hit.transform.GetComponent<DoorAnimation>().Open();
            }
        }
    }
    */
}
