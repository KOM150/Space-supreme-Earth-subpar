using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float tumble; //회전 각도
	
	void Start ()
	{
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        // angularVelocity: Rigidbody의 속성 중 하나로, 시간당 회전되는 x, y, z각도
        // Random.insideUnitSphere는 무작위한 회전 방향을 생성
        // Random.insideUnitSphere: 반지름이 1인 구형 내에서 무작위로 선택된 방향 벡터 > x, y, z 값이 -1~1의 범위 값
    }
}