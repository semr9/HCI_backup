// This file is provided under The MIT License as part of Steamworks.NET.
// Copyright (c) 2013-2019 Riley Labrecque
// Please see the included LICENSE.txt for additional information.

// This file is automatically generated.
// Changes to this file will be reverted when you update Steamworks.NET

#if UNITY_ANDROID || UNITY_IOS || UNITY_TIZEN || UNITY_TVOS || UNITY_WEBGL || UNITY_WSA || UNITY_PS4 || UNITY_WII || UNITY_XBOXONE || UNITY_SWITCH
	#define DISABLESTEAMWORKS
#endif

#if !DISABLESTEAMWORKS

using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace Steamworks {
	[System.Serializable]
	public struct SteamNetworkingMicroseconds : System.IEquatable<SteamNetworkingMicroseconds>, System.IComparable<SteamNetworkingMicroseconds> {
		public long m_SteamNetworkingMicroseconds;

		public SteamNetworkingMicroseconds(long value) {
			m_SteamNetworkingMicroseconds = value;
		}

		public override string ToString() {
			return m_SteamNetworkingMicroseconds.ToString();
		}

		public override bool Equals(object other) {
			return other is SteamNetworkingMicroseconds && this == (SteamNetworkingMicroseconds)other;
		}

		public override int GetHashCode() {
			return m_SteamNetworkingMicroseconds.GetHashCode();
		}

		public static bool operator ==(SteamNetworkingMicroseconds x, SteamNetworkingMicroseconds y) {
			return x.m_SteamNetworkingMicroseconds == y.m_SteamNetworkingMicroseconds;
		}

		public static bool operator !=(SteamNetworkingMicroseconds x, SteamNetworkingMicroseconds y) {
			return !(x == y);
		}

		public static explicit operator SteamNetworkingMicroseconds(long value) {
			return new SteamNetworkingMicroseconds(value);
		}

		public static explicit operator long(SteamNetworkingMicroseconds that) {
			return that.m_SteamNetworkingMicroseconds;
		}

		public bool Equals(SteamNetworkingMicroseconds other) {
			return m_SteamNetworkingMicroseconds == other.m_SteamNetworkingMicroseconds;
		}

		public int CompareTo(SteamNetworkingMicroseconds other) {
			return m_SteamNetworkingMicroseconds.CompareTo(other.m_SteamNetworkingMicroseconds);
		}
	}
}

#endif // !DISABLESTEAMWORKS
