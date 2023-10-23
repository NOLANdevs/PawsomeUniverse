using UnityEngine;

public class ToggleOnClick : MonoBehaviour
{
    public ClickToChangeSprite[] ChangeSpriteScripts;
    public ClickToToggleLight[] LightSpriteScripts;
    public ClickToBall[] BallSpriteScripts;
    public ClickToPlayAudio[] AudioSpriteScripts;
    public ClickToScale[] ScaleSpriteScripts;

    [SerializeField] private AudioSource selectSound;

    public void ToggleInteraction(bool state)
    {
        selectSound.Play();
        setSpriteChange(state);
        setSpriteLight(state);
        setBall(state);
        setAudio(state);
        setScale(state);
    }

    private void setSpriteChange(bool state){
        foreach (ClickToChangeSprite script in ChangeSpriteScripts)
        {
            script.SetInteract(state);
        }
    }
    private void setSpriteLight(bool state){
        foreach (ClickToToggleLight script in LightSpriteScripts)
        {
            script.SetInteract(state);
        }
    }
    private void setBall(bool state){
        foreach (ClickToBall script in BallSpriteScripts)
        {
            script.SetInteract(state);
        }
    }
    private void setAudio(bool state){
        foreach (ClickToPlayAudio script in AudioSpriteScripts)
        {
            script.SetInteract(state);
        }
    }
    private void setScale(bool state){
        foreach (ClickToScale script in ScaleSpriteScripts)
        {
            script.SetInteract(state);
        }
    }
}
