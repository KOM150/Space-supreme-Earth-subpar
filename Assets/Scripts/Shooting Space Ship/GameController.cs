using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
<<<<<<< HEAD
    public int hazardCount;

    public float startWait;
    public float spawnWait;
    public float waveWait;

    public Text titleText;
=======
    public int hazardCount; 

    public float startWait; 
    public float spawnWait; 
    public float waveWait; 

    public Text titleText; 
>>>>>>> joinyea
    public Text memoText;
    public Text subtitleText;

    public bool gameOver;
    private bool restart;

<<<<<<< HEAD
    //
    private GameManager gameManager;
    private int score;
=======
    private PlayerController playercontroller;
    private GameManager gameManager;
>>>>>>> joinyea

    void Start()
    {
        gameManager = GameManager.Instance;
        StartCoroutine(WaitAndStart());
    }

    void UpdateScore()
    {
<<<<<<< HEAD
        titleText.text = "Score: " + score;
=======
        titleText.text = "Score: " + gameManager._score;
>>>>>>> joinyea
    }

    public void AddScore(int newScoreValue)
    {
<<<<<<< HEAD
        score += newScoreValue;
=======
        gameManager._score += newScoreValue;
>>>>>>> joinyea
        UpdateScore();
    }

    IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(0.5f);

        gameOver = false;
        restart = false;

        memoText.text = "";
        subtitleText.text = "";

<<<<<<< HEAD
        score = 0;
=======
        gameManager._score = 0;
>>>>>>> joinyea
        UpdateScore();

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
<<<<<<< HEAD
        yield return new WaitForSeconds(startWait);
=======
        yield return new WaitForSeconds(startWait); 
>>>>>>> joinyea

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
<<<<<<< HEAD
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
=======
                GameObject hazard = hazards[Random.Range(0, hazards.Length)]; 
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); 
                Quaternion spawnRotation = Quaternion.identity; 
>>>>>>> joinyea

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

<<<<<<< HEAD
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                memoText.text = "Press 'R' to end the Mini game";
                memoText.fontSize = 14;
=======
            yield return new WaitForSeconds(waveWait); 

            if (gameOver)
            {
                memoText.text = "Press 'R' for GameOver";
                memoText.fontSize = 30;
>>>>>>> joinyea
                memoText.color = Color.white;
                restart = true;
                break;
            }
        }
    }

    void Update()
    {
        //재실행 시 Tycoon Scene으로
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Tycoon Scene");
            }
        }
    }

<<<<<<< HEAD
    public void GameWin() //Timer에 적용
    {
        subtitleText.text = "Mission: Win!";
        subtitleText.fontSize = 32;
        subtitleText.fontStyle = FontStyle.Bold;
        subtitleText.color = Color.yellow;

        gameManager._score += score / 10;
        gameOver = true;
    }

    public void GameLose() //DestroyByContact에 적용
    {
        subtitleText.text = "Mission: Lose!";
        subtitleText.fontSize = 32;
        subtitleText.fontStyle = FontStyle.Bold;
        subtitleText.color = Color.yellow;

        gameManager._score += -10;
=======
    public void GameOver()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().buttonFire=false;

        subtitleText.text = "Game Over!";
        subtitleText.fontSize = 36;
        subtitleText.fontStyle = FontStyle.Bold;
        subtitleText.color = Color.yellow;
>>>>>>> joinyea
        gameOver = true;
    }
}