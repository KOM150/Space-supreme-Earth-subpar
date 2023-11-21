using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnimation : MonoBehaviour
{
    Animator anim; //애니메이션을 지정해주기 위해 애니메이터 가져옴
    int randomNum; //랜덤한 애니메이션 번호
    float randomTime; //랜덤한 대기 시간

   
    void Start()
    {
        anim = GetComponent<Animator>(); //애니메이터 초기화
        StartCoroutine(MyCoroutine()); //코루틴 시작
    }
    IEnumerator MyCoroutine()
    {
        while (true)
        {
            randomTime = Random.Range(6.0f, 10.0f); //랜덤한 대기 시간 설정
            randomNum = Random.Range(1, 5); //랜덤한 애니메이션 번호 설정
           
            anim.SetInteger("Num", randomNum); //랜덤 값에 해당하는 번호의 애니메이션 출력
            
            yield return new WaitForSeconds(1.5f); //1.5초 동안 해당 번호의 애니메이션 보여줌 

            anim.SetInteger("Num", 0); //다시 기본 애니메이션으로 돌아옴
            
            yield return new WaitForSeconds(randomTime); //랜덤한 대기 시간 만큼 기다림
        }
    }

    private void Update()
    {
        anim.speed = 0.3f; //애니메이션이 동작하는 속도를 조금 늦추었음.
    }
}
