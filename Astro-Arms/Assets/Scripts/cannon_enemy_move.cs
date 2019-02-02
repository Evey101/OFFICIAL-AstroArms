﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_enemy_move : MonoBehaviour 
{
    public Rigidbody2D rb;
    public bool isleft;
    public Vector3 rotation;

	// Use this for initialization
	void Start () 
    {
        rb.AddForce((Vector3.up), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () 
    {
        rotation = transform.eulerAngles;
        Vector3 dir = Quaternion.AngleAxis(rotation.z, Vector3.forward) * Vector3.forward;
        transform.Rotate(dir);
	}
}
