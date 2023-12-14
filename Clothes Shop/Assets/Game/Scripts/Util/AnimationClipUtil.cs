using UnityEngine;
using UnityEngine.Assertions;

public static class AnimationClipUtil {
    public static AnimationClip FindContainingName(string clipName, AnimationClip[] clips) {
        Assert.IsNotNull(clips, "AnimationClip array can't be null.");

        foreach (AnimationClip clip in clips) {
            if (clip.name.Contains(clipName, System.StringComparison.InvariantCultureIgnoreCase)) {
                return clip;
            }
        }

        return null;
    }
}
