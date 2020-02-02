using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    /// <summary>
    /// DamageSystem from which this HealthBar gets its HealthData
    /// </summary>
    public DamageSystem DamageSystem;
    public float MaxStretch = 6.4f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(0.0f, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2((1.0f - (Mathf.Max(DamageSystem.health, 0.0f) / 100.0f)) * MaxStretch, transform.localScale.y);
    }
}
