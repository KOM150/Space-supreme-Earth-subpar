using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnimation : MonoBehaviour
{
    Animator anim; //�ִϸ��̼��� �������ֱ� ���� �ִϸ����� ������
    int randomNum; //������ �ִϸ��̼� ��ȣ
    float randomTime; //������ ��� �ð�

   
    void Start()
    {
        anim = GetComponent<Animator>(); //�ִϸ����� �ʱ�ȭ
        StartCoroutine(MyCoroutine()); //�ڷ�ƾ ����
    }
    IEnumerator MyCoroutine()
    {
        while (true)
        {
            randomTime = Random.Range(6.0f, 10.0f); //������ ��� �ð� ����
            randomNum = Random.Range(1, 5); //������ �ִϸ��̼� ��ȣ ����
           
            anim.SetInteger("Num", randomNum); //���� ���� �ش��ϴ� ��ȣ�� �ִϸ��̼� ���
            
            yield return new WaitForSeconds(1.5f); //1.5�� ���� �ش� ��ȣ�� �ִϸ��̼� ������ 

            anim.SetInteger("Num", 0); //�ٽ� �⺻ �ִϸ��̼����� ���ƿ�
            
            yield return new WaitForSeconds(randomTime); //������ ��� �ð� ��ŭ ��ٸ�
        }
    }

    private void Update()
    {
        anim.speed = 0.3f; //�ִϸ��̼��� �����ϴ� �ӵ��� ���� ���߾���.
    }
}
