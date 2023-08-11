// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Chapter11-Billboard"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color Tint", Color) = (1,1,1,1)
        _VerticalBillboarding ("Vertical Restraints", Range(0, 1)) = 1
    }
    SubShader
    {
        // Need to disable batching because of the vertex animation
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenferType"="Transparent" "DisableBatching"="True"}

        Pass
        {
            Tags { "LightMode" = "ForwardBase"}
            Zwrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
             
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Lighting.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed _VerticalBillboarding;
            
            struct appdata
            {
                float4 vertex : POSITION;
                float4 col : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };
            
            v2f vert (appdata v)
            {
                v2f o;
                // Suppose the center in object space is fixed
                // 这里设定一个锚点（模型空间的原点），以及求视角位置
                // 所有的计算都是在模型空间下进行的
                //float3 center = float3(0,0,0);
                float3 center = v.col.a;
                
                float3 viewer = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos,1));

                // 这里根据观察位置以及锚点计算目标法线方向，而且根据_VerticalBillboarding属性控制垂直方向上的约束度
                // _VerticalBillboarding为1，法线固定为视角方向；为0，向上方向固定为（0,1,0）
                float3 normalDir = viewer - center;
                // If _VerticalBillborading equals 1, we use the desired view dir as the normal dir
                // Which means the normal dir is fixed
                // Or if _VerticalBillboarding equals 0, the y of normal is 0
                // Which means the up dir is fixed
                normalDir.y = normalDir.y * _VerticalBillboarding;
                normalDir = normalize(normalDir);

                // Get the approximate up dir
                // If normal dir is already towards up, then the up dir is towards front
                float3 upDir = abs(normalDir.y) > 0.999 ? float3(0,0,1) : float3(0,1,0);
                float3 rightDir = normalize(cross(upDir, normalDir));
                //因为上方向还不是准确的，所以反过来上方向
                upDir = normalize(cross(normalDir, rightDir));
                
                float3 centerOffs = v.vertex.xyz - center;
                float3 localPos = center + rightDir * centerOffs.x + upDir * centerOffs.y + normalDir * centerOffs.z;
                o.pos = UnityObjectToClipPos(float4(localPos, 1));
                o.uv = TRANSFORM_TEX(v.uv,_MainTex);
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                c.rgb *= _Color.rgb;

                return c;
            }
            ENDCG
        }
    }
    Fallback "Transparent/VertexLit"
}
