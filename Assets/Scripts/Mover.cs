using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
        //물리 엔진 속도 = 게임 오브젝트의 앞쪽 방향 * 속도
        //Rigidbody의 속도를 설정 > 물리 엔진 때문에 총알이 앞으로 이동하게 됨
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
