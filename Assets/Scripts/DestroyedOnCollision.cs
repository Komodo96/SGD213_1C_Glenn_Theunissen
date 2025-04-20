using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DestroyedOnCollision gives the attached object a collision behaviour, that will destroy the
/// attached object depending on a list of tags, and whether they should be considered, or ignored.
/// </summary>
public class DestroyedOnCollision : DetectCollisionBase
{
    protected override void ProcessCollision(GameObject other) {
        base.ProcessCollision(other);
        Destroy(other);
    }
}
