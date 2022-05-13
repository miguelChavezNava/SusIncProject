using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI livesText;
    private PlayerController playerCtrlScript;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrlScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerCtrlScript.health;
        livesText.text = "Lives: " + PlayerController.lives;
        if(playerCtrlScript.health <= 0)
        {
            PlayerController.lives--;
            SceneManager.LoadScene("Main");
        }
        if(PlayerController.lives <= 0)
        {
            SceneManager.LoadScene("End");
            PlayerController.lives = 3;
        }
    }
}
