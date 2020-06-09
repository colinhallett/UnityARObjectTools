using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastHelper : MonoBehaviour
{
    [SerializeField] new Camera camera;

    public Ray GetRayFromCenterScreen()
    {
        return camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
    }

    public Ray GetRayFromScreenPoint(Vector3 point)
    {
        return camera.ScreenPointToRay(point);
    }

}
