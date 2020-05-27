using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField][ReadOnly] private float velocity = 1f;
    [SerializeField][ReadOnly] private float maxLifetime = 2f;
    [SerializeField][ReadOnly] private int damage = 1;
    [SerializeField] private float offset = 0f;

    private Character source;
    
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.zero;
    private float timerLifetime = 0f;

    public Vector2 Direction { get => direction; set => direction = value; }

    public Character Source
    {
        get { return source; }
        set { source = value; }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        if (LayerMask.LayerToName(source.gameObject.layer).Equals("Ally"))
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Ally");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToward(direction);

        if (timerLifetime >= maxLifetime)
        {
            Destroy(gameObject);
            return;
        }

        timerLifetime += Time.fixedDeltaTime;
    }

    public void SetVelocityAndDamage(float velocity, float damage)
    {
        this.damage = (int)damage;
        this.velocity = velocity;
    }

    private void MoveToward(Vector2 direction)
    {
        Vector3 movement = direction * Time.fixedDeltaTime * velocity;

        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        angle += offset;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;

        rb.MovePosition(transform.position + movement);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character != null)
        {
            character.TakeDamage(source, damage);
            Destroy(gameObject);
        }
    }
    
}
