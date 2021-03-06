﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class PhotonConnection : MonoBehaviourPunCallbacks
{

    public TMP_InputField input;
    public Button button;
    public string gameVersion;
    public string roomName;
    public byte maxPlayers;


    // Start is called before the first frame update

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            input.interactable = false;
            button.interactable = false;
            PhotonNetwork.NickName = input.text;
            PhotonNetwork.GameVersion = this.gameVersion;
            PhotonNetwork.ConnectUsingSettings();
            return;
        }
        
        if (PhotonNetwork.CountOfRooms == 0)
        {
            button.interactable = false;
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = this.maxPlayers;
            PhotonNetwork.JoinOrCreateRoom(this.roomName, options, TypedLobby.Default);
            return;
        }

        PhotonNetwork.JoinRoom(this.roomName);

    }

    public override void OnConnectedToMaster()
    {
        button.interactable = true;
        button.GetComponentInChildren<TMP_Text>().text = "Jogar";
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
