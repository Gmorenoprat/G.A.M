﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSet : MonoBehaviour
{
    public float shootForce;
    float avShoot = 1;
    bool exp = false;
    public Rigidbody2D rb;
    public GameObject explotionRad;
    public GameObject explotionAnim;
    SpriteRenderer bulletSprite;
    public bool thisMolo;
    public GameObject[] spawns;
    public List<GameObject> explotions;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bulletSprite = this.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(avShoot > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * shootForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
            avShoot--;
        }
        this.transform.up = rb.velocity.normalized;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        bulletSprite.color = new Color(0,0,0,0);

        if (!exp && thisMolo==false)
        {
            GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            newExplotionAnim.transform.position = this.transform.position;
            GameObject newExplotion = GameObject.Instantiate(explotionRad);
            newExplotion.transform.position = this.transform.position;
            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);
            GameObject.Destroy(newExplotion.gameObject, 0.2f);
        }
        else if (!exp && thisMolo == true)
        {
            //GameObject newExplotionAnim = GameObject.Instantiate(explotionAnim);
            //newExplotionAnim.transform.position = this.transform.position;

            for(int i = 0; i < spawns.Length; i++)
            {
                GameObject newExplotion = GameObject.Instantiate(explotionRad);
                newExplotion.transform.position = spawns[i].transform.position;
                explotions.Add(newExplotion);
            }


            exp = true;
            GameObject.Destroy(this.gameObject, 0.2f);

            foreach(GameObject explotion in explotions)
            {
                GameObject.Destroy(explotion.gameObject, 2f);
            }
        }
    }
}
