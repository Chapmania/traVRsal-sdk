﻿using System;

namespace traVRsal.SDK
{
    [Serializable]
    public class UserWorld
    {
        public enum WorldState
        {
            initial, preview, released
        }

        public int id;
        public string key;
        public string cover_image;
        public string unity_version;
        public string world_json;
        public WorldState state;
        public string is_private;
        public string is_virtual;
        public long android_size;
        public long pc_size;
        public string last_uploaded_at;
        public string last_statechange_at;
        public string owner;

        public override string ToString()
        {
            return $"Remote World Data {key}";
        }
    }
}