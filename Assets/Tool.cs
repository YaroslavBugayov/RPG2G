using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public void Use()
    {
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        
        if (collider != null)
        {
            collider.enabled = true;
            
            StartCoroutine(DisableCollider(collider));
            
            IEnumerator DisableCollider(Collider2D collider2D)
            {
                yield return new WaitForSeconds(0.1f);
                collider2D.enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Tree tree = collider.GetComponent<Tree>();
            
        if (tree != null)
        {
            tree.Harvest();
        }
    }
}
