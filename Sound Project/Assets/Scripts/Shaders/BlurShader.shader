Shader "BlurShader"
{
    Properties
    {
        [HideInInspector]_MainTex("Texture", 2D) = "white" {}
        _BlurSize("Blur Size", Range(0,1)) = 0
        [KeywordEnum(Low, Medium, High)] _Samples ("Sample amount", Float) = 0
    }
    SubShader
    {
        // Dont do culling
        //  Dont need to write / read on depth
        Cull Off
        ZWrite Off
        ZTest Always
        
        // Vertical Blur
        Pass 
        {
            CGPROGRAM
            // import unity library for hlsl code
            #include "unityCG.cginc"
            // Define vertex and fragment shader
            #pragma vertex vert_img
            #pragma fragment fragShader
            #pragma multi_compile _SAMPLES_LOW _SAMPLES_MEDIUM _SAMPLES_HIGH
            
            #if _SAMPLES_LOW
                #define SAMPLES 10
            #elif _SAMPLES_MEDIUM
                #define SAMPLES 30
            #else
                #define SAMPLES 100
            #endif

            // texture and transform of the texture
            sampler2D _MainTex;
            float _BlurSize;
            
            // fragment shader
            fixed4 fragShader(v2f_img i) : SV_TARGET
            {
                // init color variable
                float4 col = 0;
                // iterate over blur samples
                for (float index = 0; index < SAMPLES; index++)
                {
                    float offset = (index/(SAMPLES-1) - 0.5) * _BlurSize;
                    float2 uv = i.uv + float2(0, offset);
                    //add color at position to color
                    col += tex2D(_MainTex, uv);
                }
                //divide the sum of values by the amount of samples
                col = col / SAMPLES;
                return col;
            }
            
            ENDCG            
        }
        
        // Horizontal Blur
        Pass 
        {
            CGPROGRAM
            // import unity library for hlsl code
            #include "unityCG.cginc"
            // Define vertex and fragment shader
            #pragma vertex vert_img
            #pragma fragment fragShader
            #pragma multi_compile _SAMPLES_LOW _SAMPLES_MEDIUM _SAMPLES_HIGH
            
            #if _SAMPLES_LOW
                #define SAMPLES 10
            #elif _SAMPLES_MEDIUM
                #define SAMPLES 30
            #else
                #define SAMPLES 100
            #endif

            // texture and transform of the texture
            sampler2D _MainTex;
            float _BlurSize;
            
            // fragment shader
            fixed4 fragShader(v2f_img i) : SV_TARGET
            {
                //calculate aspect ratio
                float invAspect = _ScreenParams.y / _ScreenParams.x;
                //init color variable
                float4 col = 0;
                //iterate over blur samples
                for (float index = 0; index < SAMPLES; index++)
                {
                    //get uv coordinate of sample
                    float offset = (index/(SAMPLES-1) - 0.5) * _BlurSize * invAspect;
                    float2 uv = i.uv + float2(offset, 0);
                    //add color at position to color
                    col += tex2D(_MainTex, uv);
                }
                //divide the sum of values by the amount of samples
                col = col / SAMPLES;
                return col;
            }
            
            ENDCG            
        }
    }
}
