Shader "Custom/Refraction"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Maintex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0, 1)) = 0.5
		_Metallic("Metalic", Range(0, 1)) = 0.0
		_NoiseValue("NoiseValue", Range(0, 1)) = 0.0
		_Speed("Speed", float) =  0.0
	}


		SubShader
		{
			Tags{ "RanderType" = "Transparent" "Queue"="Transparent"}
			LOD 200

			GrabPass{}
			
				CGPROGRAM
				#pragma surface surf nolight noambient
				#pragma target 3.0

				#include "UnityCG.cginc"

				sampler2D _Maintex;
				sampler2D _GrabTexture;

				struct Input
				{
					float2 uv_Maintex;
					float4 screenPos;
				};

				half _Glossiness;
				half _Metalic;
				fixed4 _Color;

				float _NoiseValue;
				float _Speed;

				UNITY_INSTANCING_BUFFER_START(Props)
				UNITY_INSTANCING_BUFFER_END(Props)


				void surf (Input IN, inout SurfaceOutput o) //surf: surface
				{
					fixed4 noise = tex2D(_Maintex,IN.uv_Maintex);
					float2 screenUV = IN.screenPos.rgb / IN. screenPos.a;

					o.Emission = tex2D(_GrabTexture, float2	(
						(screenUV.x),
						(screenUV.y) + noise.y * _NoiseValue * sin(_Time.y * _Speed)
						));
				}

				float4 Lightingnolight (SurfaceOutput s, float3 lightDir,float atten)
				{
					return  float4(0, 0, 0, 1);
				}
				ENDCG
			
		}
				FallBack "Ragacy Shader/Transparent/Vertexlit"
	
}
