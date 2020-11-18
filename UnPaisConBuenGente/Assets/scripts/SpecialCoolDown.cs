using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoolDown : MonoBehaviour
{
    public int coolDownConsigna;
    public int coolDown;

    void Start()
    {
        coolDown = coolDownConsigna;
    }

    void Update()
    {
        if(coolDown <= 0)
        {
            gameObject.GetComponent<CharacterSet>().permission = true;
        }
    }
}
