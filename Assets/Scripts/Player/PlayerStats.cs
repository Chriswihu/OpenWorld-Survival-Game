using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    static float health;
    static float hunger;
    static float thirst;
    static float maxHealth = 100;
    static float maxHunger = 100;
    static float maxThirst = 100;


    public Slider healthBar;
    public Slider hungerBar;
    public Slider thirstBar;

    private void Start()
    {
        healthBar.minValue = 0;
        hungerBar.minValue = 0;
        thirstBar.minValue = 0;
        healthBar.maxValue = maxHealth;
        hungerBar.maxValue = maxHunger;
        thirstBar.maxValue = maxThirst;
        health = maxHealth;
        hunger = maxHunger;
        thirst = maxThirst;
    }

    private void Update()
    {
        healthBar.value = health;
        hungerBar.value = hunger;
        thirstBar.value = thirst;
        Damage();
    }

    void Damage()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            health -= 10;
            hunger -= 10;
            thirst -= 10;
        }
    }
}
