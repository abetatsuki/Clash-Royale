using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   [SerializeField] private float _speed;

   // private void Update()
   // {
   //    MovePlayer();
   // }
   //
   // private void MovePlayer()
   // {
   //    float x  = Input.GetAxis("Horizontal");
   //    float z = Input.GetAxis("Vertical") ;
   //
   //    Vector3 movement = new Vector3(x, 0, z) * Time.deltaTime * _speed;
   //    transform.Translate(movement);
   // }
}



