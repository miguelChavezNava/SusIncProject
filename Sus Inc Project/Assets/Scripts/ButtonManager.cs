using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("Title");
    }
    public void toInstructions()
    {
        SceneManager.LoadScene("Directions");
    }
}
