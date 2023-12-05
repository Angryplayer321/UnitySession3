using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float seconds;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("changeState");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator changeState()
    {

        yield return new WaitForSecondsRealtime(seconds);
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
        StartCoroutine("changeState");
    }
}
