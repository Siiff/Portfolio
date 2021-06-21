using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public PlayerData playerData;
    public Sprite playerIcon;

    private void Start()
    {
        playerIcon = playerData.playerIcon;
    }
}
