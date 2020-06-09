using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShape : MonoBehaviour
{
    #region Variables
    
    private MeshRenderer meshRenderer;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    #endregion

    #region Public Methods

    public void Rotate(Vector3 up, float amount)
    {
        transform.Rotate(up, amount);
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        Vector3 newPos = new Vector3(newPosition.x, newPosition.y + 0.05f, newPosition.z);
        transform.position = newPosition;
    }

    public void UpdateRotation(Quaternion newRotation)
    {
        transform.localRotation = newRotation;
    }

    public void SetRendererActive(bool active)
    {
        meshRenderer.enabled = active;
    }

    internal void InitialiseShape(Material material)
    {
        Destroy(GetComponent<Rigidbody>());
        GetComponent<Collider>().isTrigger = true;
        GetComponent<MeshRenderer>().sharedMaterial = material;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    #endregion
}
