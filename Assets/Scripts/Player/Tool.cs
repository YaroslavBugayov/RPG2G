using System.Collections;
using Environment;
using UnityEngine;
using Tree = Environment.Tree;

namespace Player
{
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
            Cow cow = collider.GetComponent<Cow>(); 
        
            if (tree != null)
            {
                tree.Harvest();
            }

            if (cow != null)
            {
                cow.Milking();
            }
        }
    }
}
