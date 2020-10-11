// observer.cs
// by Dave Pape, 8 Oct 2020
//
// Example of a script that accesses data from another script.
// The "objScript" attribute should be assigned to point to an object that
// has a mydata.cs script attached to it.
// This script should be attached to a TextMeshPro object, to display the
// mydata script's "value" variable.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class observer : MonoBehaviour
{
    public mydata objScript;
    private TextMeshProUGUI textMesh;
    
    void Start()
        {
        textMesh = GetComponent<TextMeshProUGUI>();
        }

    void Update()
        {
        int t = (int) Time.time;
        int val = (int) objScript.value;
        textMesh.text = $"Time: {t}  Value: {val}";
        if (val > 9000)
            textMesh.text += " !!!!!!!!";
        }
}
