using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchController : MonoBehaviour
{
    [SerializeField] private GameObject useButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Tree"))
        // {
        //     useButton.SetActive(true);
        // }
        useButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        useButton.SetActive(false);
    }
}
