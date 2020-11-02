using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoVolador : MonoBehaviour
{
    private Transform compTransform;
    public float speedRot;
    public string axisHorizontal;

    public float shootForce;
    bool exp = false;
    public Rigidbody2D rb;
    public GameObject explotionRad;
    public GameObject explotionAnim;
    SpriteRenderer gatoSprite;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        compTransform = this.GetComponent<Transform>();
        gatoSprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * shootForce * 1.2f;
        compTransform.Rotate(0, 0, -speedRot * Time.deltaTime * Input.GetAxis(axisHorizontal));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gatoSprite.color = new Color(0, 0, 0, 0);

        if (exp == false)
        {
            GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            newExplotionAnim.transform.position = this.transform.position;
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = this.transform.position;
            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
        }
    }
}
