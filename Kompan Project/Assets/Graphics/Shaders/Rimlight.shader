Shader "Unlit/Rimlight"{
	Properties{
		_MainTex ("Texture", 2D) = "white" {}
		_RimLightColor ("Rim Light Color Tint", Color) = (1,1,1,1)
		_RimLightCutOff ("Rim Light Cutoff", Range(0,1)) = 0.1
	}
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f{
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _RimLightColor;
			float _RimLightCutOff;
			
			v2f vert (appdata v){
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target{
				fixed4 col = tex2D(_MainTex, i.uv);
				float dotProduct = dot(i.normal, UNITY_MATRIX_IT_MV[2].xyz);

				if(abs(dotProduct) < _RimLightCutOff){
					col = col * _RimLightColor;
				}
				return col;
			}
			ENDCG
		}
	}
}
