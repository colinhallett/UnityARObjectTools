using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShapeEditorTool : Tool
{
    #region Variables

    [SerializeField] private SelectionHelper selectionHelper;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private ObjectManager objectManager;

    private Selectable currentSelectable;
    #endregion

    #region Button callbacks

    public Action MoveForwardPressed;
    public Action MoveBackwardsPressed;
    public Action MoveLeftPressed;
    public Action MoveRightPressed;
    public Action RotateLeftPressed;
    public Action RotateRightPressed;
    public Action DeleteButtonPressed;

    #endregion

    #region Tool

    public override void Activate()
    {
        IsActive = true;
        selectionHelper.Activate();
        uiPanel.SetActive(true);
    }

    public override void Deactivate()
    {
        IsActive = false;
        DeselectCurrent();
        selectionHelper.Deactivate();
        uiPanel.SetActive(false);
    }

    #endregion

    #region Unity Methods

    private void Update()
    {
        if (!IsActive) return;

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            HighlightSelectable(selectionHelper.CheckSelection(Input.touches[0]));
        }
    }
    #endregion

    #region Public Methods

    public void MoveForward()
    {
       MoveForwardPressed?.Invoke();
    }

    public void MoveBack()
    {
        MoveBackwardsPressed?.Invoke();
    }

    public void MoveLeft()
    {
        MoveLeftPressed?.Invoke();
    }

    public void MoveRight()
    {
        MoveRightPressed?.Invoke();
    }

    public void RotateLeft()
    {
        RotateLeftPressed?.Invoke();
    }

    public void RotateRight()
    {
        RotateRightPressed?.Invoke();
    }

    public void DeleteCurrent()
    {
        if (currentSelectable != null)
        {
            objectManager.RemoveObject(currentSelectable.gameObject);
            currentSelectable = null;
            DeleteButtonPressed?.Invoke();
        }
        
    }

    #endregion

    #region Private Methods

    private void HighlightSelectable(GameObject gameObject)
    {
        Selectable selectable = gameObject.GetComponent<Selectable>();

        if (selectable != null)
        {
            if (currentSelectable == selectable)
            {
                DeselectCurrent();
                return;
            }

            if (currentSelectable != null)
                DeselectCurrent();

            currentSelectable = selectable;
            currentSelectable.Select(this);

        } 
    }

    private void DeselectCurrent()
    {
        if (currentSelectable != null)
            currentSelectable.Deselect(this);
        currentSelectable = null;
    }

    #endregion
}
