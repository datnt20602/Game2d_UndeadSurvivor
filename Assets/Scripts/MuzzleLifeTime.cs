using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleLifeTime : MonoBehaviour
{
    private readonly float MUZZLE_LIFE_TIME = 0.1f;
    void Start()
    {
        Destroy(this.gameObject, MUZZLE_LIFE_TIME);
    }
}
