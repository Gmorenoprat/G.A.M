using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestorCloud : MonoBehaviour
{

    public Fondo_loop sky;
    public int direcction;
    public Vector2 spawn;

    public float velocidadNube = 5f;
    
    public float tiempoSpawnChorisMax = 2f;
    public float tiempoSpawnChoris = 2f;

    public SpriteRenderer sRend;

    public GameObject chori;

    private void Awake()
    {
        sky = GameObject.FindGameObjectWithTag("Sky").GetComponent<Fondo_loop>();
    }
    void Start()
    {

        if (sky.speed > 0) direcction = 1;
        else direcction = -1;

        if (direcction < 0) spawn = new Vector2(-56f, 15f);
        else spawn = new Vector2(23f, 15f);

        this.transform.position = spawn;

        sRend = this.GetComponent<SpriteRenderer>();
        if (direcction > 0) sRend.flipX = true;
    }
    void Update()
    {
       transform.position += new Vector3(velocidadNube * -direcction, 0) * Time.deltaTime;

        if(tiempoSpawnChoris < 0)
        {

            GameObject newChori = GameObject.Instantiate(chori);
            Choripan choripan = newChori.GetComponent<Choripan>();
            choripan.transform.position = this.transform.position;
            tiempoSpawnChoris = tiempoSpawnChorisMax;
        }
        tiempoSpawnChoris -= Time.deltaTime;
    }
}
