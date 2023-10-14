using UnityEngine;
using System.Collections;

public class Done_EvasiveManeuver : MonoBehaviour
{
	public Done_Boundary boundary; //���� ����
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime; //ȸ�� ���� �ð� //Vector2(x�� ~ y��)
    public Vector2 maneuverWait; //���(����) �ð� //Vector2(x�� ~ y��)

    private float currentSpeed; //z�� �ӵ� //�յ�
	private float targetManeuver; //x�� �ӵ� (����, �ӷ�) //�޿�

	void Start ()
	{
		currentSpeed = GetComponent<Rigidbody>().velocity.z; //z�� �ӵ� ����
		StartCoroutine(Evade()); //ȸ�� �ý��� //�ڷ�ƾ
	}
	
	IEnumerator Evade () 
	{
		yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y)); //Vector2(x�� ~ y��) �������� ���� ���

        while (true) //����
		{
            //1. �ӵ� ����
            //Mathf.Sign(): ��� > 1.0 ��ȯ, ���� > -1.0, 0 > 0  //�� 1~dodge������ x�� �ӵ��� ������ �� �ֵ���
            targetManeuver = Random.Range(1, dodge) /*�ӷ�*/ * -Mathf.Sign(transform.position.x)/*x�� ����*/;

            //2. ȸ�� ����
            //yield return new WaitForSeconds()�� �ڷ�ƾ�� ����, ������Ʈ�� ������ ������ �ð� ���� ȸ�� �������� ����
            //(������ �ð��� ��ٸ� ���Ŀ� �ڷ�ƾ�� ��ӵ�)
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));

            //3.�ӵ� �� 0 // ȸ�� ������ ������ �� ������ �ӵ� ���� 0���� ��, ��� (����) 
            targetManeuver = 0;

            //4. ������Ʈ�� ������ ������ �ð� ���� ���(�ӵ�0)�� ����
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
		}
	}

	//������Ʈ Transform ����
    //fixedUpdate(): ���� ������Ʈ�� ���õ� �۾��� ���� > ���� ������ ���� //�ε巯�� ������ ����
    void FixedUpdate ()
	{
		//x�� �ӵ�
		//1�� x�� �ӵ����� 2�� x�� �ӵ���, 3�� �ð� ���ݸ�ŭ �󸶳� �ε巴�� ������ ���̳�
		float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x/*1*/, targetManeuver/*2*/, smoothing * Time.deltaTime);

		//������Ʈ �ӵ�(x��, 0, z��) ����
		GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
		
		//������Ʈ ��ġ
		GetComponent<Rigidbody>().position = new Vector3
		(
            //Mathf.Clamp(): �־��� ���� �ּҰ��� �ִ밪 ���̷� ����
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin/*�ּ�*/, boundary.xMax/*�ִ�*/),  //x�� ��ġ
			0.0f, //y�� ��ġ
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) //z�� ��ġ
		);

        //������Ʈ ȸ��
        //[������] x�� �ӵ��� �� z�� ȸ�������� �����ϴ��� �ǹ�
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
