Shader "Unity Shaders Books/Chapter12/BrightnessSaturationAndContrast"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Brightness ("Brightness", Float) = 1
        _Saturation ("Saturation", Float) = 1
        _Contrast ("Contrast", Float) = 1
    }
    SubShader
    {
        
        Tags { "RenderType"="Opaque" }

        Pass
        {
            // 这些状态设置可以认为是用于屏幕后处理的Shader的“标配”
            // 关闭深度写入，是为了防止它“挡住”在其后面被渲染的物体
            ZTest Always Cull Off ZWrite Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            half _Brightness;
            half _Saturation;
            half _Contrast;

            struct v2f
            {
                half2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            // 使用内置的appdata_img结构体作为顶点着色器的输入，该结构体只包含图像处理时必需的顶点坐标和纹理坐标等变量。
            v2f vert (appdata_img v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 renderTex = tex2D(_MainTex, i.uv);

                // Apply brightness
                fixed3 finalColor = renderTex.rgb * _Brightness;

                // Apply saturation
                fixed luminance = 0.2125 * renderTex.r + 0.7154 * renderTex.g + 0.0721 * renderTex.b;
                fixed3 luminanceColor = fixed3(luminance, luminance, luminance);
                finalColor = lerp(luminanceColor, finalColor, _Saturation);

                // Apply Contrast
                fixed3 avgColor = fixed3(0.5, 0.5, 0.5);
                finalColor = lerp(avgColor, finalColor, _Contrast);

                return fixed4(finalColor, renderTex.a);
            }
            ENDCG
        }
    }
    Fallback Off
}
