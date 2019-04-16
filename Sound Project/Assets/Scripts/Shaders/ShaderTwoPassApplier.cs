using UnityEngine;

public class ShaderTwoPassApplier : MonoBehaviour
{
    [SerializeField]
    private Material _postProcessingMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //draws the pixels from the source texture to the destination texture
        var temporaryTexture = RenderTexture.GetTemporary (source.width, source.height);
        Graphics.Blit(source, temporaryTexture, _postProcessingMaterial, 0);
        Graphics.Blit(temporaryTexture, destination, _postProcessingMaterial, 1);
        RenderTexture.ReleaseTemporary(temporaryTexture);
    }
}
