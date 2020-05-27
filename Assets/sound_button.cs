using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cawotte.Toolbox.Audio;



public class sound_button : MonoBehaviour
{
    private Button bouton;

    private void Awake()
    {
        bouton = GetComponent<Button>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bouton.onClick.AddListener(() => AudioManager.Instance.PlaySound("ui_click"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
