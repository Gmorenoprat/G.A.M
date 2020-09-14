using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granada : MonoBehaviour
{
    public float explotionTime, destroyTime;
    public GameObject explotionRad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (explotionTime <= 0)
        {
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = this.transform.position;
            newExplotion.layer = this.gameObject.layer;

            GameObject.Destroy(newExplotion.gameObject);
            GameObject.Destroy(this.gameObject);
        }
        explotionTime -= Time.deltaTime;
    }
}
