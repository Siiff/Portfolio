using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonNetworkController : MonoBehaviourPunCallbacks
{
    [Header("Login")]
    public GameObject loginPn;
    public InputField playerNameInput;
    private string playerTempName;
    [Header("Lobby")]
    public InputField roomNameInput;
    public GameObject lobbyPn;
    private string roomTempName;
    [Header("Player")]
    public GameObject playerObj;


    private void Start()
    {
        loginPn.gameObject.SetActive(true);
        lobbyPn.gameObject.SetActive(false);

        playerTempName = "Kleber" + Random.Range(10, 90);
        playerNameInput.text = playerTempName;

        roomTempName = "Patagonia" + Random.Range(10, 90);
    }

    public void Login()
    {
        PhotonNetwork.ConnectUsingSettings();
        if(playerNameInput.text != "" || playerNameInput.text != null)
        {
            PhotonNetwork.NickName = playerNameInput.text;
        }
        else
        {
            PhotonNetwork.NickName = playerTempName;
        }
        loginPn.gameObject.SetActive(false);
        lobbyPn.gameObject.SetActive(true);

        roomNameInput.text = roomTempName;
    }
    // BUTTONS //

    public void buscarPartidaRapida()
    {
        PhotonNetwork.JoinLobby();
    }


    public override void OnConnected()
    {
        //base.OnConnected();
        Debug.LogWarning("OnConnected");
    }
    public void createRoom()
    {
        //base.OnCreatedRoom();
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 10 };
        if (roomNameInput.text != "" || roomNameInput.text != null)
        {
            PhotonNetwork.JoinOrCreateRoom(roomNameInput.text, roomOptions,TypedLobby.Default);
        }
        else
        {
            PhotonNetwork.JoinOrCreateRoom(roomTempName, roomOptions, TypedLobby.Default);
        }
    }

    // PUN CALLBACKS //
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.LogWarning("OnConnectedToMaster");
        Debug.LogWarning("Server Region:" + PhotonNetwork.CloudRegion);
        Debug.LogWarning("Ping:" + PhotonNetwork.GetPing());
  
    }

    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
        Debug.LogWarning("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //base.OnJoinRandomFailed(returnCode, message);
        Debug.LogError("Erro ao entrar na sala");
        createRoom();
    }

    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.LogWarning("Entrou na sala: "+PhotonNetwork.CurrentRoom);
        Debug.LogWarning("PlayerList: "+PhotonNetwork.CountOfPlayersInRooms);

        loginPn.gameObject.SetActive(false);
        lobbyPn.gameObject.SetActive(false);

        //Instantiate(playerObj);
        PhotonNetwork.Instantiate(playerObj.name,playerObj.transform.position,playerObj.transform.rotation);
    }


}
