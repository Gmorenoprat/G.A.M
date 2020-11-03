using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TurnMananger : MonoBehaviour
{
    public List<GameObject> player1Characters;
    public List<GameObject> player2Characters;

    public GameObject activeCharacter;

    public bool esPlayer1;

    public int posA;
    public int posB;

    public float timeEspera = 5f;

    public Fondo_loop fondo;
    public menuArmas menu_armas;



    private void Start()
    {
        
         desactivarCharacters();

        posA = Random.Range(0, player1Characters.Count);
        posB = Random.Range(0, player2Characters.Count);
        
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
        if (activeCharacter != null)
        {
            if(activeCharacter.GetComponent<PlayerController>().yaDisparo == true) { 
                timeEspera -= Time.deltaTime;
                if (timeEspera <= 0)
                {
                    cambiarTurno();
                    timeEspera = 5f;
                }
            }
        }
        else { timeEspera = 5f;  cambiarTurno(); }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cambiarTurno();
        }
    }

    private void cambiarTurno()
    {
        if (fondo != null) fondo.ChangeRandomDirectionSpeed();
        desactivarCharacters();

        //si esPlayer1 lo desactiva (pasa turno)
        if (esPlayer1)
        {
            posA += 1;
            posA = posA % player1Characters.Count;
            try
            {activarCharacter(player2Characters[posB]);}
            catch
            {player2Characters.RemoveAt(posB);}

        }
        if (!esPlayer1)
        {
            posB += 1;
            posB = posB % player2Characters.Count;

            try
            { activarCharacter(player1Characters[posA]);}
            catch
            {player1Characters.RemoveAt(posA);}
        }

        esPlayer1 = !esPlayer1;

        
    }


    private void activarCharacter(GameObject character) {
        character.GetComponent<PlayerController>().enabled = true;
        character.GetComponent<CharacterSet>().enabled = true;
        activeCharacter = character;
        activeCharacter.GetComponent<PlayerController>().yaDisparo = false;
        setCamera(character);
        string charName = character.GetComponent<CharacterSet>().nombreCharacter.text;
        menu_armas.SetSpecialHability(charName); //nombreDelCharacter
       }
    private void desactivarCharacters()
    {
        foreach(GameObject character in player1Characters) {
            if (!character) continue; // { player1Characters.RemoveAt(player1Characters.IndexOf(character)); continue; }
            character.GetComponent<PlayerController>().enabled = false;
            character.GetComponent<CharacterSet>().enabled = false;
        }
        foreach(GameObject character in player2Characters) {
            if (!character) continue;
            character.GetComponent<PlayerController>().enabled = false;
            character.GetComponent<CharacterSet>().enabled = false;
        }
    }

    private void setCamera(GameObject character)
    {
        Camera.main.GetComponent<CameraFollowScript>().SetFollow(character);
    }




}
