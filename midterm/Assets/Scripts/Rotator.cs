using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name.Contains("Box"))
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        if (this.name.Contains("Coin"))
        {
            transform.Rotate(new Vector3(200, 0, 0) * Time.deltaTime);
        }

        if (this.name.Contains("Capsule"))
        {
            transform.Rotate(new Vector3(180, 0, 0) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            

            ScoreManager tmp = GameObject.FindObjectOfType<ScoreManager>();
            if (tmp)
            {
                if (this.name.Contains("Coin"))
                    tmp.score += 10;
                else if (this.name.Contains("Box"))
                    tmp.score += 500;

                GameObject.FindObjectOfType<UI>().score.text = tmp.score.ToString();
            }
            Destroy(gameObject);

        }
    }

}
