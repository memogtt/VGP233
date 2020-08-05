using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask whatCanBeClickOn;

    private NavMeshAgent myAgent;

    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private Rigidbody bullet;

    public float shootForce = 1000.0f;

    public GameObject scoreManager;

    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameOver())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 100, whatCanBeClickOn))
                {
                    myAgent.SetDestination(hitInfo.point);
                }
            }

            Shoot();
        }

    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Rigidbody b = Instantiate(bullet, muzzle.position, muzzle.rotation) as Rigidbody;

            b.AddForce(muzzle.forward * shootForce);

            //Bullet g = Instantiate(bullet2, muzzle.position, muzzle.rotation) as Bullet;
            //g.parentGameObj = gameObject;
            //b.GetComponent<GameObject> 
        }
    }

    public bool IsGameOver()
    {

        //scoreManager.GetComponent<ScoreManager>().score == 
        if (!IsAlive())
        {
            Transform tmp = GameObject.FindObjectOfType<UI>().GetComponent<Transform>();
            tmp.GetChild(2).gameObject.SetActive(true);

            GameObject.FindObjectOfType<UI>().message.text = "YOU DIE, GAME OVER.";
            return true;
        }
        else if (scoreManager.GetComponent<ScoreManager>().score >= 1000)
        {
            Transform tmp = GameObject.FindObjectOfType<UI>().GetComponent<Transform>();
            tmp.GetChild(2).gameObject.SetActive(true);

            GameObject.FindObjectOfType<UI>().message.text = "CONGRATULATIONS, YOU WIN."; 
             return true;
        }
        return false;
    }

    bool IsAlive()
    {
        if (health <= 0)
        {
            return false;
        }
        return true;
    }
}
