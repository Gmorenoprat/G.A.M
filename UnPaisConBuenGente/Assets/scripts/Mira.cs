using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    Vector3 thisPos, mousePos, mousePosInWorld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = thisPos;
        mousePos = Input.mousePosition;
        mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePos);
        thisPos = mousePosInWorld;
        thisPos.z = 0;
    }
}
