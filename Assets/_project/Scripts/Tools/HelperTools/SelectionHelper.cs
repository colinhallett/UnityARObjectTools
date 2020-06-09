using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionHelper : Tool
{
    [SerializeField] RaycastHelper raycastHelper;

    public override void Activate()
    {
        IsActive = true;
    }

    public override void Deactivate()
    {
        IsActive = false;
    }

    public GameObject CheckSelection(Touch touch)
    {
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return null;
        }

        var ray = raycastHelper.GetRayFromScreenPoint(touch.position);
        if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity))
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    
}
