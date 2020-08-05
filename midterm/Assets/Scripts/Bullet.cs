using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;

public class Bullet : MonoBehaviour
{
    private float lifeSpan = 4.0f;
    public GameObject scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void OnTriggerEnter(Collider other)
    {
   
        if (other.CompareTag("Enemy"))
        {
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Destroy(gameObject);

            ScoreManager tmp = GameObject.FindObjectOfType<ScoreManager>();
            if(tmp)
            {
                tmp.kills++;
                tmp.score += 100;
                GameObject.FindObjectOfType<UI>().kills.text = tmp.kills.ToString();
                GameObject.FindObjectOfType<UI>().score.text = tmp.score.ToString();
            }
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

}
