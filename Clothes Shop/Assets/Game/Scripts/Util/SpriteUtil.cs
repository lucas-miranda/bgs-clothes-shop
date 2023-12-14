using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public static class SpriteUtil {
    /// <summary>Get first Sprite from an AnimationClip.</summary>
    public static Sprite GetFirst(AnimationClip clip) {
        Assert.IsNotNull(clip, "AnimationClip can't be null.");

        foreach (EditorCurveBinding curveBinding in AnimationUtility.GetObjectReferenceCurveBindings(clip)) {
            ObjectReferenceKeyframe[] keyframes = AnimationUtility.GetObjectReferenceCurve(clip, curveBinding);

            if (keyframes.Length == 0) {
                continue;
            }

            return keyframes[0].value as Sprite;
        }

        return null;
    }

    /// <summary>
    /// Try to get first sprite from a specific animation clip, containing provided name.
    /// Otherwise, fallback to the first clip available or null.
    /// </summary>
    public static Sprite GetContainingNameOrFirstOrNull(RuntimeAnimatorController runtimeController, string name) {
        Assert.IsNotNull(runtimeController, "RuntimeAnimatorController can't be null.");
        AnimationClip[] clips = runtimeController.animationClips;

        if (clips == null || clips.Length == 0) {
            return null;
        }

        AnimationClip clip = AnimationClipUtil.FindContainingName(name, clips);

        if (clip == null) {
            // retry, but get first clip registered

            if (clips.Length == 0) {
                return null;
            }

            clip = clips[0];
        }

        return SpriteUtil.GetFirst(clip);
    }
}
