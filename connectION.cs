using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class connectION : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI RoomName;
    private bool connectedToMaster;
    public bool JoinedRoom;
    public string Player;
    public Vector3 CreatePlayer;

    public void ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("connecting to master");

    }

    public  void CreateRoom()
    {  

        //if (!connectedToMaster||JoinedRoom) return;
        PhotonNetwork.CreateRoom("1", new RoomOptions() { MaxPlayers = 4 }, TypedLobby.Default);
        Debug.Log("Creating room");
    }

    public void JoinRoom()
    {

       // if (!connectedToMaster||JoinedRoom) return;
        PhotonNetwork.JoinRoom("1");
        Debug.Log("Joining");

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("connect to master SUCCESSFULLY");

    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Join in the room you created!!!!!");

        JoinedRoom = true;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room Successfully!!!!!!");
        PhotonNetwork.Instantiate(Player, CreatePlayer, Quaternion.identity);

    }
}
