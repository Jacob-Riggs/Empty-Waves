using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable {

    [SerializeField]
    private float _health = 100;
    private float _maxHealth = 100;
    public float health
    {
        // This will get the current health and hold it every time it is changed
        get
        {
            return _health;
        }
        // This will then set the changed amount when it is changed.
        set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            if (_health <= 0) { /*add special death handle later*/ }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_health > 0)
        {
            health -= damageAmount;
        }
    }

    // Use this for initialization
    void Start()
    {
        health = 100;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            TakeDamage(20);
        }
    }
}
