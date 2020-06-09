using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    #region Public methods

    public GameObject SpawnShape(GameObject objectToSpawn, Vector3 position, Quaternion rotation)
    {
        return Instantiate(objectToSpawn, position, rotation);
    }

    #endregion
}
