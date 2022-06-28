using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSimple : monster
{
    void Start()
    {
        clickCount = 5 + FindObjectOfType<spawn>().addExtraTaps;
        speed = 1 + FindObjectOfType<spawn>().addExtraSpeed;

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        movement = new Vector3(Random.Range(-5f, 5f), 0.0f, Random.Range(-5f, 5f));
        rotationSpeed = 10;
    }
}
