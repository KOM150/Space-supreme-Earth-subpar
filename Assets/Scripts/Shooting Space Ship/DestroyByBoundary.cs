using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class DestroyByBoundary : MonoBehaviour
{
    public GameObject explosion; // 자신의 폭발 효과
    public GameObject playerExplosion; // 플레이어 폭발 효과
    // 게임 컨트롤러 스크립트에 접근하기 위한 변수
    private GameController gameController;

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
            UnityEngine.Debug.Log("Can't find 'GameController' script");
        }
    }

    //OnTriggerExit(): Collider(충돌체)간에 Trigger(충돌 감지)이 일어나면 호출
    void OnTriggerExit (Collider other) 
	{
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            gameController.GameLose();

        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}