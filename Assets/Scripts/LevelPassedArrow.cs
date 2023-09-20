using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelPassedArrow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Update()
    {
        if (_target != null)
        {
            Vector3 directionToA = _target.position - transform.position;
            directionToA.z = 0f;

            float angle = Mathf.Atan2(directionToA.y, directionToA.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
