using UnityEngine;
using System.Collections;

public class ShapeFactory : MonoBehaviour
{
    public GameObject[] shapes;

    public GameObject GetShape(int shapeIndex)
    {
        return shapes[shapeIndex];
    }
}
