Shader "Custom/GreenToBlueShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
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

                // Alterar tons verdes para tons azuis
                if (color.g > color.r && color.g > color.b)
                {
                    // O tom verde será alterado para um tom de azul
                    color.rgb = lerp(color.rgb, float3(0.0, 0.0, 2), 0.5); // Ajuste a interpolação conforme necessário
                }

                // Definir a transparência com base no alpha da textura
                color.a = tex2D(_MainTex, i.uv).a;

                return color;
            }
            ENDCG
        }
    }
}
