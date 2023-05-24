using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScrene : MonoBehaviour
{
    public Text pointsText;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Setup(int Player)
    {
        gameObject.SetActive(true);
        pointsText.text = "Player"+Player.ToString() + " Wins";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
