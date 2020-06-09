using UnityEngine;
using System.Collections;

public abstract class Tool : MonoBehaviour
{
    public abstract void Activate();
    public abstract void Deactivate();

    public bool IsActive { get; set; }
}
