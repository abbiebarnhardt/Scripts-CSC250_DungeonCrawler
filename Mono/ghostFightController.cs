
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostFightController : MonoBehaviour
{
    private Animator theAnimator;

    // Start is called before the first frame update
    void Start()
    {
        this.theAnimator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            this.theAnimator.SetTrigger("attack");
        }
    }
}
