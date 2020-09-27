using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granada : MonoBehaviour
{
    public float shootForce;
    public float explotionTime;
    bool exp = false;
    public GameObject explotionRad;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (explotionTime <= 0 && !exp)
        {
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = this.transform.position;
            exp = true;
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
            GameObject.Destroy(this.gameObject, 0.2f);
        }
        explotionTime -= Time.deltaTime;
    }

}
