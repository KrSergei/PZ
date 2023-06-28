using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    [SerializeField] private Slider healthslider;

    [SerializeField]
    private float maxHealth;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }


    public void UpdateHealthBar(float currentValue, float maxValue)
    {
     healthslider.value = currentValue / maxValue;
    } 
}
