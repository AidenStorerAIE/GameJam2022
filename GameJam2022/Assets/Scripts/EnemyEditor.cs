using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyEditor : MonoBehaviour
{
    [Header("Components")]
    public EnemyAI enemy;
    public Weapon weapon;
    public Health health;

    [Header("Menus")]
    public GameObject weaponMenu;
    public GameObject enemyMenu;

    [Header("UI")]
    public TMP_Dropdown dropdown;
    public Slider speedSlider;
    void Start()
    {        
        weaponMenu.SetActive(false);
        enemyMenu.SetActive(true);
    }
    private void Update()
    {
        
    }
    public void OnEnemySelect()
    {
        if (enemy == null)
            return;
        // set dropdown
        if (enemy.type == EnemyAI.AIType.Patrol)
            dropdown.value = 0;
        else if (enemy.type == EnemyAI.AIType.Guard)
            dropdown.value = 1;
        else if (enemy.type == EnemyAI.AIType.Chase)
            dropdown.value = 2;

        // set speed
        speedSlider.value = enemy.moveSpeed;
    }
    public void DropdownChange()
    {
        if (!enemy)
            return;

        int index = dropdown.value;
        if(index == 0)
            enemy.type = EnemyAI.AIType.Patrol;
        else if(index == 1)
            enemy.type = EnemyAI.AIType.Guard;
        else if (index == 2)
            enemy.type = EnemyAI.AIType.Chase;        
    }  
   
}
