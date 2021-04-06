using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Animator anim;
    bool isdie = false;
    float dieTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdie)
        {
            dieTimer += Time.deltaTime;
            if(dieTimer >= 0.3f)
            {
                soundManager.instance.HitSound();
                Destroy(gameObject);
            }
        }
    }
    public void Die() 
    {
        anim.SetBool("isdie", true);
        isdie = true;
    }
}
