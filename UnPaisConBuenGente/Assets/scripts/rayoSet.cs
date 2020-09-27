using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayoSet : MonoBehaviour
{
    public float cont;

    void Update()
    {
        if (cont <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
        cont -= Time.deltaTime;
    }
}
