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
            gameOverText.text = "그동안 고마웠어... \n Press 'L'";
            gameOverText.fontStyle = FontStyle.Bold;

            if (Input.GetKeyDown(KeyCode.L))
            {
                gameLose = true;
            }
        }

        if (SliderCtrl._hp == 100)
        {
            gameOverText.enabled = true;
            gameOverText.text = "이제 난 너 덕분에 우주로 갈 수 있어. 고마워!\n Press 'W'";
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
