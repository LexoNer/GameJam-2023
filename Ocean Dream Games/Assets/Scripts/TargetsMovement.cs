using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsMovement : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = velocity * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + speed, transform.position.y, transform.position.z), step); ;
    }

}
