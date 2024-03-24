using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRole : MonoBehaviour
{
    public Animator animator;
    [HideInInspector] public Rigidbody2D roleRg;
    [HideInInspector] public CapsuleCollider2D roleCollider;
    
    public virtual void Awake()
    {
        roleRg = GetComponent<Rigidbody2D>();
        roleCollider = GetComponent<CapsuleCollider2D>();
    }

    public virtual void Start()
    {
        
    }
    
    public virtual void Update()
    {
        
    }
}
