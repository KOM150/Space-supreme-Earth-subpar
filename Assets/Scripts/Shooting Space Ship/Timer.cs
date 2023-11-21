using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //�ð� ����
    public float LimitTime; //���� �ð�
    public Text text_Timer; //ȭ�鿡 �ð� ǥ��
    public GameObject player; //�÷��̾� ������Ʈ
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // gameController ������ "GameController" �±׸� ���� ���� ������Ʈ�� �Ҵ�
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
        {
            //���Ӱ� GameController �Ӽ� �Ҵ� > ���� ������ ���� ���� �� ������ ������Ʈ�ϱ� ���� ���
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        // gameController�� ã�� ���� ��� ����� �޽��� ���
        if (gameController == null)
        {
            Debug.Log("Can't find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���� �ð� �߰�
        if (!gameController.gameOver)
        {
            if (LimitTime <= 0)
            {
                player.SetActive(false);

                gameController.GameWin();

            }
            else
            {
                LimitTime -= Time.deltaTime;
                text_Timer.text = "�ð� : " + Mathf.Round(LimitTime);
            }
        }
    }
}
