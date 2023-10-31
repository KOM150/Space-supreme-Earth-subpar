using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HpBarController : MonoBehaviour
{
    float curHealth = 50; // 나중에 과거 Data랑 연동해야 함
    float maxHealth = 100; 
    public Slider HpBarSlider;
    public GameController shootingSpaceShip;

    void Start()
    {
        shootingSpaceShip = GetComponent<GameController>();
        SetHp(curHealth);
    }

    private void Update()
    {
        UpdateScore(10);
    }

    public void SetHp(float score)
    {
        if (HpBarSlider != null)
        {
            HpBarSlider.value = score;
        }
    }

    public void UpdateScore(float damage)
    {
        /*
        if (shootingSpaceShip != null && shootingSpaceShip.GameOver()) //Error
        {
            SetHp(shootingSpaceShip.score/10);
        }
        */
    }
}
