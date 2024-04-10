
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chompFightAnimationController : MonoBehaviour
{
    private Animator an;

    // Start is called before the first frame update
    void Start()
    {
        this.an = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.an.SetTrigger("attack");
        }
    }
}
