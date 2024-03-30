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
    public Transform wallDetect;
    public float groundDetectDistance = 0.1f;
    public float wallDetectDistance = 0.1f;

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
        var groundDetectPosition = groundDetect.position;
        Gizmos.DrawLine(groundDetectPosition, new Vector2(groundDetectPosition.x, groundDetectPosition.y - groundDetectDistance));
        
        // draw wall detect line
        Gizmos.color = Color.red;
        var wallDetectPosition = wallDetect.position;
        Gizmos.DrawLine(wallDetectPosition, new Vector2(wallDetectPosition.x + wallDetectDistance, wallDetectPosition.y));
    }
}
