using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// A list of tags which is used to determine whether or not an object is destroyed depending on the tagListType (Blacklist or Whitelist)
// This script is used to prevent the player from being destroyed by their own bullets
public enum TagListType
{
    Blacklist,
    Whitelist
}

public class ObjectDestroyer : MonoBehaviour
{
    //Variables for the tag list types
    [SerializeField]
    private TagListType tagListType = TagListType.Blacklist;

    [SerializeField]
    private List<string> tags;

    //Called when an object collides with another
    void OnTriggerEnter2D(Collider2D other)
    {
        //checks to see if the object contains the game object tag
        bool tagInList = tags.Contains(other.gameObject.tag);

        //Checks to see if the object has the Blacklist tag
        if (tagListType == TagListType.Blacklist && tagInList)
        {
            //If so then destroy it
            Destroy(gameObject);
        }

        //Otherwise check to see if the object has the whitelist tag and is NOT in the Whitelist
        else if (tagListType == TagListType.Whitelist && !tagInList)
        {
            //If so then destroy it  
            Destroy(gameObject);
        }
    }

    // Function used to destroy any objects that leave the viewport in order to save memory
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
