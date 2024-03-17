using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Player player;
    private SpriteRenderer spriteRenderer;
    private Weapon weapon; 

    public bool WeaponRotationStopped { get; private set; }

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        weapon = GetComponentInChildren < WeaponParent() >;
        weapon.OnAnimationDone += AttackFinished;
    }
    private void AttackFinished()
    {
        WeaponRotaionStopped = false;
    }

    private void Update()
    {
        if (WeaponRotationStopped)
            return;
        transform.right = (player.PointerInput - (Vector2)transform.position).normalized;

        Vector3 scale = transform.localScale;
        float dotProduct = Vector2.Dot(Vector2.right, transform.right);
        if (dotProduct < 0)
        {
            scale.y = -1;
        }
        else if (dotProduct > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
        if (transform.localEulerAngles.z > 180 && transform.localEulerAngles.z < 360)
        {
            spriteRenderer.sortingOrder = 1;
        }
        else
        {
            spriteRenderer.sortingOrder = -1;
        }
    }


    public void PerformAnAttack()
    {
        if (weapon == null)
        {
            Debug.LogError("Weapon is null", gameObject);
            return;
        }
        weapon.Use();
        WeaponRotationStopped = true;
    }

}

}