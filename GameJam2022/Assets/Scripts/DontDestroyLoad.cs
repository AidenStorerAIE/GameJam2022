using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyLoad : MonoBehaviour
{
    public Player player;
    private Animator anime;
    public AnimationController controller;
    public List<GameObject> rigidBodies;
    // Start is called before the first frame update
    void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        player = FindObjectOfType<Player>();
        anime = GetComponent<Animator>();
        controller = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewScene()
    {
        player = FindObjectOfType<Player>();
        foreach (var rigidBody in rigidBodies)
        {
            Destroy (rigidBody.GetComponent<MeshCollider>());
        }
            transform.parent = player.transform;
        transform.localPosition = new Vector3(0, 0.5f, 0);
        transform.localScale = new Vector3(.3F, .3F, .3F);
        controller.enabled = true;
        controller.player = FindObjectOfType<Player>().gameObject;
        anime.enabled = true;
        anime.SetBool("Test", true);
    }
}
