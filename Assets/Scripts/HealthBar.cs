using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;

    public void SetMaxHealth(float health)
    {
        healthBarImage.fillAmount = 1f;
    }

    public void SetHealth(float health,float maxHealth)
    {
        healthBarImage.fillAmount = health/maxHealth;
    }

}
