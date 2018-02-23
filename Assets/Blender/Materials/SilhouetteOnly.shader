Shader "Outlined/Silhouette Only" {
	Properties{
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline width", Range(0.0, 0.5)) = .001
	}

	CGINCLUDE
	#include "UnityCG.cginc"
	struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 pos : POSITION;
		float4 color : COLOR;
	};

	uniform float _Outline;
	uniform float4 _OutlineColor;

	v2f vert(appdata v) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);

		float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
		float2 offset = TransformViewToProjection(norm.xy);

		o.pos.xy += offset * o.pos.z * _Outline;
		o.color = _OutlineColor;
		return o;
	}
	ENDCG

	SubShader{
		Tags{ "Queue" = "Transparent" }

		Pass{
			ZTest Greater
			// uncomment this to hide inner details:
			Offset -8, -8

			SetTexture[_OutlineColor]{
				ConstantColor(0,0,0,0)
				Combine constant
			}
		}

		Pass{
			Name "OUTLINE"
			Tags{ "LightMode" = "Always" }
			ZTest Greater
			Cull Front


			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			half4 frag(v2f i): COLOR{
				half4 colorTransparent = half4(1,1,1,0);
				return i.color * colorTransparent;
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
}