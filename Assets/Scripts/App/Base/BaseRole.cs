using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRole : MonoBehaviour
{
    public Animator animator;
    [HideInInspector] public Rigidbody2D rg;
    [HideInInspector] public CapsuleCollider2D roleCollider;
    
    [Header("Now State")] public int dir;

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

    protected virtual void OnDrawGizmos()
    {
        // draw ground detect line
        Gizmos.color = Color.red;
        var groundDetectPosition = groundDetect.position;
        Gizmos.DrawLine(groundDetectPosition, groundDetectPosition + new Vector3(0, -groundDetectDistance, 0));
        
        // draw wall detect line
        Gizmos.color = Color.red;
        var wallDetectPosition = wallDetect.position;
        Gizmos.DrawLine(wallDetectPosition, wallDetectPosition + new Vector3(wallDetectDistance * dir, 0, 0));
    }
    
    public bool DetectGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundDetect.position, Vector2.down, groundDetectDistance, 1 << LayerMask.NameToLayer("Ground"));
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
        
    public bool DetectWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(wallDetect.position, Vector2.right * dir, groundDetectDistance, 1 << LayerMask.NameToLayer("Ground"));
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
