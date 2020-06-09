using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{

    [SerializeField] private List<Tool> tools = new List<Tool>();

    private List<Tool> activeTools = new List<Tool>();
    private void Start()
    {
       
    }

    public void ActivateTool(int index)
    {
        foreach (var tool in activeTools)
        {
            tool.Deactivate();
        }
        activeTools.Clear();

        for (int i = 0; i < tools.Count; i++)
        {
            if (i == index)
            {
                activeTools.Add(tools[i]);
                tools[i].Activate();
            }
            else
                tools[i].Deactivate();
        }
    }
}
