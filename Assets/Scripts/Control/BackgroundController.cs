using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] float scrollSpeed;

    Vector2 startingPos;
    SpriteRenderer renderer;

    private void Awake()
    {
        startingPos = GetComponentInParent<Transform>().position;
        renderer = GetComponentInParent<SpriteRenderer>();
    }
    private void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, renderer.size.y);
        transform.parent.transform.position = startingPos + Vector2.down * newPos;
    }
}
