using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TurnMananger : MonoBehaviour
{
    [SerializeField] private List<GameObject> player1Characters;
    [SerializeField] private List<GameObject> player2Characters;

    public List<GameObject> players;

    public int p1Pos;
    public int p2Pos;

    public GameObject activeCharacter;

    public bool esPlayer1;
    public bool esPlayer2;

    public float timeEspera = 5f;

    public Fondo_loop fondo;
    public menuArmas menu_armas;

    public int turnCount=0;
    public float turnTimer;
    public float turnTimerConsigna;

    private void Awake()
    {
        GameObject[] allCharacters = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject character in allCharacters)
        {
            if(character.gameObject.layer == 14) //pinguinos
            {
                player1Characters.Add(character);
            }
            if (character.gameObject.layer == 15) //gorilas
            {
                player2Characters.Add(character);
            }
        }

        players.AddRange(allCharacters);

    }

    private void Start()
    {
         desactivarCharacters();

        var empiezaP1 = (Random.value < 0.5);

        if (empiezaP1)
        {
            p1Pos = Random.Range(0, player1Characters.Count);
            activarCharacter(player1Characters[p1Pos]);
            esPlayer1 = true;
            esPlayer2 = false;
        }
        else
        {
            p2Pos = Random.Range(0, player2Characters.Count);
            activarCharacter(player2Characters[p2Pos]);
            esPlayer1 = false;
            esPlayer2 = true;
        }


        turnTimer = turnTimerConsigna;
    }

    private void Update()
    {
        if (activeCharacter != null)
        {
            if(activeCharacter.GetComponent<PlayerController>().yaDisparo == true)
            { 
                timeEspera -= Time.deltaTime;
                if (timeEspera <= 0)
                {
                    cambiarTurno();
                }
            }
        }
        else { cambiarTurno(); }


        //forDebugs
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cambiarTurno();
        }

        turnTimer -= Time.deltaTime;

        if(turnTimer <= 0)
        {
            cambiarTurno();
        }
    }
     
    public void cambiarTurno()
    {
        if (fondo != null) fondo.ChangeRandomDirectionSpeed();

        timeEspera = 5f;
        turnCount++;
        turnTimer = turnTimerConsigna;

        //Se puede hacer con delegate! (mas optimo)
        //resta un turno al cooldown de cada personaje
        foreach(GameObject player in players)
        {
            if(player != null)
            player.GetComponent<SpecialCoolDown>().coolDown--;
        }

        desactivarCharacters();

        pasarTurno();



    }

    private void pasarTurno() 
    {
        esPlayer1 = !esPlayer1;
        esPlayer2 = !esPlayer2;
        //si esPlayer1 lo desactiva (pasa turno)
        if (esPlayer1)
        {
            p1Pos += 1;
            p1Pos = p1Pos % player1Characters.Count;
            try
            { activarCharacter(player1Characters[p1Pos]); }
            catch
            { 
                player1Characters.RemoveAt(p1Pos); 
                activeCharacter = null;
                esPlayer1 = !esPlayer1;
                esPlayer2 = !esPlayer2;
                p1Pos -= 1;
                p1Pos = p1Pos % player1Characters.Count;
                cambiarTurno();
            }
           

        }
        if (esPlayer2)
        {
            p2Pos += 1;
            p2Pos = p2Pos % player2Characters.Count;
            try
            { activarCharacter(player2Characters[p2Pos]); }
            catch
            { 
                player2Characters.RemoveAt(p2Pos); 
                activeCharacter = null;
                p2Pos -= 1;
                p2Pos = p2Pos % player2Characters.Count;
                esPlayer1 = !esPlayer1;
                esPlayer2 = !esPlayer2;
                cambiarTurno();
            }
           
        }

 
        
    }

    private void activarCharacter(GameObject character) 
    {
        if(character.GetComponent<PlayerController>() == null) { pasarTurno(); }
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
            try
            {
                // { player1Characters.RemoveAt(player1Characters.IndexOf(character)); continue; }
                character.GetComponent<Animator>().SetFloat("walk speed", 0);
                character.GetComponent<PlayerController>().enabled = false;
                character.GetComponent<CharacterSet>().enabled = false;
            }
            catch
            {
                continue;
            }
        }
        foreach(GameObject character in player2Characters) {
            try { 
            character.GetComponent<Animator>().SetFloat("walk speed", 0);
            character.GetComponent<PlayerController>().enabled = false;
            character.GetComponent<CharacterSet>().enabled = false;
            }
            catch
            {
                continue;
            }
        }
    }

    private void setCamera(GameObject character)
    {
        Camera.main.GetComponent<CameraFollowScript>().SetFollow(character);
    }




}
