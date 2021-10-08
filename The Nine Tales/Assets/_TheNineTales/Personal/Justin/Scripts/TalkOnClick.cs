using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class TalkOnClick : MonoBehaviour
{
    public Flowchart flowchart;
    
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        flowchart.ExecuteBlock("Dialogue");
    }
}
