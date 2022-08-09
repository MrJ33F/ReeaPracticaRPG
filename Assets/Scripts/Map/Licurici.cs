using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Licurici : MonoBehaviour
{
     protected Vector3 velocity;
public Transform _transform;
public float distance = 1f;
public float speedH = 1f;
public float speedV = 0f;
Vector3 _originalPosition;
bool isGoingLeft = false;
public float distFromStartH;
public float distFromStartV;
public void Start () {
    _originalPosition = gameObject.transform.position;
    _transform = GetComponent<Transform>();
    velocity = new Vector3(speedH,speedV,0);
    _transform.Translate ( velocity.x*Time.deltaTime, velocity.y*Time.deltaTime, 0);
}

void Update()
{    
    distFromStartH = transform.position.x - _originalPosition.x;   
    distFromStartV = transform.position.y - _originalPosition.y;
    if (isGoingLeft)
    { 
        // If gone too far, switch direction
        if (distFromStartH < -distance)
            SwitchDirection();

        _transform.Translate (-velocity.x * Time.deltaTime, -velocity.y * Time.deltaTime, 0);
    }
    else
    {
        // If gone too far, switch direction
        if (distFromStartH > distance)
            SwitchDirection();

        _transform.Translate (velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, 0);
    }
    if (isGoingLeft)
    { 
        // If gone too far, switch direction
        if (distFromStartV < -distance)
            SwitchDirection();

        _transform.Translate (-velocity.x * Time.deltaTime, -velocity.y * Time.deltaTime, 0);
    }
    else
    {
        // If gone too far, switch direction
        if (distFromStartV > distance)
            SwitchDirection();

        _transform.Translate (velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, 0);
    }
}

void SwitchDirection()
{
    isGoingLeft = !isGoingLeft;
    //TODO: Change facing direction, animation, etc
}
}
    
       

