using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyEditor : MonoBehaviour
{
    public EnemyAI enemy;
    public Weapon weapon;
    public EnemyHealth health;

    public GameObject weaponMenu;
    public GameObject enemyMenu;

    public TMP_Dropdown dropdown;
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

        if (enemy.type == EnemyAI.AIType.Patrol)
            dropdown.value = 0;
        else if (enemy.type == EnemyAI.AIType.Guard)
            dropdown.value = 1;
        else if (enemy.type == EnemyAI.AIType.Chase)
            dropdown.value = 2;
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
