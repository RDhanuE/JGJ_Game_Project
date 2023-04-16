using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public AudioSource audioSource;
    private float volume = 1f;

    public string cat_tag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(cat_tag)){
            audioSource.PlayOneShot(audioSource.clip, volume);
            Debug.Log("contact with fish");
            Destroy(gameObject);
        }
    }

}

