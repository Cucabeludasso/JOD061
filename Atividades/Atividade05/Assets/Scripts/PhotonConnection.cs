using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;


public class PhotonConnection : MonoBehaviourPunCallbacks
{
    public string gameVersion = "0.0.1";
    public string nickName = "Player";
    public string roomName = "JOD061";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Conectando ao servidor...", this);


        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.NickName = nickName + Random.Range(0, 9999);
        PhotonNetwork.ConnectUsingSettings();
        
}

    public override void OnConnectedToMaster()
    {
        
        if (PhotonNetwork.CountOfRooms == 0)
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 4;
            PhotonNetwork.JoinOrCreateRoom(roomName, options, TypedLobby.Default);
        }
        else
{
            PhotonNetwork.JoinRoom(roomName);
        }
        
    }

    public override void OnCreatedRoom() 
    {
        Debug.Log("Criada a sala " + roomName);
        Debug.Log("Jogador " + PhotonNetwork.LocalPlayer.NickName + " entrou na sala " + roomName + " (" + PhotonNetwork.CurrentRoom.PlayerCount + ")");
    }



    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        Debug.Log("Desconectado!");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Jogador " + newPlayer.NickName + " entrou na sala " + roomName + " (" + PhotonNetwork.CurrentRoom.PlayerCount + ")");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Jogador " + otherPlayer.NickName + " saiu na sala " + roomName + " (" + PhotonNetwork.CurrentRoom.PlayerCount + ")");
    }


}