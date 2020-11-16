using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    Vector3 thisPos, mousePos, mousePosInWorld;
    SpriteRenderer spMira;

    private void Awake()
    {
        spMira = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = thisPos;
        mousePos = Input.mousePosition;
        mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePos);
        thisPos = mousePosInWorld;
        thisPos.z = 0;
        Cursor.visible = false;
    }

    public void desactivarPorSegundos(float segundos)
    {
        StartCoroutine(desactivarPorSegundosCoroutine(segundos));
    }
    public IEnumerator desactivarPorSegundosCoroutine(float segundos)
    {
        spMira.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(segundos);
        spMira.color = new Color(255, 255, 255, 255);
        yield break;
    }
}
