using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyEditor : MonoBehaviour
{
    public EnemyAI enemy;
    public Weapon weapon;

    public GameObject weaponMenu;
    public GameObject enemyMenu;

    public Dropdown dropdown;
    void Start()
    {        
        weaponMenu.SetActive(false);
        enemyMenu.SetActive(true);
    }
    public void DropdownChange()
    {
        int index = dropdown.value;
        if(index == 0)
            enemy.type = EnemyAI.AIType.Patrol;
        else if(index == 1)
            enemy.type = EnemyAI.AIType.Guard;
        else if (index == 2)
            enemy.type = EnemyAI.AIType.Chase;        
    }
   
   
}
