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
	public static class SteamUserStats {
		/// <summary>
		/// <para> Ask the server to send down this user's data and achievements for this game</para>
		/// </summary>
		public static bool RequestCurrentStats() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_RequestCurrentStats(CSteamAPIContext.GetSteamUserStats());
		}

		/// <summary>
		/// <para> Data accessors</para>
		/// </summary>
		public static bool GetStat(string pchName, out int pData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetStatInt32(CSteamAPIContext.GetSteamUserStats(), pchName2, out pData);
			}
		}

		public static bool GetStat(string pchName, out float pData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetStatFloat(CSteamAPIContext.GetSteamUserStats(), pchName2, out pData);
			}
		}

		/// <summary>
		/// <para> Set / update data</para>
		/// </summary>
		public static bool SetStat(string pchName, int nData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_SetStatInt32(CSteamAPIContext.GetSteamUserStats(), pchName2, nData);
			}
		}

		public static bool SetStat(string pchName, float fData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_SetStatFloat(CSteamAPIContext.GetSteamUserStats(), pchName2, fData);
			}
		}

		public static bool UpdateAvgRateStat(string pchName, float flCountThisSession, double dSessionLength) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_UpdateAvgRateStat(CSteamAPIContext.GetSteamUserStats(), pchName2, flCountThisSession, dSessionLength);
			}
		}

		/// <summary>
		/// <para> Achievement flag accessors</para>
		/// </summary>
		public static bool GetAchievement(string pchName, out bool pbAchieved) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetAchievement(CSteamAPIContext.GetSteamUserStats(), pchName2, out pbAchieved);
			}
		}

		public static bool SetAchievement(string pchName) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_SetAchievement(CSteamAPIContext.GetSteamUserStats(), pchName2);
			}
		}

		public static bool ClearAchievement(string pchName) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_ClearAchievement(CSteamAPIContext.GetSteamUserStats(), pchName2);
			}
		}

		/// <summary>
		/// <para> Get the achievement status, and the time it was unlocked if unlocked.</para>
		/// <para> If the return value is true, but the unlock time is zero, that means it was unlocked before Steam</para>
		/// <para> began tracking achievement unlock times (December 2009). Time is seconds since January 1, 1970.</para>
		/// </summary>
		public static bool GetAchievementAndUnlockTime(string pchName, out bool pbAchieved, out uint punUnlockTime) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetAchievementAndUnlockTime(CSteamAPIContext.GetSteamUserStats(), pchName2, out pbAchieved, out punUnlockTime);
			}
		}

		/// <summary>
		/// <para> Store the current data on the server, will get a callback when set</para>
		/// <para> And one callback for every new achievement</para>
		/// <para> If the callback has a result of k_EResultInvalidParam, one or more stats</para>
		/// <para> uploaded has been rejected, either because they broke constraints</para>
		/// <para> or were out of date. In this case the server sends back updated values.</para>
		/// <para> The stats should be re-iterated to keep in sync.</para>
		/// </summary>
		public static bool StoreStats() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_StoreStats(CSteamAPIContext.GetSteamUserStats());
		}

		/// <summary>
		/// <para> Achievement / GroupAchievement metadata</para>
		/// <para> Gets the icon of the achievement, which is a handle to be used in ISteamUtils::GetImageRGBA(), or 0 if none set.</para>
		/// <para> A return value of 0 may indicate we are still fetching data, and you can wait for the UserAchievementIconFetched_t callback</para>
		/// <para> which will notify you when the bits are ready. If the callback still returns zero, then there is no image set for the</para>
		/// <para> specified achievement.</para>
		/// </summary>
		public static int GetAchievementIcon(string pchName) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetAchievementIcon(CSteamAPIContext.GetSteamUserStats(), pchName2);
			}
		}

		/// <summary>
		/// <para> Get general attributes for an achievement. Accepts the following keys:</para>
		/// <para> - "name" and "desc" for retrieving the localized achievement name and description (returned in UTF8)</para>
		/// <para> - "hidden" for retrieving if an achievement is hidden (returns "0" when not hidden, "1" when hidden)</para>
		/// </summary>
		public static string GetAchievementDisplayAttribute(string pchName, string pchKey) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName))
			using (var pchKey2 = new InteropHelp.UTF8StringHandle(pchKey)) {
				return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetAchievementDisplayAttribute(CSteamAPIContext.GetSteamUserStats(), pchName2, pchKey2));
			}
		}

		/// <summary>
		/// <para> Achievement progress - triggers an AchievementProgress callback, that is all.</para>
		/// <para> Calling this w/ N out of N progress will NOT set the achievement, the game must still do that.</para>
		/// </summary>
		public static bool IndicateAchievementProgress(string pchName, uint nCurProgress, uint nMaxProgress) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_IndicateAchievementProgress(CSteamAPIContext.GetSteamUserStats(), pchName2, nCurProgress, nMaxProgress);
			}
		}

		/// <summary>
		/// <para> Used for iterating achievements. In general games should not need these functions because they should have a</para>
		/// <para> list of existing achievements compiled into them</para>
		/// </summary>
		public static uint GetNumAchievements() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetNumAchievements(CSteamAPIContext.GetSteamUserStats());
		}

		/// <summary>
		/// <para> Get achievement name iAchievement in [0,GetNumAchievements)</para>
		/// </summary>
		public static string GetAchievementName(uint iAchievement) {
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetAchievementName(CSteamAPIContext.GetSteamUserStats(), iAchievement));
		}

		/// <summary>
		/// <para> Friends stats &amp; achievements</para>
		/// <para> downloads stats for the user</para>
		/// <para> returns a UserStatsReceived_t received when completed</para>
		/// <para> if the other user has no stats, UserStatsReceived_t.m_eResult will be set to k_EResultFail</para>
		/// <para> these stats won't be auto-updated; you'll need to call RequestUserStats() again to refresh any data</para>
		/// </summary>
		public static SteamAPICall_t RequestUserStats(CSteamID steamIDUser) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestUserStats(CSteamAPIContext.GetSteamUserStats(), steamIDUser);
		}

		/// <summary>
		/// <para> requests stat information for a user, usable after a successful call to RequestUserStats()</para>
		/// </summary>
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out int pData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetUserStatInt32(CSteamAPIContext.GetSteamUserStats(), steamIDUser, pchName2, out pData);
			}
		}

		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out float pData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetUserStatFloat(CSteamAPIContext.GetSteamUserStats(), steamIDUser, pchName2, out pData);
			}
		}

		public static bool GetUserAchievement(CSteamID steamIDUser, string pchName, out bool pbAchieved) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetUserAchievement(CSteamAPIContext.GetSteamUserStats(), steamIDUser, pchName2, out pbAchieved);
			}
		}

		/// <summary>
		/// <para> See notes for GetAchievementAndUnlockTime above</para>
		/// </summary>
		public static bool GetUserAchievementAndUnlockTime(CSteamID steamIDUser, string pchName, out bool pbAchieved, out uint punUnlockTime) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetUserAchievementAndUnlockTime(CSteamAPIContext.GetSteamUserStats(), steamIDUser, pchName2, out pbAchieved, out punUnlockTime);
			}
		}

		/// <summary>
		/// <para> Reset stats</para>
		/// </summary>
		public static bool ResetAllStats(bool bAchievementsToo) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_ResetAllStats(CSteamAPIContext.GetSteamUserStats(), bAchievementsToo);
		}

		/// <summary>
		/// <para> Leaderboard functions</para>
		/// <para> asks the Steam back-end for a leaderboard by name, and will create it if it's not yet</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardFindResult_t</para>
		/// </summary>
		public static SteamAPICall_t FindOrCreateLeaderboard(string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType) {
			InteropHelp.TestIfAvailableClient();
			using (var pchLeaderboardName2 = new InteropHelp.UTF8StringHandle(pchLeaderboardName)) {
				return (SteamAPICall_t)NativeMethods.ISteamUserStats_FindOrCreateLeaderboard(CSteamAPIContext.GetSteamUserStats(), pchLeaderboardName2, eLeaderboardSortMethod, eLeaderboardDisplayType);
			}
		}

		/// <summary>
		/// <para> as above, but won't create the leaderboard if it's not found</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardFindResult_t</para>
		/// </summary>
		public static SteamAPICall_t FindLeaderboard(string pchLeaderboardName) {
			InteropHelp.TestIfAvailableClient();
			using (var pchLeaderboardName2 = new InteropHelp.UTF8StringHandle(pchLeaderboardName)) {
				return (SteamAPICall_t)NativeMethods.ISteamUserStats_FindLeaderboard(CSteamAPIContext.GetSteamUserStats(), pchLeaderboardName2);
			}
		}

		/// <summary>
		/// <para> returns the name of a leaderboard</para>
		/// </summary>
		public static string GetLeaderboardName(SteamLeaderboard_t hSteamLeaderboard) {
			InteropHelp.TestIfAvailableClient();
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamUserStats_GetLeaderboardName(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard));
		}

		/// <summary>
		/// <para> returns the total number of entries in a leaderboard, as of the last request</para>
		/// </summary>
		public static int GetLeaderboardEntryCount(SteamLeaderboard_t hSteamLeaderboard) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardEntryCount(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard);
		}

		/// <summary>
		/// <para> returns the sort method of the leaderboard</para>
		/// </summary>
		public static ELeaderboardSortMethod GetLeaderboardSortMethod(SteamLeaderboard_t hSteamLeaderboard) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardSortMethod(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard);
		}

		/// <summary>
		/// <para> returns the display type of the leaderboard</para>
		/// </summary>
		public static ELeaderboardDisplayType GetLeaderboardDisplayType(SteamLeaderboard_t hSteamLeaderboard) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardDisplayType(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard);
		}

		/// <summary>
		/// <para> Asks the Steam back-end for a set of rows in the leaderboard.</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardScoresDownloaded_t</para>
		/// <para> LeaderboardScoresDownloaded_t will contain a handle to pull the results from GetDownloadedLeaderboardEntries() (below)</para>
		/// <para> You can ask for more entries than exist, and it will return as many as do exist.</para>
		/// <para> k_ELeaderboardDataRequestGlobal requests rows in the leaderboard from the full table, with nRangeStart &amp; nRangeEnd in the range [1, TotalEntries]</para>
		/// <para> k_ELeaderboardDataRequestGlobalAroundUser requests rows around the current user, nRangeStart being negate</para>
		/// <para>   e.g. DownloadLeaderboardEntries( hLeaderboard, k_ELeaderboardDataRequestGlobalAroundUser, -3, 3 ) will return 7 rows, 3 before the user, 3 after</para>
		/// <para> k_ELeaderboardDataRequestFriends requests all the rows for friends of the current user</para>
		/// </summary>
		public static SteamAPICall_t DownloadLeaderboardEntries(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_DownloadLeaderboardEntries(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd);
		}

		/// <summary>
		/// <para> as above, but downloads leaderboard entries for an arbitrary set of users - ELeaderboardDataRequest is k_ELeaderboardDataRequestUsers</para>
		/// <para> if a user doesn't have a leaderboard entry, they won't be included in the result</para>
		/// <para> a max of 100 users can be downloaded at a time, with only one outstanding call at a time</para>
		/// </summary>
		public static SteamAPICall_t DownloadLeaderboardEntriesForUsers(SteamLeaderboard_t hSteamLeaderboard, CSteamID[] prgUsers, int cUsers) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_DownloadLeaderboardEntriesForUsers(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard, prgUsers, cUsers);
		}

		/// <summary>
		/// <para> Returns data about a single leaderboard entry</para>
		/// <para> use a for loop from 0 to LeaderboardScoresDownloaded_t::m_cEntryCount to get all the downloaded entries</para>
		/// <para> e.g.</para>
		/// <para>		void OnLeaderboardScoresDownloaded( LeaderboardScoresDownloaded_t *pLeaderboardScoresDownloaded )</para>
		/// <para>		{</para>
		/// <para>			for ( int index = 0; index &lt; pLeaderboardScoresDownloaded-&gt;m_cEntryCount; index++ )</para>
		/// <para>			{</para>
		/// <para>				LeaderboardEntry_t leaderboardEntry;</para>
		/// <para>				int32 details[3];		// we know this is how many we've stored previously</para>
		/// <para>				GetDownloadedLeaderboardEntry( pLeaderboardScoresDownloaded-&gt;m_hSteamLeaderboardEntries, index, &amp;leaderboardEntry, details, 3 );</para>
		/// <para>				assert( leaderboardEntry.m_cDetails == 3 );</para>
		/// <para>				...</para>
		/// <para>			}</para>
		/// <para> once you've accessed all the entries, the data will be free'd, and the SteamLeaderboardEntries_t handle will become invalid</para>
		/// </summary>
		public static bool GetDownloadedLeaderboardEntry(SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, out LeaderboardEntry_t pLeaderboardEntry, int[] pDetails, int cDetailsMax) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetDownloadedLeaderboardEntry(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboardEntries, index, out pLeaderboardEntry, pDetails, cDetailsMax);
		}

		/// <summary>
		/// <para> Uploads a user score to the Steam back-end.</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardScoreUploaded_t</para>
		/// <para> Details are extra game-defined information regarding how the user got that score</para>
		/// <para> pScoreDetails points to an array of int32's, cScoreDetailsCount is the number of int32's in the list</para>
		/// </summary>
		public static SteamAPICall_t UploadLeaderboardScore(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, int[] pScoreDetails, int cScoreDetailsCount) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_UploadLeaderboardScore(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, pScoreDetails, cScoreDetailsCount);
		}

		/// <summary>
		/// <para> Attaches a piece of user generated content the user's entry on a leaderboard.</para>
		/// <para> hContent is a handle to a piece of user generated content that was shared using ISteamUserRemoteStorage::FileShare().</para>
		/// <para> This call is asynchronous, with the result returned in LeaderboardUGCSet_t.</para>
		/// </summary>
		public static SteamAPICall_t AttachLeaderboardUGC(SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_AttachLeaderboardUGC(CSteamAPIContext.GetSteamUserStats(), hSteamLeaderboard, hUGC);
		}

		/// <summary>
		/// <para> Retrieves the number of players currently playing your game (online + offline)</para>
		/// <para> This call is asynchronous, with the result returned in NumberOfCurrentPlayers_t</para>
		/// </summary>
		public static SteamAPICall_t GetNumberOfCurrentPlayers() {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_GetNumberOfCurrentPlayers(CSteamAPIContext.GetSteamUserStats());
		}

		/// <summary>
		/// <para> Requests that Steam fetch data on the percentage of players who have received each achievement</para>
		/// <para> for the game globally.</para>
		/// <para> This call is asynchronous, with the result returned in GlobalAchievementPercentagesReady_t.</para>
		/// </summary>
		public static SteamAPICall_t RequestGlobalAchievementPercentages() {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestGlobalAchievementPercentages(CSteamAPIContext.GetSteamUserStats());
		}

		/// <summary>
		/// <para> Get the info on the most achieved achievement for the game, returns an iterator index you can use to fetch</para>
		/// <para> the next most achieved afterwards.  Will return -1 if there is no data on achievement</para>
		/// <para> percentages (ie, you haven't called RequestGlobalAchievementPercentages and waited on the callback).</para>
		/// </summary>
		public static int GetMostAchievedAchievementInfo(out string pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved) {
			InteropHelp.TestIfAvailableClient();
			IntPtr pchName2 = Marshal.AllocHGlobal((int)unNameBufLen);
			int ret = NativeMethods.ISteamUserStats_GetMostAchievedAchievementInfo(CSteamAPIContext.GetSteamUserStats(), pchName2, unNameBufLen, out pflPercent, out pbAchieved);
			pchName = ret != -1 ? InteropHelp.PtrToStringUTF8(pchName2) : null;
			Marshal.FreeHGlobal(pchName2);
			return ret;
		}

		/// <summary>
		/// <para> Get the info on the next most achieved achievement for the game. Call this after GetMostAchievedAchievementInfo or another</para>
		/// <para> GetNextMostAchievedAchievementInfo call passing the iterator from the previous call. Returns -1 after the last</para>
		/// <para> achievement has been iterated.</para>
		/// </summary>
		public static int GetNextMostAchievedAchievementInfo(int iIteratorPrevious, out string pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved) {
			InteropHelp.TestIfAvailableClient();
			IntPtr pchName2 = Marshal.AllocHGlobal((int)unNameBufLen);
			int ret = NativeMethods.ISteamUserStats_GetNextMostAchievedAchievementInfo(CSteamAPIContext.GetSteamUserStats(), iIteratorPrevious, pchName2, unNameBufLen, out pflPercent, out pbAchieved);
			pchName = ret != -1 ? InteropHelp.PtrToStringUTF8(pchName2) : null;
			Marshal.FreeHGlobal(pchName2);
			return ret;
		}

		/// <summary>
		/// <para> Returns the percentage of users who have achieved the specified achievement.</para>
		/// </summary>
		public static bool GetAchievementAchievedPercent(string pchName, out float pflPercent) {
			InteropHelp.TestIfAvailableClient();
			using (var pchName2 = new InteropHelp.UTF8StringHandle(pchName)) {
				return NativeMethods.ISteamUserStats_GetAchievementAchievedPercent(CSteamAPIContext.GetSteamUserStats(), pchName2, out pflPercent);
			}
		}

		/// <summary>
		/// <para> Requests global stats data, which is available for stats marked as "aggregated".</para>
		/// <para> This call is asynchronous, with the results returned in GlobalStatsReceived_t.</para>
		/// <para> nHistoryDays specifies how many days of day-by-day history to retrieve in addition</para>
		/// <para> to the overall totals. The limit is 60.</para>
		/// </summary>
		public static SteamAPICall_t RequestGlobalStats(int nHistoryDays) {
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestGlobalStats(CSteamAPIContext.GetSteamUserStats(), nHistoryDays);
		}

		/// <summary>
		/// <para> Gets the lifetime totals for an aggregated stat</para>
		/// </summary>
		public static bool GetGlobalStat(string pchStatName, out long pData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchStatName2 = new InteropHelp.UTF8StringHandle(pchStatName)) {
				return NativeMethods.ISteamUserStats_GetGlobalStatInt64(CSteamAPIContext.GetSteamUserStats(), pchStatName2, out pData);
			}
		}

		public static bool GetGlobalStat(string pchStatName, out double pData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchStatName2 = new InteropHelp.UTF8StringHandle(pchStatName)) {
				return NativeMethods.ISteamUserStats_GetGlobalStatDouble(CSteamAPIContext.GetSteamUserStats(), pchStatName2, out pData);
			}
		}

		/// <summary>
		/// <para> Gets history for an aggregated stat. pData will be filled with daily values, starting with today.</para>
		/// <para> So when called, pData[0] will be today, pData[1] will be yesterday, and pData[2] will be two days ago,</para>
		/// <para> etc. cubData is the size in bytes of the pubData buffer. Returns the number of</para>
		/// <para> elements actually set.</para>
		/// </summary>
		public static int GetGlobalStatHistory(string pchStatName, long[] pData, uint cubData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchStatName2 = new InteropHelp.UTF8StringHandle(pchStatName)) {
				return NativeMethods.ISteamUserStats_GetGlobalStatHistoryInt64(CSteamAPIContext.GetSteamUserStats(), pchStatName2, pData, cubData);
			}
		}

		public static int GetGlobalStatHistory(string pchStatName, double[] pData, uint cubData) {
			InteropHelp.TestIfAvailableClient();
			using (var pchStatName2 = new InteropHelp.UTF8StringHandle(pchStatName)) {
				return NativeMethods.ISteamUserStats_GetGlobalStatHistoryDouble(CSteamAPIContext.GetSteamUserStats(), pchStatName2, pData, cubData);
			}
		}
