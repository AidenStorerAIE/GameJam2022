using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                //assetMenu.SetActive(false);
                //enemyMenu.SetActive(false);
            }         

            if (hit.collider.GetComponent<EnemyAI>())
            {
                assetMenu.SetActive(true);
                enemyMenu.enemy = hit.collider.GetComponent<EnemyAI>();
                enemyMenu.gameObject.SetActive(true);
            }
            else
            {
                //assetMenu.SetActive(false);
                //enemyMenu.SetActive(false);
            }                   
              
        }
    }
    private RaycastHit GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }

        return hit;
    }
}
