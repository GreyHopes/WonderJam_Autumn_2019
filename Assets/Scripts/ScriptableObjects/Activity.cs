using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Activity", menuName = "ScriptableObjects/Activity", order = 1)]
public class Activity : ScriptableObject
{
    [SerializeField] private string activityName;
    [SerializeField] private string[] scenes;

    public string[] Scenes { get => scenes; }
}
