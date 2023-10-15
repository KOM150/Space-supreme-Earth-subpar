using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
    // 다른 오브젝트와 상호작용할 때 사용할 파티클 오브젝트를 지정
    public GameObject explosion; // 자신의 폭발 효과
    public GameObject playerExplosion; // 플레이어 폭발 효과

    // 해당 오브젝트 제거 시 플레이어가 얻을 점수
    public int scoreValue;

    // 게임 컨트롤러 스크립트에 접근하기 위한 변수
    private Done_GameController gameController;

    /*
     게임에서 플레이어가 점수를 얻거나 게임이 종료되었을 때 > 이 정보를 다른 스크립트로 전달하고 업데이트해야 함. 
     
    Done_GameController 스크립트는 이러한 정보를 추적하고 관리하는 중요한 역할을 함.
     > Start 함수에서 Done_GameController 스크립트에 접근하여 gameController 변수에 참조를 설정함.
     */
    void Start()
    {
        // gameController 변수에 "GameController" 태그를 가진 게임 오브젝트를 할당
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
        {
            //새롭게 GameController 속성 할당 > 게임 내에서 게임 상태 및 점수를 업데이트하기 위해 사용
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }

        // gameController를 찾지 못한 경우 디버그 메시지 출력
        if (gameController == null)
        {
            Debug.Log("Can't find 'GameController' script");
        }
    }

    // Collider(충돌체)와 충돌했을 때 호출되는 함수
    // 충돌한 오브젝트의 태그를 확인하여 처리
    void OnTriggerEnter(Collider other)
    {
        // 1. "Boundary" 또는 "Enemy" 태그가 있는 오브젝트와 충돌한 경우
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            // 아무 작업도 하지 않고 함수가 종료됨
            return;
        }

        // 2. 충돌한 오브젝트의 태그가 "Player"인 경우
        if (other.tag == "Player")
        {
            // 플레이어 폭발 효과를 생성
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //게임 오버 함수를 호출
            gameController.GameOver();
        }

        // 폭발 효과가 지정되어 있는 경우
        if (explosion != null)
        {
            //폭발 효과 생성
            Instantiate(explosion, transform.position, transform.rotation);
        }

        // 2인 경우에만 게임 컨트롤러에 점수가 추가됨
        gameController.AddScore(scoreValue);

        //충돌한 오브젝트와 자신을 파괴
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

/*
일반적으로 Start 함수는 스크립트 속성을 초기화(설정)하고 
Update 함수는 스크립트를 참조하는 작업을 함. ex, 해당 스크립트의 메서드 호출
*/

/*
 게임 컨트롤러와 같은 중요한 초기화나 설정 : Start 함수에서 수행됨. 
 스크립트가 게임 오브젝트에 부착된 순간 한 번만 실행되기 때문에 > 효율적이며, 초기화 작업을 수행하기에 적합
 */

//Start 함수는 스크립트가 게임 오브젝트에 연결될 때 처음 한 번 실행되는 함수. //주요 작업은 gameController 변수를 초기화