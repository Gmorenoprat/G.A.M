﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterSet controller;
    public string axisHorizontal, commandJump, commandShoot;
    Camera mainCamera;
    public Vector3 mouseWorldPosition;
    public Vector3 mousePosition;
    public float shootForce;
    public bool yaDisparo = false;
    //public Image energia;
    public GameObject energia;
    

    void Start()
    {
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
            
            yaDisparo = true;
            //desactivar movimiento? testear...
            this.enabled = false;
        }
    }
}
