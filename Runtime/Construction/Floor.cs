﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace traVRsal.SDK
{
    [Serializable]
    public class Floor
    {
        [Header("Configuration")]
        public string name;
        public float height = 2.5f;
        public bool underground = false;
        public List<BasicEntity> entities;
        public Dictionary<string, TMProperty[]> layerProps;
        public TMProperty[] properties;

        [Header("Runtime Information")]
        public int idx;
        public PositionInfoMarker[,] positionInfoMarker;
        public Vector3[] shortestPath;
        public Transform node;
        public Bounds bounds;
        public Transform center;

        [HideInInspector]
        [NonSerialized]
        public Maze maze;
        [HideInInspector]
        [NonSerialized]
        public List<Behaviour> portalCache;

        public Floor()
        {
            entities = new List<BasicEntity>();
            layerProps = new Dictionary<string, TMProperty[]>();
        }

        public Floor(string name) : this()
        {
            this.name = name;
        }

        public Floor(Floor copyFrom) : this()
        {
            name = copyFrom.name;
            height = copyFrom.height;
            underground = copyFrom.underground;
            properties = SDKUtil.CopyProperties(copyFrom.properties);

            foreach (string key in copyFrom.layerProps.Keys)
            {
                layerProps.Add(key, SDKUtil.CopyProperties(copyFrom.layerProps[key]));
            }
            foreach (BasicEntity entity in copyFrom.entities)
            {
                entities.Add(new BasicEntity(entity));
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Floor floor &&
                   name == floor.name &&
                   height == floor.height &&
                   underground == floor.underground &&
                   EqualityComparer<List<BasicEntity>>.Default.Equals(entities, floor.entities) &&
                   EqualityComparer<Dictionary<string, TMProperty[]>>.Default.Equals(layerProps, floor.layerProps) &&
                   EqualityComparer<TMProperty[]>.Default.Equals(properties, floor.properties);
        }

        public override int GetHashCode()
        {
            int hashCode = 1827241312;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + height.GetHashCode();
            hashCode = hashCode * -1521134295 + underground.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BasicEntity>>.Default.GetHashCode(entities);
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<string, TMProperty[]>>.Default.GetHashCode(layerProps);
            hashCode = hashCode * -1521134295 + EqualityComparer<TMProperty[]>.Default.GetHashCode(properties);
            return hashCode;
        }

        public override string ToString()
        {
            return $"Floor {idx} ({height}m)";
        }
    }
}