using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
    [Tooltip("Caching a reference to the player script")]Player player;
    
    //Make sure that you can find the player ship
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    //I have wired this method to a button
    //If you click on that button, it will call the public method from the player script
    public void TurnPlayerRed()
    {
        player.TurnRed();
    }

    //I have wired this method to a button
    //If you click on that button, it will call the public method from the player script
    public void TurnPlayerBlue()
    {
        player.TurnBlue();
    }

    //I have wired this method to a button
    //If you click on that button, it will call the public method from the player script
    public void TurnPlayerGreen()
    {
        player.TurnGreen();
    }

    //I have wired this method to a button
    //If you click on that button, it will call the public method from the player script
    public void TurnPlayerGray()
    {
        player.TurnGray();
    }

    //I have wired this method to a button
    //If you click on that button, it will call the public method from the player script
    public void TurnPlayerPurple()
    {
        player.TurnPurple();
    }

    //I have wired this method to a button
    //If you click on that button, it will call the public method from the player script
    public void TurnPlayerWhite()
    {
        player.TurnWhite();
    }

    //I have wired this method to a button
    //If you click on that button, it will call the public method from the player script
    public void TurnPlayerCyan()
    {
        player.TurnCyan();
    }

    //I have wired this method to a button
    //If you click on that button, it will call the public method from the player script
    public void TurnPlayerBlack()
    {
        player.TurnBlack();
    }
}
