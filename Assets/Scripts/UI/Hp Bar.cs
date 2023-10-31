using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour
{
    float curHealth = 50; // 나중에 과거 Data랑 연동해야 함
    public Slider HpBarSlider;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Can't find 'GameController' script");
        }

        SetHp(curHealth);
    }

    private void Update()
    {
        if (gameController.gameOver)
        {
            HpBarSlider.value += gameController.gameOverScore / 10;
        }
    }

    public void SetHp(float score)
    {
        if (HpBarSlider != null)
        {
            HpBarSlider.value = score;
        }
    }
}
