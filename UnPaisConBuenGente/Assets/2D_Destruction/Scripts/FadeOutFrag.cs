using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutFrag : MonoBehaviour
{
    private Color alphaColor;
    private float timeToFade = 2f;
    private float timeToDestroy = 2f;

    private void Start()
    {
        alphaColor = this.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;
    }
   
    void OnEnable()
    {
       
        //Debug.Log("PrintOnEnable: script was enabled");
    }

    public void Update()
    {
        
            this.GetComponent<MeshRenderer>().material.color = Color.Lerp(this.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);


        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 1.5f) this.GetComponent<PolygonCollider2D>().enabled = false;
        if (timeToDestroy <= 0)
                {
                Destroy(this.gameObject);
             }
        
    }
}
