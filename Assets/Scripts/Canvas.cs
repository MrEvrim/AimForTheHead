using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public GameObject player;
    public Button btnStart;
    public Button btnRess;
    public Button btnExit;
    public GameObject Menu;
    public GameObject InGame;
    public GameObject Dead;
    public GameObject Win;

    void Start()
    {
        player.GetComponent<PlayerShooting>().enabled = false;
        Win.SetActive(false);
        Menu.SetActive(true);
        InGame.SetActive(false);
        Dead.SetActive(false);
        Time.timeScale = 0;
    }

    public void btnStartF()
    {
        player.GetComponent<PlayerShooting>().enabled = true;
        player.SetActive(true);
        Win.SetActive(false);
        Menu.SetActive(false);
        InGame.SetActive(true);
        Dead.SetActive(false);
        Time.timeScale = 1;
    }
    public void btnRessF()
    {
        Win.SetActive(false);
        Menu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        InGame.SetActive(true);
        Dead.SetActive(false);
    }
    public void btnExitF()
    {
        Application.Quit();
    }

}