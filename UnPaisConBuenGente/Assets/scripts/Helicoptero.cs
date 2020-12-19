using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helicoptero : MonoBehaviour
{
    public Fondo_loop sky;
    public int direcction;
    public Vector2 spawn;
    public bool player;
    public float velocidadNube = 5f;

    public SpriteRenderer sRend;

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

        player = GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnMananger>().esPlayer1;
        GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnMananger>().ret = true;
    }

    void Update()
    {
        transform.position += new Vector3(velocidadNube * -direcction, 0) * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
       if(player == true)
        {
            SceneManager.LoadScene("winner gorila");
        }
       else if(player == false)
        {
            SceneManager.LoadScene("winner pinguin");
        }
        GameObject.Destroy(this.gameObject, 1);
    }
}
