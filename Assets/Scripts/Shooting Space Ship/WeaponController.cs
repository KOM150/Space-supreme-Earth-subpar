using UnityEngine;
using System.Collections;

// 총알 발사를 위한 코드

public class WeaponController : MonoBehaviour
{
    public GameObject shot; // 발사될 총알 (프리팹)
    public Transform shotSpawn; // 총알의 생성 위치
    public float fireRate; // 총알 발사 속도
    public float delay; // 초기 지연 시간

    void Start()
    {

        InvokeRepeating("Fire", delay, fireRate);
        // InvokeRepeating ( 메서드 명 , 초기 지연 시간, Method를 반복 호출할 간격)
        // 게임 시작 후 delay 동안 대기한 뒤, fireRate 간격으로 "Fire" Method 호출
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        // shot 프리펩을 shotSpawn.position 위치에 shotSpawn.rotation 회전으로 생성
        GetComponent<AudioSource>().Play();
        // "Fire" Method 가 실행되면 AudioSource에 설정된 음악 실행
    }
}
