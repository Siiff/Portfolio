using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SelectPlayer : MonoBehaviour
{

    public int playerSelected = 2;
    public GameObject playerBody;
    public Image playerIconCanvas;
    public GameObject playerCanvas;
    PhotonView photonView;


    void Start()
    {
        photonView = this.GetComponent<PhotonView>();
        if(!photonView.IsMine)
        {
            playerCanvas.gameObject.SetActive(false);
        }
        
        SwitchPlayer();        
    }

    private void SwitchPlayer()
    {
        photonView.RPC("SwitchPlayerRPC", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void SwitchPlayerRPC()
    {
        int i = 0;

        foreach (Transform item in playerBody.transform)
        {
            if (i == playerSelected)
            {
                item.gameObject.SetActive(true);
                if (item.gameObject.GetComponent<PlayerConfig>())
                {
                    Debug.LogWarning("CAIU AQUIIII");
                    playerIconCanvas.sprite = item.gameObject.GetComponent<PlayerConfig>().playerIcon;
                }
            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }
    }

   
    public void ButtonLeft()
    {
        photonView.RPC("ButtonLeftRPC", RpcTarget.AllBuffered);
    }

    
    public void ButtonRight()
    {
        photonView.RPC("ButtonRightRPC", RpcTarget.AllBuffered);
    }
    [PunRPC]
    public void ButtonLeftRPC()
    {
        playerSelected--;

        if (playerSelected < 0)
        {
            playerSelected = playerBody.transform.childCount - 1;
        }
        SwitchPlayer();
    }
    [PunRPC]
    public void ButtonRightRPC()
    {
        playerSelected++;

        if (playerSelected > (playerBody.transform.childCount - 1))
        {
            playerSelected = 0;
        }
        SwitchPlayer();
    }
}
