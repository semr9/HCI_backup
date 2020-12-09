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
	public struct HSteamNetConnection : System.IEquatable<HSteamNetConnection>, System.IComparable<HSteamNetConnection> {
		public static readonly HSteamNetConnection Invalid = new HSteamNetConnection(0);
		public uint m_HSteamNetConnection;

		public HSteamNetConnection(uint value) {
			m_HSteamNetConnection = value;
		}

		public override string ToString() {
			return m_HSteamNetConnection.ToString();
		}

		public override bool Equals(object other) {
			return other is HSteamNetConnection && this == (HSteamNetConnection)other;
		}

		public override int GetHashCode() {
			return m_HSteamNetConnection.GetHashCode();
		}

		public static bool operator ==(HSteamNetConnection x, HSteamNetConnection y) {
			return x.m_HSteamNetConnection == y.m_HSteamNetConnection;
		}

		public static bool operator !=(HSteamNetConnection x, HSteamNetConnection y) {
			return !(x == y);
		}

		public static explicit operator HSteamNetConnection(uint value) {
			return new HSteamNetConnection(value);
		}

		public static explicit operator uint(HSteamNetConnection that) {
			return that.m_HSteamNetConnection;
		}

		public bool Equals(HSteamNetConnection other) {
			return m_HSteamNetConnection == other.m_HSteamNetConnection;
		}

		public int CompareTo(HSteamNetConnection other) {
			return m_HSteamNetConnection.CompareTo(other.m_HSteamNetConnection);
		}
	}
}

#endif // !DISABLESTEAMWORKS
