using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    [SerializeField] private Transform player;
    Vector3 mesafe;

    void Start()
    {
        mesafe = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + mesafe;
    }
}
