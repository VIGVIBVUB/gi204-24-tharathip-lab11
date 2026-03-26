using UnityEngine;
using System.Collections.Generic;

public class Gravity : MonoBehaviour
{
    public static List<Gravity> otherObj;
    private Rigidbody rb;
    const float G = 0.00667f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObj == null)
        {
            otherObj = new List<Gravity>();
        }
        otherObj.Add(this);

    }
    void FixedUpdate()
    {
        foreach (Gravity obj in otherObj)
        {
            if (obj != this)
            {
                Attract(obj);
            }           
        }
    }
    void Attract(Gravity otherRb)
    {
        Rigidbody otherRB = otherRb.rb;
        Vector3 direction = rb.position - otherRB.position;

        float distance = direction.magnitude;
        if (distance == 0f) return;

        float forceMagnitude = G * (rb.mass * otherRB.mass) / Mathf.Pow(distance, 2);
        Vector3 gravityForce = forceMagnitude * direction.normalized;
        otherRB.AddForce(gravityForce);
    }
}
