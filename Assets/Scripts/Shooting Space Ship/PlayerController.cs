using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public float speed = 13.0f;
    public GameObject Bolt;
	public Transform shotSpawn; //Bolt Transform
	public float fireRate;

	private float nextFire; //무한 발사 방지 (시간 제한)

<<<<<<< HEAD
	void Update()
	{
		bool buttonFire = false;

		if (Input.GetButton("Fire1"))
=======
	public bool buttonFire;
	public GameController gameController;

	void Update()
	{
		buttonFire = false;
		
		if(GameObject.Find("Game Controller").GetComponent<GameController>().gameOver==false && Input.GetButton("Fire1"))
>>>>>>> a04964c3c3cfec33477f1ab6eb78284d37a34827
		{
			buttonFire = true;
		}

		if (buttonFire && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;

            //Instantiate(): 게임을 실행하는 도중에 게임 오브젝트를 생성
            //Bolt를 생성하고, Bolt 위치 및 각도 설정

            //가운데 Bolt 
            Instantiate(Bolt, shotSpawn.position, shotSpawn.rotation);
			//왼쪽 Bolt *반시계
            Quaternion angle = Quaternion.Euler(new Vector3(0, 15.0f, 0));
            Instantiate(Bolt, shotSpawn.position, shotSpawn.rotation * angle);
            //오른쪽 Bolt
            angle = Quaternion.Euler(new Vector3(0, -15.0f, 0));
			Instantiate(Bolt, shotSpawn.position, shotSpawn.rotation * angle);

            GetComponent<AudioSource>().Play();
		}
	}

	//Player 이동
	void FixedUpdate()
	{
		//키보드를 누르면 그 값을 반환
		float horizontal_input = Input.GetAxis("Horizontal"); //왼 > -1, 오 > 1
		float vertical_input = Input.GetAxis("Vertical"); //

        //플레이어가 초당 얼마나 많은 거리를 이동해야 하는지를 계산하는데 사용
        //초당 프레임 = 플레이어의 스피드 * 델타 타임
        float distance_per_frame = speed * Time.deltaTime;

		transform.Translate(Vector3.right/*X축*/* horizontal_input /*방향*/ * distance_per_frame/*거리*/);
		transform.Translate(Vector3.forward/*Z축*/ * vertical_input /*방향*/ * distance_per_frame);
	}
}

