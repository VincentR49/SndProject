using UnityEngine;

public class BlurAdjuster : MonoBehaviour
{
    [SerializeField]
    private Material _blurMaterial;


    public void AdjustBlurSize(float value)
    {
        Debug.Log("Set blur size: " + value);
        _blurMaterial.SetFloat("_BlurSize", value);
    }
}
