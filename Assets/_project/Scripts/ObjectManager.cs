using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private List<GameObject> allGameObjects;

    private void Start()
    {
        allGameObjects = new List<GameObject>();
    }

    public void AddObject(GameObject gameObject)
    {
        allGameObjects.Add(gameObject);
    }

    public void RemoveObject(GameObject gameObject)
    {
        allGameObjects.Remove(gameObject);
        Destroy(gameObject);
    }

    public void DestroyAllShapes()
    {
        
        foreach (var gameObject in allGameObjects)
        {
            Destroy(gameObject);
        }
        allGameObjects.Clear();
    }
}
