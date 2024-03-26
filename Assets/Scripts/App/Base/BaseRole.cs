using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRole : MonoBehaviour
{
    public Animator animator;
    [HideInInspector] public Rigidbody2D rg;
    [HideInInspector] public CapsuleCollider2D roleCollider;

    #region dectect
    [Header("Detect")]
    public Transform groundDetect;
    public float groundDetectDistance = 0.1f;

    #endregion
    
    public virtual void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        roleCollider = GetComponent<CapsuleCollider2D>();
    }

    public virtual void Start()
    {
        
    }
    
    public virtual void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        // draw ground detect line
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundDetect.position, new Vector2(groundDetect.position.x, groundDetect.position.y - groundDetectDistance));
    }
}
