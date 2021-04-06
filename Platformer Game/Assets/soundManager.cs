using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance = null;
    private AudioSource audiosource;
    public AudioClip background;
    public AudioClip hitsound;
    public AudioClip attacksound;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = background;
        audiosource.volume = 1.0f;
        audiosource.loop = true;
        audiosource.mute = false;
        audiosource.Play();
    }

    public void AttackSound()
    {
        audiosource.PlayOneShot(attacksound);
    }
    public void HitSound()
    {
        audiosource.PlayOneShot(hitsound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
