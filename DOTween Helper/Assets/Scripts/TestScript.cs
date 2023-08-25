using DOTweenHelper.Runtime.Sequences;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public DOTweenSequenceController SequenceController;

    [NaughtyAttributes.Button("Play")]
    public void Play() => 
        SequenceController.Play();

    [NaughtyAttributes.Button("Pause")]
    public void Pause() => 
        SequenceController.Pause();
    
    [NaughtyAttributes.Button("Restart")]
    public void Restart() => 
        SequenceController.Restart();
    
    [NaughtyAttributes.Button("Go to")]
    public void GoTo() => 
        SequenceController.GoTo(0f, false);

    [NaughtyAttributes.Button("Complete")]
    public void Complete() => 
        SequenceController.Complete(false);
}
