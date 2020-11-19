using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILive : MonoBehaviour
{
    public TurnMananger turnManager;
    public CharacterSet activePlayer;
    public TextMeshProUGUI turns, timer;
    public GameObject blockedUlti;
    public GameObject[] arrayHeads;
    public GameObject[] arrayPlayers;
    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnMananger>();
        activePlayer = turnManager.activeCharacter.GetComponent<CharacterSet>();
    }

    // Update is called once per frame
    void Update()
    {
        turns.text = "TURNO "+ turnManager.turnCount;
        timer.text = ""+ Mathf.Round(turnManager.turnTimer);

        if (activePlayer != null)
        {
            if (!activePlayer.permission)
            {
                blockedUlti.SetActive(true);
            }
            else blockedUlti.SetActive(false);
        }

        if (!arrayPlayers[0])
        {
            arrayHeads[0].SetActive(true);
        }
        if (!arrayPlayers[1])
        {
            arrayHeads[1].SetActive(true);
        }
        if (!arrayPlayers[2])
        {
            arrayHeads[2].SetActive(true);
        }
        if (!arrayPlayers[3])
        {
            arrayHeads[3].SetActive(true);
        }
        if (!arrayPlayers[4])
        {
            arrayHeads[4].SetActive(true);
        }
        if (!arrayPlayers[5])
        {
            arrayHeads[5].SetActive(true);
        }
        if (!arrayPlayers[6])
        {
            arrayHeads[6].SetActive(true);
        }
        if (!arrayPlayers[7])
        {
            arrayHeads[7].SetActive(true);
        }
        if (!arrayPlayers[8])
        {
            arrayHeads[8].SetActive(true);
        }
        if (!arrayPlayers[9])
        {
            arrayHeads[9].SetActive(true);
        }
    }
}
