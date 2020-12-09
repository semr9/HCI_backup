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
	public struct HSteamListenSocket : System.IEquatable<HSteamListenSocket>, System.IComparable<HSteamListenSocket> {
		public static readonly HSteamListenSocket Invalid = new HSteamListenSocket(0);
		public uint m_HSteamListenSocket;

		public HSteamListenSocket(uint value) {
			m_HSteamListenSocket = value;
		}

		public override string ToString() {
			return m_HSteamListenSocket.ToString();
		}

		public override bool Equals(object other) {
			return other is HSteamListenSocket && this == (HSteamListenSocket)other;
		}

		public override int GetHashCode() {
			return m_HSteamListenSocket.GetHashCode();
		}

		public static bool operator ==(HSteamListenSocket x, HSteamListenSocket y) {
			return x.m_HSteamListenSocket == y.m_HSteamListenSocket;
		}

		public static bool operator !=(HSteamListenSocket x, HSteamListenSocket y) {
			return !(x == y);
		}

		public static explicit operator HSteamListenSocket(uint value) {
			return new HSteamListenSocket(value);
		}

		public static explicit operator uint(HSteamListenSocket that) {
			return that.m_HSteamListenSocket;
		}

		public bool Equals(HSteamListenSocket other) {
			return m_HSteamListenSocket == other.m_HSteamListenSocket;
		}

		public int CompareTo(HSteamListenSocket other) {
			return m_HSteamListenSocket.CompareTo(other.m_HSteamListenSocket);
		}
	}
}

#endif // !DISABLESTEAMWORKS
