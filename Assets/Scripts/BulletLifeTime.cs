using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletLifeTime : MonoBehaviour
{
    private readonly float LIFE_TIME = 3f;
    void Start()
    {
        Destroy(this.gameObject, LIFE_TIME);
    }
}
