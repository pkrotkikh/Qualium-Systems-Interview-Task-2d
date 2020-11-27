using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    Text stopMovingText;

    private void Start()
    {
        stopMovingText = gameObject.transform.Find("StopMovingText").GetComponent<Text>();
    }

    public void PauseGame()
    {
        Player.isPlayerPaused = !Player.isPlayerPaused;
        Player.isMoving = false;

        if (Player.isPlayerPaused)
        {
            stopMovingText.text = "Continue";
        }
        else
        {
            stopMovingText.text = "Stop Moving";
        }
    }
}
