using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimDatabase", menuName = "Animation/AnimDatabase")]
public class AnimDatabase : ScriptableObject {
    
    // NOTE The Dictionary facilitate the look up of the data using only the ID
    public List<AnimData> anims = new List<AnimData>();
    private Dictionary<AnimID, AnimData> cache;

    // Get the data of all registered anims and add them to cache
    public void Initialise() {
        cache = new Dictionary<AnimID, AnimData>();
        foreach (var anim in anims)
            cache.Add(anim.id, anim);
    }

    // Return the data of the anim passed as argument
    public AnimData Get(AnimID id) { return cache[id]; }
}
