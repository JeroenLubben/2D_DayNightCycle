using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour {

    public Gradient gradient;

    private void Update()
    {
        Debug.Log(gradient.colorKeys);
    }
}
