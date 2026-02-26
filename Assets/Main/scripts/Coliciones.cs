using System;
using Unity.VisualScripting;
using UnityEngine;

public class Colisiones : MonoBehaviour
{ 
     void OnCollisionEnter2D (Collision2D collison)
{
        Debug.Log("OnCollisionEnter");
}




}