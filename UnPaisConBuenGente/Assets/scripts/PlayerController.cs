using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterSet controller;
    public string axisHorizontal, commandJump, commandShoot;
    Camera mainCamera;

    public SpriteRenderer spriteRend;
    public SpriteRenderer cabezaSRend;

    public Vector3 mouseWorldPosition;
    public Vector3 mousePosition;
    public float shootForce;
    public bool yaDisparo = false;
    public GameObject energia;

    public GameObject randomSpots;


    private void Awake()
    {
        try
        {
            randomSpots = GameObject.FindGameObjectsWithTag("SpotGenerator")[0];
            RandomSpotSpawnHorizontal randoms = randomSpots.GetComponent<RandomSpotSpawnHorizontal>();
            this.transform.position = randoms.getSpawn();
        }
        catch { Debug.Log("NoHaySpawner"); }
    }

    void Start()
    {
        spriteRend = this.GetComponent<SpriteRenderer>();
        controller = this.GetComponent<CharacterSet>();


       

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 100;
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0;
        controller.currentWeapon.transform.up = mouseWorldPosition - controller.currentWeapon.transform.position;

        controller.Move(Input.GetAxis(axisHorizontal));

        if (Input.GetButtonDown(commandJump))
        {
            controller.Jump();
        }

     
      

        if (Input.GetButton(commandShoot))
        {
            if(shootForce <= 20)
            {
                shootForce += Time.deltaTime * 18;
            }

            energia.gameObject.SetActive(true);
            energia.transform.localScale = new Vector3(shootForce/40, 0.4f, 0.5f);
        }

        if (Input.GetButtonUp(commandShoot))
        {
            energia.gameObject.SetActive(false);
            WeaponSet weps = controller.currentWeapon.GetComponent<WeaponSet>();
            weps.Shoot(shootForce);
            shootForce = 0;

            yaSeDisparo();
            //desactivar movimiento? testear...
            this.enabled = false;
            controller.enabled = false;
        }

        flipRenderer((mouseWorldPosition - transform.position).x <= 0);

    }

    public void yaSeDisparo()
    {
        yaDisparo = true;
        controller.ActivarDesactivarBuitre(false);
    }

    public void flipRenderer(bool flip)
    {
        spriteRend.flipX = flip;
        cabezaSRend.flipX = flip;
        controller.currentWeapon.GetComponent<SpriteRenderer>().flipX = !flip;

    }
}
