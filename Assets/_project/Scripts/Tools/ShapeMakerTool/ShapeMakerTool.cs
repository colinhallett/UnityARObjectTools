using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMakerTool : Tool
{
    #region Variables

    [Header("Component references")]
    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private PlacementHelper placementIndicator;
    
    [SerializeField] private GameObject uiPanel;

    [Header("Materials")]
    [SerializeField] private Material ghostShapeMaterial;

    private GhostShape ghostShape;

    private ShapeFactory shapeFactory;
    private ShapeSpawner shapeSpawner;

    private GameObject objectToSpawn;
    private Quaternion objectRotation;

    #endregion

    #region Unity Methods

    private void Start()
    {
        shapeFactory = GetComponent<ShapeFactory>();
        shapeSpawner = GetComponent<ShapeSpawner>();
        SelectShape(0);

        Deactivate();
    }
    private void Update()
    {
        if (IsActive)
            ghostShape.UpdatePosition(placementIndicator.DropPosition);
    }

    #endregion

    #region Tool

    public override void Activate()
    {
        IsActive = true;

        ghostShape.SetRendererActive(true);
        uiPanel.SetActive(true);
        placementIndicator.Activate();
    }

    public override void Deactivate()
    {
        IsActive = false;

        ghostShape.SetRendererActive(false);
        uiPanel.SetActive(false);
        placementIndicator.Deactivate();
    }

    #endregion

    #region Public Methods
    public void AddShape()
    {
        var newShape = shapeSpawner.SpawnShape(objectToSpawn, ghostShape.transform.position, objectRotation);
        objectManager.AddObject(newShape);
    }
    public void RotateLeft()
    {
        RotateShapes(Vector3.up, -10f);
    }

    public void RotateRight()
    {
        RotateShapes(Vector3.up, 10f);
    }

    public void SelectShape(int shapeIndex)
    {
        var shapeGO = shapeFactory.GetShape(shapeIndex);
        objectToSpawn = shapeGO;

        if (ghostShape != null) Destroy(ghostShape.gameObject);

        ghostShape = Instantiate(objectToSpawn, placementIndicator.DropPosition + Vector3.up * 0.05f, objectRotation).AddComponent<GhostShape>();
        ghostShape.InitialiseShape(ghostShapeMaterial);
        
    }

    #endregion

    #region Private Methods

    private void RotateShapes(Vector3 axis, float amount)
    {
        ghostShape.transform.Rotate(axis, amount);
        objectRotation = ghostShape.transform.localRotation;
    }

    #endregion 


}
