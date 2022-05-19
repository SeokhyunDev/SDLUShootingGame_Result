using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Material material = null;
    [SerializeField] float speed = 0.08f;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
