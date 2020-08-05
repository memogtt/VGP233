using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNodeScript : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemy.getPatrolDistance());
    }
}
