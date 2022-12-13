using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssetSelector : MonoBehaviour
{
    public static AssetSelector Instance;
    [Header("Menus")]
    public GameObject assetMenu;
    public EnemyEditor enemyMenu;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        // disable menus
        assetMenu.SetActive(false);
        enemyMenu.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit = GetMousePos();

            if (hit.collider == null)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    CloseMenu();
                }
            }
            else
            {
                if (hit.collider.GetComponent<EnemyAI>() && !EventSystem.current.IsPointerOverGameObject())
                {
                    assetMenu.SetActive(true);
                    enemyMenu.gameObject.SetActive(true);

                    enemyMenu.enemy = hit.collider.GetComponent<EnemyAI>();
                    enemyMenu.weapon = hit.collider.GetComponent<Weapon>();
                    enemyMenu.health = hit.collider.GetComponent<Health>();

                    enemyMenu.OnEnemySelect();
                }
                else if(!EventSystem.current.IsPointerOverGameObject())
                {
                    CloseMenu();
                }
            }            
        }
        if (enemyMenu.enabled && enemyMenu.enemy == null)
        {
            CloseMenu();
        }
    }
    void CloseMenu()
    {
        assetMenu.SetActive(false);
        enemyMenu.gameObject.SetActive(false);

        // null all variables
        enemyMenu.health = null;
        enemyMenu.enemy = null;
        enemyMenu.weapon = null;
    }
    private RaycastHit GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
        }

        return hit;
    }
}
