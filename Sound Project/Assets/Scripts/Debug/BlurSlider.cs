using UnityEngine;
using UnityEngine.UI;

public class BlurSlider : MonoBehaviour
{
    [SerializeField]
    private BlurAdjuster _blurAdjuster;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        OnSliderValueChange();
    }


    public void OnSliderValueChange()
    {
        _blurAdjuster.AdjustBlurSize(_slider.value);
    }
}