#if _PS3
		/// <summary>
		/// <para> Call to kick off installation of the PS3 trophies. This call is asynchronous, and the results will be returned in a PS3TrophiesInstalled_t</para>
		/// <para> callback.</para>
		/// </summary>
		public static bool InstallPS3Trophies() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_InstallPS3Trophies(CSteamAPIContext.GetSteamUserStats());
		}

		/// <summary>
		/// <para> Returns the amount of space required at boot to install trophies. This value can be used when comparing the amount of space needed</para>
		/// <para> by the game to the available space value passed to the game at boot. The value is set during InstallPS3Trophies().</para>
		/// </summary>
		public static ulong GetTrophySpaceRequiredBeforeInstall() {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetTrophySpaceRequiredBeforeInstall(CSteamAPIContext.GetSteamUserStats());
		}

		/// <summary>
		/// <para> On PS3, user stats &amp; achievement progress through Steam must be stored with the user's saved game data.</para>
		/// <para> At startup, before calling RequestCurrentStats(), you must pass the user's stats data to Steam via this method.</para>
		/// <para> If you do not have any user data, call this function with pvData = NULL and cubData = 0</para>
		/// </summary>
		public static bool SetUserStatsData(IntPtr pvData, uint cubData) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_SetUserStatsData(CSteamAPIContext.GetSteamUserStats(), pvData, cubData);
		}

		/// <summary>
		/// <para> Call to get the user's current stats data. You should retrieve this data after receiving successful UserStatsReceived_t &amp; UserStatsStored_t</para>
		/// <para> callbacks, and store the data with the user's save game data. You can call this method with pvData = NULL and cubData = 0 to get the required</para>
		/// <para> buffer size.</para>
		/// </summary>
		public static bool GetUserStatsData(IntPtr pvData, uint cubData, out uint pcubWritten) {
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetUserStatsData(CSteamAPIContext.GetSteamUserStats(), pvData, cubData, out pcubWritten);
		}
#endif
	}
}

#endif // !DISABLESTEAMWORKS
