using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationLogic : MonoBehaviour
{
    Transform player;
    public float timeIntensity;
    public float maxDistance;
    public float minDistance;
    public int numOfRanges = 4;
    int currentRange = 1;
    

    float rangeDistance;
    float distanceToTarget = 0;
    float timer = 0;

    void Start()
    {
        player = GameObject.Find("Character").transform;

        rangeDistance = (maxDistance - minDistance) / numOfRanges;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(this.transform.position, player.position);

        if (distanceToTarget <= maxDistance)
        {
            Debug.Log("HA DE VIBRAR, PERO CUANTO?");
            for (int i = 1; i <= numOfRanges; i++)
            {
                if (distanceToTarget <= maxDistance && distanceToTarget >= maxDistance - rangeDistance * i)
                {
                    Debug.Log("Estas en el Rango: " + i);
                    currentRange = i;
                    break;
                }
            }

            timer += Time.deltaTime;

            if (timer >= timeIntensity/currentRange)
            {
                Handheld.Vibrate();
                Debug.Log("VIBRAAAAA!!!");
                timer = 0;
            }

        }
        else
        {
            timer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, maxDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
