Shader "Custom/SimpleBlueToGreen"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Obtém a cor da textura original
                fixed4 color = tex2D(_MainTex, i.uv);

                // Definindo a faixa de azul a ser convertida
                float3 colorMin = float3(0.2039, 0.3216, 0.5412); // #34528A (RGB)
                float3 colorMax = float3(0.3255, 0.5098, 0.8157); // #5382D0 (RGB)

                // Verifica se o pixel está dentro da faixa de azul especificada
                if (color.r >= colorMin.r && color.r <= colorMax.r &&
                    color.g >= colorMin.g && color.g <= colorMax.g &&
                    color.b >= colorMin.b && color.b <= colorMax.b)
                {
                    // Muda para um tom de verde
                    color = fixed4(0.0, 1.0, 0.0, color.a); // Verde com o mesmo alpha
                }

                // Retorna a cor (modificada ou original)
                return color;
            }
            ENDCG
        }
    }
}
