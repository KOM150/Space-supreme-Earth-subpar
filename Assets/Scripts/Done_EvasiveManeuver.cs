using UnityEngine;
using System.Collections;

public class Done_EvasiveManeuver : MonoBehaviour
{
	public Done_Boundary boundary; //영역 제한
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime; //회피 동작 시간 //Vector2(x초 ~ y초)
    public Vector2 maneuverWait; //대기(멈춤) 시간 //Vector2(x초 ~ y초)

    private float currentSpeed; //z축 속도 //앞뒤
	private float targetManeuver; //x축 속도 (방향, 속력) //왼오

	void Start ()
	{
		currentSpeed = GetComponent<Rigidbody>().velocity.z; //z축 속도 설정
		StartCoroutine(Evade()); //회피 시스템 //코루틴
	}
	
	IEnumerator Evade () 
	{
		yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y)); //Vector2(x초 ~ y초) 간격으로 랜덤 대기

        while (true) //무한
		{
            //1. 속도 설정
            //Mathf.Sign(): 양수 > 1.0 반환, 음수 > -1.0, 0 > 0  //즉 1~dodge까지의 x축 속도만 구현할 수 있도록
            targetManeuver = Random.Range(1, dodge) /*속력*/ * -Mathf.Sign(transform.position.x)/*x축 방향*/;

            //2. 회피 동작
            //yield return new WaitForSeconds()로 코루틴을 멈춰, 오브젝트가 설정된 랜덤한 시간 동안 회피 움직임을 유지
            //(랜덤한 시간을 기다린 이후에 코루틴이 계속됨)
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));

            //3.속도 값 0 // 회피 동작을 수행할 수 없도록 속도 값을 0으로 둬, 대기 (멈춤) 
            targetManeuver = 0;

            //4. 오브젝트가 설정된 랜덤한 시간 동안 대기(속도0)를 유지
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
		}
	}

	//오브젝트 Transform 설정
    //fixedUpdate(): 물리 업데이트와 관련된 작업에 적합 > 물리 엔진에 적합 //부드러운 움직임 구현
    void FixedUpdate ()
	{
		//x축 속도
		//1번 x축 속도에서 2번 x축 속도로, 3번 시간 간격만큼 얼마나 부드럽게 움직일 것이냐
		float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x/*1*/, targetManeuver/*2*/, smoothing * Time.deltaTime);

		//오브젝트 속도(x축, 0, z축) 적용
		GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
		
		//오브젝트 위치
		GetComponent<Rigidbody>().position = new Vector3
		(
            //Mathf.Clamp(): 주어진 값을 최소값과 최대값 사이로 제한
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin/*최소*/, boundary.xMax/*최대*/),  //x축 위치
			0.0f, //y축 위치
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) //z축 위치
		);

        //오브젝트 회전
        //[월요일] x축 속도를 왜 z축 회전값으로 적용하는지 의문
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
