using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    bool gameLose = false;
    bool gameWin = false;

    private void Start()
    {
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SliderCtrl._hp == 0)
        {
            gameOverText.enabled = true;
            gameOverText.text = "�׵��� ������... \n Press 'L'";
            gameOverText.fontStyle = FontStyle.Bold;

            if (Input.GetKeyDown(KeyCode.L))
            {
                gameLose = true;
            }
        }

        if (SliderCtrl._hp == 100)
        {
            gameOverText.enabled = true;
            gameOverText.text = "���� �� �� ���п� ���ַ� �� �� �־�. ����!\n Press 'W'";
            gameOverText.fontStyle = FontStyle.Bold;

            if (Input.GetKeyDown(KeyCode.W))
            {
                gameWin = true;
            }
        }

        if (gameLose) 
        {
            SceneManager.LoadScene("GameLose");
        }

        if (gameWin)
        {
            SceneManager.LoadScene("GameWin");
        }
    }
}
