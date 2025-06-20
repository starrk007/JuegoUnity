Shader "Custom/FixedRenderQueue" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
        Tags { "Queue" = "Geometry-10" } // <-- esto fuerza que se dibuje antes del default
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard
        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o) {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
