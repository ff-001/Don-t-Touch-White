Shader "Custom/SimpleAlpha" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader {
//		Tags{"Queue"="Transparent"}
		Pass{
			blend One One
			Color [_Color]
		}
	} 
	FallBack "Diffuse"
}
