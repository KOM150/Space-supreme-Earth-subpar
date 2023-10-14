using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards; //소환 오브젝트 배열 
    public Vector3 spawnValues; //소환 오브젝트 영역 제한 (x, y, z)
    public int hazardCount; //소환 오브젝트 배열 크기

    //게임 난이도 조절
    public float startWait; //게임이 시작되고 얼마나 빨리 소환 오브젝트가 나타날지
    public float spawnWait; //소환 오브젝트 생성 간격
    public float waveWait; //소환 오브젝트 생성이 시작되기 전의 간격

    public Text titleText; //게임 실행 시 Score Text로 사용
    public Text memoText;
    public Text subtitleText;

    private bool gameOver; //게임 종료 여부
    private bool restart; //재실행 여부
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;

        memoText.text = ""; //게임 실행하면 화면에서 사라짐
        subtitleText.text = "";
        
        //점수 시스템
        score = 0;
        UpdateScore();

        //소환 및 재실행 시스템
        //코루틴
        /*
          1. 게임 루프의 차단 방지: 코루틴을 사용하면 긴 작업을 수행해도 게임 루프를 차단하지 않고 계속 실행 > 부드러운 게임 실행 유지
          2. 시간 지연 및 간격 제어: yield return new WaitForSeconds(time)
          3. 병렬 작업 처리
         */
        StartCoroutine(SpawnWaves());
    }

    void UpdateScore()
    {
        // Enemy 20점, 행성 10점 이러한 점수 값을 어떻게 해당 코드에 반영했는지
        // > 바로 AddScore()를 사용
        // > Done_Destory by Contact 스크립트에서 Done_GameController 객체를 받아와, AddScore()를 사용
        titleText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); //1. 게임이 시작되고 얼마나 빨리 소환 오브젝트가 나타날지

        //무한
        while (true)
        {
            //소환 시스템 //3. 소환 오브젝트 생성 간격
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)]; //행성 1~3과 적 중 랜덤 생성
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); //소환 오브젝트 위치
                Quaternion spawnRotation = Quaternion.identity; //소환 오브젝트 각도 = 회전을 갖지 않는 초기 상태

                //Instantiate(): 게임을 도중에 게임 오브젝트를 생성
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait); //다음 i(index)로 가기 위해 얼마나 기다릴 것이냐
            }

            yield return new WaitForSeconds(waveWait); //2. 소환 오브젝트 생성이 시작되기 전의 간격 // Wave 간격 // 그룹 간격

            //재실행 시스템
            if (gameOver)
            {
                memoText.text = "Press 'R' for Restart";
                memoText.fontSize = 36;
                restart = true;
                break; //While문 탈출
            }
        }
    }

    void Update()
    {
        //재실행 시스템
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SceneManager.LoadScene() : 현재 활성화된 씬을 다시 로드함으로써 씬을 다시 시작하거나 초기 상태
                //SceneManager.GetActiveScene().buildIndex : 현재 활성화된 씬의 빌드 인덱스
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void GameOver()
    {
        subtitleText.text = "Game Over!";
        subtitleText.fontSize = 36;
        subtitleText.fontStyle = FontStyle.Bold;
        subtitleText.color = Color.yellow;
        gameOver = true;
    }
}