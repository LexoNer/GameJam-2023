using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D hormigas;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
