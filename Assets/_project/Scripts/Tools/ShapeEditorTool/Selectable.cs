using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [SerializeField] private Material highlightedMaterial;

    private Material defaultMaterial;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    public void Select(ShapeEditorTool shapeEditorTool)
    {
        meshRenderer.material = highlightedMaterial;

        shapeEditorTool.MoveForwardPressed += MoveForward;
        shapeEditorTool.MoveBackwardsPressed += MoveBack;
        shapeEditorTool.MoveLeftPressed += MoveLeft;
        shapeEditorTool.MoveRightPressed += MoveRight;
        shapeEditorTool.RotateLeftPressed += RotateLeft;
        shapeEditorTool.RotateRightPressed += RotateRight;
    }

    public void Deselect(ShapeEditorTool shapeEditorTool)
    {
        meshRenderer.material = defaultMaterial;
        shapeEditorTool.MoveForwardPressed -= MoveForward;
        shapeEditorTool.MoveBackwardsPressed -= MoveBack;
        shapeEditorTool.MoveLeftPressed -= MoveLeft;
        shapeEditorTool.MoveRightPressed -= MoveRight;
        shapeEditorTool.RotateLeftPressed -= RotateLeft;
        shapeEditorTool.RotateRightPressed -= RotateRight;
    }

    public void MoveForward()
    {
        Move(transform.forward * 0.02f);
    }

    public void MoveBack()
    {
        Move(transform.forward * -0.02f);
    }

    public void MoveLeft()
    {
        Move(transform.right * -0.02f);
    }

    public void MoveRight()
    {
        Move(transform.right * 0.02f);
    }

    public void RotateLeft()
    {
        Rotate(transform.up, -10f);
    }

    public void RotateRight()
    {
        Rotate(transform.up, 10f);
    }

    private void Move(Vector3 amount)
    {
        transform.position += amount;
    }

    private void Rotate(Vector3 axis, float amount)
    {
        transform.Rotate(axis, amount);
    }


}
