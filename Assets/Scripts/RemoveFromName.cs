using UnityEngine;

public class RemoveFromName : MonoBehaviour
{
    [SerializeField] private int startIndex;
    [SerializeField] private int count;

    [SerializeField] private string prefix;
    [SerializeField] private string suffix;


    [ContextMenu("Add To Name")]
    private void AddName()
    {
        name = prefix + name + suffix;
    }
    
    [ContextMenu("Remove From Name")]
    private void RemoveName()
    {
        name = name.Remove(startIndex, count);
    }
}
