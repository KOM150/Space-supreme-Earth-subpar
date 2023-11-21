using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;

    public float startWait;
    public float spawnWait;
    public float waveWait;

    public Text titleText;
    public Text memoText;
    public Text subtitleText;

    public bool gameOver;
    private bool restart;

    private PlayerController playercontroller;
    private GameManager gameManager;
    private int score;

    void Start()
    {
        gameManager = GameManager.Instance;
        StartCoroutine(WaitAndStart());
    }

    void UpdateScore()
    {
        titleText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(0.5f);

        gameOver = false;
        restart = false;

        memoText.text = "";
        subtitleText.text = "";

        score = 0;
        UpdateScore();

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                memoText.text = "Press 'R' to end the Mini game";
                memoText.fontSize = 14;
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
        gameOver = true;
    }
}