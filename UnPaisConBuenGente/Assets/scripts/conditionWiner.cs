using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class conditionWiner : DestroyableComp
{
    public GameObject[] gorila;
    public GameObject[] pinguins;
    public int totalLifeGorila;
    public int totalLifePinguin;
    public int playersNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // totalLifeGorila = life / playersNumber ;

       // totalLifeGorila = life / playersNumber;

        if(totalLifeGorila >= 0)
        {
            SceneManager.LoadScene("winner pinguin");
        }

        if (totalLifeGorila >= 0)
        {
            SceneManager.LoadScene("winner gorila");
        }
    }
}
