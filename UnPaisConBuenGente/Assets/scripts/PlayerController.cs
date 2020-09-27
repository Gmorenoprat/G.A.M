using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterSet controller;
    public string axisHorizontal, commandJump, commandShoot;
    Camera mainCamera;
    public Vector3 mouseWorldPosition;
    public Vector3 mousePosition;

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

        if (Input.GetButtonDown(commandShoot))
        {
            WeaponSet weps = controller.currentWeapon.GetComponent<WeaponSet>();
            weps.Shoot();
        }
    }
}
