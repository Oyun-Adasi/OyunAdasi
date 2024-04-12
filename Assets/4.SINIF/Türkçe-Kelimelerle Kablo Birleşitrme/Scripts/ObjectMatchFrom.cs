using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObjectMatchFrom : MonoBehaviour
{
    [SerializeField] private int matchId;

    public int Get_ID()
    {
        return matchId;
    }
}
