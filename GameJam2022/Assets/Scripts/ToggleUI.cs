using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    public Material materialM;
    public Image image;
     public GameObject _settings;
     Image _arrow;
     Animator _dropAnimator;
     bool _dropEnabled = false;
     public List<Sprite> _sprites;
    // Start is called before the first frame update
    void Start()
    {
        _dropAnimator = GetComponent<Animator>();
        _arrow = GameObject.Find("Arrow").GetComponent<Image>();
        _settings.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnim()
    {
        if(_dropEnabled == false)
        {
            _dropAnimator.SetTrigger("Down");
            _dropEnabled = true;
            _arrow.sprite = _sprites[1];
            _settings.SetActive(true);
            image.material = materialM;
            

        }
        else
        {
            _dropAnimator.SetTrigger("Up");
            _dropEnabled=false;
            _arrow.sprite = _sprites[0];
            _settings.SetActive(false);

        }

    }
}
