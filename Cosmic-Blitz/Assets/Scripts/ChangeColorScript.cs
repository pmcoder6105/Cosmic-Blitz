using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void TurnPlayerRed()
    {
        player.TurnRed();
    }

    public void TurnPlayerBlue()
    {
        player.TurnBlue();
    }

    public void TurnPlayerGreen()
    {
        player.TurnGreen();
    }
    public void TurnPlayerGray()
    {
        player.TurnGray();
    }

    public void TurnPlayerPurple()
    {
        player.TurnPurple();
    }
    public void TurnPlayerWhite()
    {
        player.TurnWhite();
    }
    public void TurnPlayerCyan()
    {
        player.TurnCyan();
    }
    public void TurnPlayerBlack()
    {
        player.TurnBlack();
    }
}
