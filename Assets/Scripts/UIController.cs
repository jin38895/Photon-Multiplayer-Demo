using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviourPunCallbacks
{

    public InputField roomNameInput;

    #region Methods

    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnClickJoinRoom()
    {
        string roomName = roomNameInput.text;
        if (!string.IsNullOrEmpty(roomName))
        {
            PhotonNetwork.JoinRoom(roomName);
        }
    }

    public void OnClickCreateRoom()
    {
        string roomName = roomNameInput.text;
        if (!string.IsNullOrEmpty(roomName))
        {
            PhotonNetwork.CreateRoom(roomName);
        }
    }
    #endregion

    #region PHOTON_CALLBACKS
    public override void OnCreatedRoom()
    {
        Debug.Log(roomNameInput.text + " Room Created");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(roomNameInput.text + " Room Created");
        PhotonNetwork.LoadLevel("MainGame");
    }
    #endregion
}
