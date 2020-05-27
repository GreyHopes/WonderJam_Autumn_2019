using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cawotte.Toolbox.Audio;



public class upgrade_button : MonoBehaviour
{
    private Button bouton;
    protected AudioSourcePlayer player;
    private void Awake()
    {
        bouton = GetComponent<Button>();
        player = gameObject.AddComponent<AudioSourcePlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bouton.onClick.AddListener(() => player.PlaySound("buy_upgrade"));
    }

}
