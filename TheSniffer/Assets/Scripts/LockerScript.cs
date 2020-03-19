using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerScript : MonoBehaviour
{
    Animator myAnimator;
    GameManager myGameManager;
    [SerializeField] float maxTime = 2f;
    float aux = 0f;
    bool isSelected=false;
    bool _checked=false;
    public bool hasObject = false;
    VibrationLogic myVibrationLogic;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = this.GetComponent<Animator>();
        myVibrationLogic = this.GetComponent<VibrationLogic>();
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (!hasObject)
        {
            myVibrationLogic.enabled = false;
        }
    }

    public void setUp(bool _hasObject)
    {
        hasObject = _hasObject;
        
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
                    myGameManager.objectFound();
                    myVibrationLogic.ZeroSniffBar();
                    myVibrationLogic.enabled = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "DogTrigger")
        {
            isSelected = true;
            myAnimator.SetBool("Selected",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "DogTrigger")
        {
            isSelected = false;
            myAnimator.SetBool("Selected", false);
            aux = 0f;
        }
    }

}
