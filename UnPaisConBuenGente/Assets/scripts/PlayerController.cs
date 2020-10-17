﻿using System.Collections;
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
    public Image energia;

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
                shootForce += Time.deltaTime * 10;
            }

            energia.gameObject.SetActive(true);
            energia.transform.localScale = new Vector3(shootForce/20, 1, 1);
        }

        if (Input.GetButtonUp(commandShoot))
        {
            energia.gameObject.SetActive(false);
            WeaponSet weps = controller.currentWeapon.GetComponent<WeaponSet>();
            weps.Shoot(shootForce);
            shootForce = 0;
        }
    }
}
