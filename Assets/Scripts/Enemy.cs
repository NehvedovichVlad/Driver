using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (Mathf.Abs(collision.impulse.x) > 0.5f || Mathf.Abs(collision.impulse.z) > 0.5f)
            {
                Destroy(gameObject);
            }

        }

    }
}
