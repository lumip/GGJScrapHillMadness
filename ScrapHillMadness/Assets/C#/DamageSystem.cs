using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int health;
    public int hazardDamage;

    public float groundHazardForce;
    public float flyingHazardForce;

    /// <summary>
    /// Probability with which a wheel is lost on collision
    /// </summary>
    public float loseWheelProbability = 1.0f;

    /// <summary>
    /// Time, in seconds, during which no additional wheels are lost after loosing one
    /// </summary>
    public float loseWheelGraceTime = 1.0f;

    private float lostWheelCountdown = 0.0f;

    public WheelSlot[] wheels;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        lostWheelCountdown = Mathf.Max(lostWheelCountdown -= Time.deltaTime, 0.0f);

        if (health <= 0)
        {
            Restart();
        }
    }


    void TakeDamage (int damage)
    {
        health -= hazardDamage;
    }

    private void LoseRandomWheelMaybe()
    {
        if (lostWheelCountdown <= 0.0f)
        {
            float p = Random.value;
            if (p <= loseWheelProbability)
            {
                int wheelIndex = (int)Random.Range(0, wheels.Length);
                wheels[wheelIndex].LoseWheel();
            }
        }
    }

    private void OnTriggerEnter(Collider hazard)
    {
        if (hazard.tag == "hazard" || hazard.tag == "flyinghazard")
        {
            TakeDamage(hazardDamage);
        }

        if (hazard.tag == "hazard")
        {
            float random1 = Random.Range(0, 5);
            float random2 = Random.Range(0, 5);
            rb.AddForce ((Vector3.up + new Vector3(random1, 0, random2).normalized) * groundHazardForce);
            LoseRandomWheelMaybe();
        }

        if (hazard.tag == "flyinghazard")
        {
            rb.AddForce(((transform.position - hazard.transform.position).normalized + Vector3.up) * flyingHazardForce);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene("1");
    }
}
