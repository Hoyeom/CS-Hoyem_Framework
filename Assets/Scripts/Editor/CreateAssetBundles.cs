using System.IO;
using UnityEditor;

namespace Manager.Core
{
    public class CreateAssetBundles
    {
        [MenuItem("Assets/Build AssetBundles")]
        static void BuildAssetBundle()
        {
            string assetBundleDirectory = "Assets/AssetBundles";

            if (!Directory.Exists(assetBundleDirectory))
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }

            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None,
                BuildTarget.StandaloneWindows);
        }
    }
}