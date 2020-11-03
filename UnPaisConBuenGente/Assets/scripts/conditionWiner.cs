using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class conditionWiner : MonoBehaviour
{
    public GameObject[] gorila;
    public GameObject[] pinguins;
    public int totalMemberGorila;
    public int totalMemberPinguin;
   

    private void Start()
    {
        totalMemberGorila = gorila.Length;
        totalMemberPinguin = pinguins.Length;
    }
    public void lifeDown(GameObject objet)
    {
        for (int i = 0; i < gorila.Length; i++)
        {
            if (gorila != null)
            {


                if (gorila[i] == objet)
                {
                    totalMemberGorila--;
                    if (totalMemberGorila <= 0)
                    {
                        SceneManager.LoadScene("winner pinguin");
                    }
                    return;
                }
            }
        }
        for (int i = 0; i < pinguins.Length; i++)
        {
            if (pinguins != null)
            {


                if (pinguins[i] == objet)
                {
                    totalMemberPinguin--;
                    if (totalMemberPinguin <= 0)
                    {
                        SceneManager.LoadScene("winner gorila");
                    }
                    return;
                }
            }
        }


    }
}
