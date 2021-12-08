using System;
using UnityEditor;
using UnityEditor.Build.Reporting;
using static UnityEditor.BuildPipeline;

namespace Editor
{
  public static class Builder
  {
    [MenuItem("Build/Android")]
    public static void BuildAndroid()
    {
      var report = BuildPlayer(
        new BuildPlayerOptions
        {
          target = BuildTarget.Android,
          locationPathName = "../artifacts/BallFighter.apk",
          scenes = new[] { "Assets/Scenes/LoseScene.unity", "Assets/Scenes/MainMenu.unity", "Assets/Scenes/PlayScene.unity" }
        }
     );

      if (report.summary.result != BuildResult.Succeeded)
      {
        throw new Exception("Faiid to build Android package.");
      }
    }
  }

}
