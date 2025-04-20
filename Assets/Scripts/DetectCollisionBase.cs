using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionBase : MonoBehaviour
{

    [SerializeField]
    private TagListType tagListType = TagListType.Blacklist;

    // A list of tags which we use to determine whether to explode or not
    // Depending on the tagListType (Blacklist or Whitelist)
    [SerializeField]
    private List<string> tags;

    void OnTriggerEnter2D(Collider2D other)
    {
        bool tagInList = tags.Contains(other.gameObject.tag);

        if (tagListType == TagListType.Blacklist 
            && tagInList)
        {
            // Destroy if it's a Blacklist and the tag IS in the Blacklist
            ProcessCollision(other.gameObject);
        }
        else if (tagListType == TagListType.Whitelist 
            && !tagInList)
        {
            // Destroy if it's a Whitelist and the tag is NOT in the Whitelist
            ProcessCollision(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        bool tagInList = tags.Contains(other.gameObject.tag);

        if (tagListType == TagListType.Blacklist
            && tagInList) {
            // Destroy if it's a Blacklist and the tag IS in the Blacklist
            ProcessCollision(other.gameObject);
        } else if (tagListType == TagListType.Whitelist
              && !tagInList) {
            // Destroy if it's a Whitelist and the tag is NOT in the Whitelist
            ProcessCollision(other.gameObject);
        }
    }

    protected virtual void ProcessCollision(GameObject other) {

        print("Detected collision with " + other.name);
    }
}

public enum TagListType {
    Blacklist,
    Whitelist
}

