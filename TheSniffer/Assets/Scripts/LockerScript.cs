using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerScript : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] float maxTime = 2f;
    float aux = 0f;
    bool isSelected=false;
    bool _checked=false;
    bool hasObject = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (isSelected && !_checked)
        {
            aux += Time.deltaTime;
            if (aux > maxTime)
            {
                isSelected = false;
                myAnimator.SetBool("Open", true);
                _checked = true;

                if (hasObject)
                {
                    //Spawn Object / give points
                }
            }
        }

        if (hasObject)
        {
            //code that modify progressBar
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isSelected = true;
            myAnimator.SetBool("Selected",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isSelected = false;
            myAnimator.SetBool("Selected", false);
            aux = 0f;
        }
    }

}
