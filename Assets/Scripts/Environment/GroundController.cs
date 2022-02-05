using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Environment
{
    public class GroundController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            transform.position += new Vector3(0, 0, 80);
            Debug.Log(other.gameObject.name);
        }
    }
}
