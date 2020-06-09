using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using System;

public class PlacementHelper : Tool
{
    #region Variables

    [Header("Component References")]
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private Transform visual;
    [SerializeField] private RaycastHelper raycastHelper;

    public Vector3 DropPosition { get; private set; }

    #endregion

    #region Tool
    public override void Activate()
    {
        IsActive = true;
        visual.gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        IsActive = false;
        visual.gameObject.SetActive(false);
    }

    #endregion

    #region Unity Methods

    private void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Update()
    {
        if (!IsActive) return;

        Ray ray = raycastHelper.GetRayFromCenterScreen();

        if (CheckForGameObjectHit(ray)) return;

        var hits = CheckForARRaycastHit();
        HandleARRaycastHit(hits);
    }

    #endregion

    #region Helper Methods

    private bool CheckForGameObjectHit(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            HandleGameObjectHit(raycastHit);
            return true;
        } else
        {
            return false;
        }
    }

    private void HandleGameObjectHit(RaycastHit raycastHit)
    {
        visual.position = raycastHit.point + Vector3.up * 0.01f;
        visual.localRotation = Quaternion.Euler(raycastHit.normal);
        DropPosition = visual.position;
    }

    private List<ARRaycastHit> CheckForARRaycastHit()
    {
        //shoot raycast from centre of screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(
            new Vector2(Screen.width / 2, Screen.height / 2),
            hits,
            TrackableType.Planes);
        return hits;
    }

    private void HandleARRaycastHit(List<ARRaycastHit> hits)
    {
        if (hits.Count > 0)
        {
            visual.position = hits[0].pose.position + Vector3.up * 0.01f;
            DropPosition = visual.position;
        }
    }

    #endregion
}
