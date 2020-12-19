using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Retirada : MonoBehaviour
{
    public TextMeshProUGUI contador;
    public float cont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cont -= Time.deltaTime;
        if(cont <= 0)
        {
            cont = 0;
        }
        contador.text = "TOMÁNDOSE EL PALO EN... " + Mathf.Round(cont);
    }
}
