using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviour
{
    [SerializeField]
    public Text playerCount;

    [SerializeField]
    GameObject[] SpawnPoints;


    // Start is called before the first frame update
    void Start()
    {

        if (PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }

        playerCount.text = PhotonNetwork.CurrentRoom.PlayerCount + "/2 Starting Room";
    }

    void SpawnPlayer()
    {
        int player;
        if (PhotonNetwork.IsMasterClient)
        {
            player = 0;
        }
        else
        {
            player = 1;
        }
        GameObject Player = PhotonNetwork.Instantiate("Player_Red", SpawnPoints[player].transform.position, Quaternion.identity);
    }

    void Win()
    {
    }
}
