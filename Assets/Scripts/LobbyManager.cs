using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;
using PlayFab;
using PlayFab.ClientModels;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static Action GetPhotonFriends = delegate { };
    [SerializeField]
    GameObject findMatchBtn;
    [SerializeField]
    GameObject searchingPanel;
    [SerializeField]
    GameObject playPanel;
    [SerializeField]
    GameObject lockerPanel;
    [SerializeField]
    GameObject shopPanel;
    [SerializeField]
    GameObject friendsPanel;
    [SerializeField]
    GameObject settingsPanel;

    void Start()
    {
        searchingPanel.SetActive(false);
        findMatchBtn.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are Connected to Photon! on " + PhotonNetwork.CloudRegion + " Server");
        PhotonNetwork.AutomaticallySyncScene = true;
        findMatchBtn.SetActive(true);
    }

    public void FindMatch()
    {
        searchingPanel.SetActive(true);
        findMatchBtn.SetActive(false);

        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Searching for a Game");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Couldn't Find Room - Creating a Room");
        MakeRoom();
    }

    void MakeRoom()
    {
        int randomRoomName = UnityEngine.Random.Range(0, 5000);
        RoomOptions roomOptions =
        new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2
        };
        PhotonNetwork.CreateRoom("RoomName_" + randomRoomName, roomOptions);
        Debug.Log("Room Created, Waiting For Another Player");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient)
        {
            Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount + "/2 Starting Room");
            PhotonNetwork.LoadLevel(3);
        }
        GetPhotonFriends?.Invoke();
    }

    public void StopSearch()
    {
        searchingPanel.SetActive(false);
        findMatchBtn.SetActive(true);
        PhotonNetwork.LeaveRoom();
        Debug.Log("Stopped, Back to Lobby");
    }

    public void ChangeToPlay()
    {
        playPanel.SetActive(true);
        lockerPanel.SetActive(false);
        shopPanel.SetActive(false);
        friendsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void ChangeToLocker()
    {
        playPanel.SetActive(false);
        lockerPanel.SetActive(true);
        shopPanel.SetActive(false);
        friendsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void ChangeToShop()
    {
        playPanel.SetActive(false);
        lockerPanel.SetActive(false);
        shopPanel.SetActive(true);
        friendsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void ChangeToFriends()
    {
        playPanel.SetActive(false);
        lockerPanel.SetActive(false);
        shopPanel.SetActive(false);
        friendsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    public void ChangeToSettings()
    {
        playPanel.SetActive(false);
        lockerPanel.SetActive(false);
        shopPanel.SetActive(false);
        friendsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
