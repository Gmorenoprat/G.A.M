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

    Dictionary<GameObject, GameObject> dic = new Dictionary<GameObject, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<TurnMananger>();
        activePlayer = turnManager.activeCharacter.GetComponent<CharacterSet>();

        dic.Add(arrayPlayers[0], arrayHeads[0]);
        dic.Add(arrayPlayers[1], arrayHeads[1]);
        dic.Add(arrayPlayers[2], arrayHeads[2]);
        dic.Add(arrayPlayers[3], arrayHeads[3]);
        dic.Add(arrayPlayers[4], arrayHeads[4]);
        dic.Add(arrayPlayers[5], arrayHeads[5]);
        dic.Add(arrayPlayers[6], arrayHeads[6]);
        dic.Add(arrayPlayers[7], arrayHeads[7]);
        dic.Add(arrayPlayers[8], arrayHeads[8]);
        dic.Add(arrayPlayers[9], arrayHeads[9]);
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

        foreach(KeyValuePair<GameObject, GameObject> player in dic)
        {
            if (!player.Key)
            {
                player.Value.SetActive(true);
            }
        }
    }
}
