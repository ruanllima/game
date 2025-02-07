Shader "Custom/DarkGrayToBlack"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Threshold ("Gray Threshold", Range(0, 0.2)) = 0.05
        _DarknessThreshold ("Darkness Threshold", Range(0, 0.5)) = 0.3
    }
    SubShader
    {
        Tags {"RenderType"="Transparent"}
        LOD 200

        Pass
        {
            ZWrite Off
            Cull Off
            Lighting Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Threshold;
            float _DarknessThreshold;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv);
                
                // Calcula a média dos canais RGB para detectar tons de cinza
                float grayValue = (color.r + color.g + color.b) / 3.0;
                
                // Verifica se o pixel é próximo a um tom de cinza
                bool isGray = abs(color.r - grayValue) < _Threshold && abs(color.g - grayValue) < _Threshold && abs(color.b - grayValue) < _Threshold;
                
                // Verifica se o pixel é suficientemente escuro
                bool isDark = grayValue < _DarknessThreshold;

                if (isGray && isDark)
                {
                    // Se for cinza escuro, transforma em preto
                    color.rgb = float3(0.0150, 0.0150, 0.0400);
                }
                
                return color;
            }
            ENDCG
        }
    }
}
