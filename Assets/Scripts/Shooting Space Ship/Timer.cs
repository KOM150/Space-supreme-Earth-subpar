using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //시간 제한
    public float LimitTime; //제한 시간
    public Text text_Timer; //화면에 시간 표시
    public GameObject player; //플레이어 오브젝트
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // gameController 변수에 "GameController" 태그를 가진 게임 오브젝트를 할당
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
        {
            //새롭게 GameController 속성 할당 > 게임 내에서 게임 상태 및 점수를 업데이트하기 위해 사용
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        // gameController를 찾지 못한 경우 디버그 메시지 출력
        if (gameController == null)
        {
            Debug.Log("Can't find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //제한 시간 추가
        if (!gameController.gameOver)
        {
            if (LimitTime <= 0)
            {
                player.SetActive(false);
<<<<<<< HEAD
                gameController.GameWin();
=======
                gameController.GameOver();
>>>>>>> joinyea
            }
            else
            {
                LimitTime -= Time.deltaTime;
                text_Timer.text = "시간 : " + Mathf.Round(LimitTime);
            }
        }
    }
}
