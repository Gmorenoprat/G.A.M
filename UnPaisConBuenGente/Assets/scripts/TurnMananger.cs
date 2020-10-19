using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Lang;

public class TurnMananger : MonoBehaviour
{
    public GameObject[] player1Characters;
    public GameObject[] player2Characters;

    public GameObject activeCharacter;

    public bool esPlayer1;

    public int posA;
    public int posB;



    private void Start()
    {
        foreach (GameObject player in player1Characters)
        {
            desactivarCharacter(player);
        }
        foreach (GameObject player in player2Characters)
        {
            desactivarCharacter(player);
        }

        var empiezaP1 = (Random.value < 0.5);
        if (empiezaP1)
        {
            activarCharacter(player1Characters[posA]);
            esPlayer1 = true;
        }
        else
        {
            activarCharacter(player2Characters[posB]);
            esPlayer1 = false;
        }

    }

    private void Update()
    {
        if (activeCharacter.GetComponent<PlayerController>().yaDisparo == true)
        {
            cambiarTurno();
        }
    }

    private void cambiarTurno()
    {

        //si esPlayer1 lo desactiva (pasa turno)
        if (esPlayer1)
        {
            desactivarCharacter(player1Characters[posA]);
            activarCharacter(player2Characters[posB]);
            setCamera(player2Characters[posB]);
            posA += 1;
            posA = posA % player1Characters.Length;
        }
        if (!esPlayer1)
        {
            activarCharacter(player1Characters[posA]);
            setCamera(player1Characters[posA]);
            desactivarCharacter(player2Characters[posB]);
            posB += 1;
            posB = posB % player2Characters.Length;
        }
        esPlayer1 = !esPlayer1;
    }


    private void activarCharacter(GameObject character) {
        character.GetComponent<PlayerController>().enabled = true;
        character.GetComponent<CharacterSet>().enabled = true;
        activeCharacter = character;
        activeCharacter.GetComponent<PlayerController>().yaDisparo = false;
    }
    private void desactivarCharacter(GameObject character)
    {
        character.GetComponent<PlayerController>().enabled = false;
        character.GetComponent<CharacterSet>().enabled = false;
    }

    private void setCamera(GameObject character)
    {
        Vector3 posPlayer = character.transform.position;
        posPlayer.z = -40;
        Camera.main.transform.position = posPlayer;
    }



}
