using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyEditor : MonoBehaviour
{
    [Header("Selected Components")]
    public EnemyAI enemy;
    public Weapon weapon;
    public Health health;

    [Header("Menu")]
    public GameObject weaponMenu;
    public GameObject enemyMenu;

    [Header("UI")]
    public TMP_Dropdown dropdown;
    public Slider sliderH;
    public Slider sliderD;
    public Slider sliderAS;
    void Start()
    {
        weaponMenu.SetActive(false);
        enemyMenu.SetActive(true);

        sliderH.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderD.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        sliderAS.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    private void Update()
    {

    }
    public void OnEnemySelect()
    {
        if (enemy == null)
            return;

        if (enemy.type == EnemyAI.AIType.Patrol)
            dropdown.value = 0;
        else if (enemy.type == EnemyAI.AIType.Guard)
            dropdown.value = 1;
        else if (enemy.type == EnemyAI.AIType.Chase)
            dropdown.value = 2;

        if (health == null)
            return;
        sliderH.value = health.currentHealth;
        sliderD.value = weapon.damage;
        sliderAS.value = weapon.attackSpeed;
    }
    public void ValueChangeCheck()
    {
        Debug.Log("JS = " + sliderH.value);
    }
    public void DropdownChange()
    {
        if (!enemy)
            return;

        int index = dropdown.value;
        if (index == 0)
            enemy.type = EnemyAI.AIType.Patrol;
        else if (index == 1)
            enemy.type = EnemyAI.AIType.Guard;
        else if (index == 2)
            enemy.type = EnemyAI.AIType.Chase;
    }
    public void SetValues()
    {
        if (!health)
            return;
        health.currentHealth = sliderH.value;

        if (!weapon)
            return;
        weapon.damage = sliderD.value;
        weapon.attackSpeed = sliderAS.value;
    }    

}
