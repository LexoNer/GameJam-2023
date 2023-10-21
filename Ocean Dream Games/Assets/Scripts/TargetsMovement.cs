using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsMovement : MonoBehaviour
{
    [SerializeField] float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = velocity * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), step);
    }

}
