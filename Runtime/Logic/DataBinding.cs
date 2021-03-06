﻿using UnityEngine;

namespace traVRsal.SDK
{
    public class DataBinding : ExecutorConfig
    {
        public const int REQUIRE_SOURCE = 1000;
        public const int ASYNC_RESULT = 2000;

        public enum Reference
        {
            OriginalValue = 0,
            AppVersion = 1,

            DoOpenWorldDetailsDialog = 18,
            DoCloseWorldDetailsDialog = 13,
            DoOpenSettingsDialog = 20,
            DoCloseSettingsDialog = 21,
            DoOpenPlayerDialog = 58,
            DoClosePlayerDialog = 59,
            DoCloseInfoDialog = 69,
            DoOpenChallengesDialog = 71,
            DoCloseChallengesDialog = 73,
            DoCloseCreateWorldsDialog = 93,
            DoPause = 15,
            DoReturnToMain = 17,
            DoReturnToMainInterstitial = 70,
            DoPostChallenge = 72,
            DoStartWorld = 14,
            DoStartWorldDownload = 67,
            DoStartRandomChallenge = 109,
            DoUnpause = 16,
            DoLogOut = 63,
            DoClearCache = 68,
            DoResetSettings = 111,
            DoChallengeFilterMine = 94,
            DoChallengeFilterOthers = 95,
            DoChallengeFilterPlayspace = 100,
            DoChallengeFilterNotBeaten = 97,
            DoChallengeFilterBeaten = 96,
            DoChallengeFilterBest = 98,

            EnterLogin = 64,
            EnterNickname = 62,
            EnterNicknameWithTerms = 99,
            EnterPassword = 65,

            WorldCategory = 10,
            WorldCover = ASYNC_RESULT + 3,
            WorldName = 2,
            WorldShortDescription = 11,
            WorldLongDescription = 12,
            WorldTime = 4,
            WorldUpdate = 56,
            WorldUpdateRelative = 92,
            WorldSize = 55,
            WorldOwner = 66,

            PlayerDistance = 9,
            PlayerName = 3,
            PlayerLogin = 57,

            SettingDebugMode = 7,
            SettingPadding = 6,
            SettingTileCount = 5,
            SettingTileSizeHint = 8,

            StatAccuracy = 23,
            StatDeaths = 25,
            StatDistanceWalked = 26,
            StatPlayerDamage = 30,
            StatPoints = 27,
            StatShotsFired = 29,
            StatShotsHit = 28,
            StatTargets = 32,
            StatTargetsDestroyed = 31,
            StatTargetsDestroyedRatio = 24,
            StatTimeOnCriticalPath = 22,

            ChallengePlayer = 110,
            ChallengeStatAccuracy = 81,
            ChallengeStatDeaths = 82,
            ChallengeStatDistanceWalked = 83,
            ChallengeStatPlayerDamage = 84,
            ChallengeStatPoints = 85,
            ChallengeStatShotsFired = 86,
            ChallengeStatShotsHit = 87,
            ChallengeStatTargets = 88,
            ChallengeStatTargetsDestroyed = 89,
            ChallengeStatTargetsDestroyedRatio = 90,
            ChallengeStatTimeOnCriticalPath = 91,

            ChallengesPosted = 101,
            ChallengesPostedBeaten = 102,
            ChallengesPostedBeatenPercentage = 106,
            ChallengesPostedTries = 108,
            ChallengesBeaten = 103,
            ChallengesBeatenBest = 104,
            ChallengesRemaining = 105,
            ChallengesBeatenRemainingPercentage = 107,

            ShowStatAccuracy = 34,
            ShowStatDeaths = 38,
            ShowStatDistanceWalked = 39,
            ShowStatPoints = 40,
            ShowStatTargets = 37,
            ShowStatTimeOnCriticalPath = 33,
            ShowPostChallenge = 74,

            ShowIfChallengeMode = 79,
            ShowIfChallengeWonNormal = 77,
            ShowIfChallengeWonBest = 78,
            ShowIfChallengeWon = 80,

            ShowPlayerLogin = 60,
            ShowPlayerLoggedIn = 61,

            ShowWorldDownload = ASYNC_RESULT + 1,
            ShowWorldStart = ASYNC_RESULT + 2,
            ShowWorldChallenges = 76,
            ShowWorldStatistics = 75,

            ImageName = REQUIRE_SOURCE + 1,
            ImageDescription = REQUIRE_SOURCE + 2,
            ImageDate = REQUIRE_SOURCE + 3,
            ImageAuthor = REQUIRE_SOURCE + 4,
            ImageAuthorLink = REQUIRE_SOURCE + 5,
            ImageLink = REQUIRE_SOURCE + 6,
            ImageRatingsCount = REQUIRE_SOURCE + 7
        }

        [Tooltip("Optional source for the data (e.g. image assignment), otherwise using globally available data")]
        public Component sourceComponent;

        public Component targetComponent;
        public Reference reference;

        [Tooltip("Indicator if boolean result should be checked for false instead of true")]
        public bool invert;

        [Tooltip("Maximum number of characters to be returned (... added if longer)")]
        public int maxLength;

        [Tooltip("Maximum number of lines to be returned (... added if longer)")]
        public int maxLines;

        [Tooltip("Indicator if result should be calculated only once")]
        public bool oneTimeOnly;

        [HideInInspector] public IDataSource dataSource;
        [HideInInspector] public bool isTriggered;

        public void Trigger()
        {
            isTriggered = true;
        }
    }
}