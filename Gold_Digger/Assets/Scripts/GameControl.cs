using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public bool isGameContinue = false;
    public int goldNum = 0;

    public TextMeshProUGUI goldNumText;

    public UnityEngine.UI.Button btnStart;

    [SerializeField] private GameObject gameCompletedPanel;


    void Start()
    {
        GetComponent<AudioSource>().Play();
        
    }

    public void AddGold()
    {
        goldNum++;
        goldNumText.text = "Gold: " + goldNum;

        if(goldNum >= 3)
        {
            Cursor.visible = true;
            gameCompletedPanel.SetActive(true);
            isGameContinue = false;
        }
    }


    public void StartGame()
    {
        Cursor.visible = false;
        isGameContinue = true;
        btnStart.gameObject.SetActive(false);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
